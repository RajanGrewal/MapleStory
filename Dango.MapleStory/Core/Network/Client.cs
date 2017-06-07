using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using Dango.MapleStory.Core.Cryptography;
using Dango.MapleStory.Core.IO;

namespace Dango.MapleStory.Core.Network
{
    public abstract class Client : IDisposable
    {
        /// <summary>
        /// 客户端的网络接口
        /// </summary>
        private readonly TcpClient _client;

        /// <summary>
        /// 服务器发送数据用的加密机
        /// </summary>
        private MapleCryptograph _encryptor;

        /// <summary>
        /// 服务器接收数据用的解密机
        /// </summary>
        private MapleCryptograph _decryptor;

        /// <summary>
        /// 网络接口对应的网络流
        /// </summary>
        private NetworkStream _networkStream;

        private readonly object _lock = new object();

        /// <summary>
        /// 销毁会话事件
        /// </summary>
        public event EventHandler Disposing;

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        /// <summary>
        /// 当前连接的客户端的IP地址
        /// </summary>
        public string ClientIp { get; }

        public bool IsAlive { get; set; }

        /// <summary>
        /// 服务端加密数据时使用的初始化向量
        /// </summary>
        public byte[] SendIv { get; } = new byte[4];

        /// <summary>
        /// 服务端解密数据时使用的初始化向量
        /// </summary>
        public byte[] ReceiveIv { get; } = new byte[4];

        /// <summary>
        /// 会话构造方法
        /// </summary>
        /// <param name="client">网络接口</param>
        public Client(TcpClient client)
        {
            _client = client;
            _client.NoDelay = true;
            _client.SendBufferSize = 0xFFFF;
            _client.ReceiveBufferSize = 0xFFFF;
            _networkStream = _client.GetStream();
            ClientIp = ((IPEndPoint) _client.Client.RemoteEndPoint).Address.ToString();
            IsAlive = true;

            // 生成用于发送和接收的初始化变量
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(SendIv);
                rng.GetNonZeroBytes(ReceiveIv);
            }

            unchecked
            {
                _encryptor = new MapleCryptograph(SendIv, MapleCryptograph.TransformDirection.Encrypt);
                _decryptor = new MapleCryptograph(ReceiveIv, MapleCryptograph.TransformDirection.Decrypt);
            }
        }

        /// <summary>
        /// 持续接收数据
        /// </summary>
        public async void ReceiveData()
        {
            byte[] buffer;

            while (IsAlive)
            {
                if (!_networkStream.DataAvailable) continue;

                try
                {
                    // 读取封包头
                    var length = _encryptor.IvLength;
                    buffer = new byte[length];
                    if (await _networkStream.ReadAsync(buffer, 0, length) == length)
                        length = MapleCryptograph.GetPacketLength(buffer);

                    // 通过收取到的封包头计算数据长度，如果比缓冲区还长则停止会话
                    // 如果检测出封包头不满足约束条件，则停止会话
                    if (length > _client.ReceiveBufferSize || !_decryptor.IsValidHeader(buffer))
                    {
                        Dispose();
                        return;
                    }

                    // 读取真正内容
                    buffer = new byte[length];
                    if (await _networkStream.ReadAsync(buffer, 0, length) == length)
                    {
                        _decryptor.Transform(buffer);
                        OnDataReceived(this, new DataReceivedEventArgs { ReceivedData = buffer });
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"会话：读取数据出错，错误信息 {e.Message}");
                }
            }
        }

        /// <summary>
        /// 提取封包写入器的流中包含的字节数组并发送，自动添加封包头
        /// </summary>
        /// <param name="writer">封包写入器</param>
        public void SendData(ServerPacketWriter writer)
        {
            SendData(writer.ToArray());
        }

        /// <summary>
        /// 连续发送多个字节数组，并自动添加封包头
        /// </summary>
        /// <param name="buffers">任意多个字节数组</param>
        public void SendData(params byte[][] buffers)
        {
            if (!IsAlive) return;

            lock (_lock) // TODO:这里用锁是因为调用他的时候可能是多线程调用，碰到了再说
            {
                var offset = 0;

                // 统计发送全部字符数组需要的长度，4是封包头的长度
                var length = buffers.Sum(buffer => buffer.Length + _encryptor.IvLength);
                var bigBuffer = new byte[length];

                foreach (var buffer in buffers)
                {
                    // 依次将封包头和真正内容填入封包
                    var header = _encryptor.GetPacketHeader(buffer.Length);
                    Buffer.BlockCopy(header, 0, bigBuffer, offset, _encryptor.IvLength);
                    offset += _encryptor.IvLength;
                    _encryptor.Transform(buffer);
                    Buffer.BlockCopy(buffer, 0, bigBuffer, offset, buffer.Length);
                    offset += buffer.Length;
                }

                SendRawData(bigBuffer);
            }
        }

        /// <summary>
        /// 通过网络接口发送字节数组，不自动加封包头
        /// </summary>
        /// <param name="buffer">要发送的字节数组</param>
        public async void SendRawData(byte[] buffer)
        {
            if (!IsAlive) return;

            try
            {
                await _networkStream.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"会话：发送数据出错，错误信息 {e.Message}");
            }
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            IsAlive = false;
            _networkStream.Dispose();
            _client.Close();
            _encryptor?.Dispose();
            _decryptor?.Dispose();
            OnDisposing();
        }
        
        private void OnDisposing() => Disposing?.Invoke(this, EventArgs.Empty);

        private void OnDataReceived(object sender, DataReceivedEventArgs e) => DataReceived?.Invoke(sender, e);
    }

    /// <summary>
    /// 事件<see cref="Client.DataReceived"/>所使用的参数类，包含从客户端接收到的数据<see cref="ReceivedData"/>
    /// </summary>
    public sealed class DataReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 收取到的封包数据
        /// </summary>
        public byte[] ReceivedData { get; set; }
    }
}
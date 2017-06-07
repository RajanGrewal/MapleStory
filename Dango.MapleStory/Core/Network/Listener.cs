using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Core.Network
{
    /// <summary>
    /// 监听端口以建立与客户端连接的帮助类
    /// </summary>
    public sealed class Listener : IDisposable
    {
        /// <summary>
        /// 监听的端口
        /// </summary>
        public short Port { get; }

        private readonly TcpListener _listener;

        /// <summary>
        /// 获取到客户端网络接口的事件
        /// </summary>
        public event EventHandler<ClientAcceptedEventArgs> ClientAccepted;

        /// <summary>
        /// 建立与特定客户端之间连接的帮助类的构造函数
        /// </summary>
        /// <param name="ip">监听对象的IP地址</param>
        /// <param name="port">监听的端口</param>
        public Listener(IPAddress ip, short port)
        {
            Port = port;
            _listener = new TcpListener(ip, port);
        }

        /// <summary>
        /// 建立与任意客户端之间连接的帮助类的构造函数
        /// </summary>
        /// <param name="port">监听的端口</param>
        public Listener(short port) : this(IPAddress.Any, port) { }

        /// <summary>
        /// 异步获取客户端网络接口并触发事件<see cref="ClientAccepted"/>
        /// </summary>
        public async void AcceptSocketAsync()
        {
            var client = await _listener.AcceptTcpClientAsync();  // TODO: 这里不用socket直接用TcpClient是可以的嘛
            OnClientAccepted(this, new ClientAcceptedEventArgs { Client = client });
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            _listener.Server.Close();
        }

        private void OnClientAccepted(object sender, ClientAcceptedEventArgs e) => ClientAccepted?.Invoke(sender, e);

    }

    /// <summary>
    /// 事件<see cref="Listener.ClientAccepted"/>所使用的参数类，包含监听到的客户端网络接口<see cref="Client"/>
    /// </summary>
    public sealed class ClientAcceptedEventArgs : EventArgs
    {
        public TcpClient Client { get; set; }
    }
}

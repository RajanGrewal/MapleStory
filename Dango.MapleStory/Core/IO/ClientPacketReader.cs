using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Data;
using Dango.MapleStory.Network;

namespace Dango.MapleStory.Core.IO
{
    /// <summary>
    /// 从客户端接收到的封包中读取内容的帮助类
    /// </summary>
    public sealed class ClientPacketReader : PacketHelper
    {
        private readonly BinaryReader _reader;

        public ReceiveOperationCodes OperationCode { get; }

        /// <summary>
        /// 根据字节数组构造封包读取工具类的实例
        /// </summary>
        /// <param name="buffer">用于创建流的字节数组</param>
        public ClientPacketReader(byte[] buffer)
        {
            Stream = new MemoryStream(buffer, false);
            _reader = new BinaryReader(Stream, Encoding.ASCII);
            OperationCode = (ReceiveOperationCodes)ReadInt16();
            Disposing += MyOnDisposing;
        }

        /// <summary>
        /// 读取字节数组
        /// </summary>
        /// <param name="count">字节数</param>
        /// <returns>字节数组</returns>
        public byte[] ReadBytes(int count) => _reader.ReadBytes(count);

        /// <summary>
        /// 读取一个字节
        /// </summary>
        /// <returns>字节</returns>
        public byte ReadByte() => _reader.ReadByte();

        /// <summary>
        /// 读取一个布尔值
        /// </summary>
        /// <returns></returns>
        public bool ReadBoolean() => _reader.ReadBoolean();

        /// <summary>
        /// 读取一个短整数
        /// </summary>
        /// <returns>16比特整数</returns>
        public short ReadInt16() => _reader.ReadInt16();

        /// <summary>
        /// 读取一个整数
        /// </summary>
        /// <returns>32比特整数</returns>
        public int ReadInt32() => _reader.ReadInt32();

        /// <summary>
        /// 读取一个长整数
        /// </summary>
        /// <returns>64比特整数</returns>
        public long ReadInt64() => _reader.ReadInt64();

        /// <summary>
        /// 读取一个点结构
        /// </summary>
        /// <returns></returns>
        public Point ReadPoint() => new Point(ReadInt16(), ReadInt16());

        /// <summary>
        /// 读取确定长度字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns>字符串</returns>
        public string ReadString(int length) => new string(_reader.ReadChars(length));

        /// <summary>
        /// 根据流中下一个16比特整数指定的长度读取字符串
        /// </summary>
        /// <returns>字符串</returns>
        public string ReadMapleString() => ReadString(ReadInt16());

        /// <summary>
        /// 根据流中下一个64比特整数读取时间戳
        /// </summary>
        /// <returns></returns>
        public DateTime ReaDateTime() => DateTime.FromFileTimeUtc(ReadInt64());

        /// <summary>
        /// 自定义销毁方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MyOnDisposing(object sender, EventArgs args) => _reader.Dispose();
    }
}

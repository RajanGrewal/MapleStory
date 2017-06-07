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
    /// 向服务器发送的封包写入内容的帮助类
    /// </summary>
    public sealed class ServerPacketWriter : PacketHelper
    {
        private readonly BinaryWriter _writer;

        /// <summary>
        /// 根据操作码和容量构造封包写入帮助类的实例
        /// </summary>
        /// <param name="operationCode">封包操作码</param>
        /// <param name="capacity">封包容量，默认为32字节</param>
        public ServerPacketWriter(SendOperationCodes operationCode, int capacity = 32)
        {
            Stream = new MemoryStream(capacity);
            _writer = new BinaryWriter(Stream, Encoding.ASCII);
            WriteInt16((short) operationCode);
            Disposing += MyOnDisposing;
        }

        /// <summary>
        /// 写入字节数组
        /// </summary>
        /// <param name="buffer">字节数组</param>
        public void WriteBytes(byte[] buffer) => _writer.Write(buffer);

        /// <summary>
        /// 写入一个无符号字节
        /// </summary>
        /// <param name="value">无符号字节，缺省值为0x00</param>
        public void WriteByte(byte value = 0x00) => _writer.Write(value);

        /// <summary>
        /// 写入一个有符号字节
        /// </summary>
        /// <param name="value">有符号字节，缺省值为0x00</param>
        public void WriteSByte(sbyte value = 0x00) => _writer.Write(value);

        /// <summary>
        /// 写入一个布尔值
        /// </summary>
        /// <param name="value">布尔值</param>
        public void WriteBoolean(bool value = false) => _writer.Write(value);

        /// <summary>
        /// 写入一个短整数
        /// </summary>
        /// <param name="value">16比特整数</param>
        public void WriteInt16(short value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个整数
        /// </summary>
        /// <param name="value">32比特整数</param>
        public void WriteInt32(int value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个长整数
        /// </summary>
        /// <param name="value">64比特整数</param>
        public void WriteInt64(long value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个点结构
        /// </summary>
        /// <param name="point">点结构</param>
        public void WritePoint(Point point)
        {
            WriteInt16(point.X);
            WriteInt16(point.Y);
        }

        /// <summary>
        /// 写入一个字符串
        /// </summary>
        /// <param name="value">字符串</param>
        public void WriteString(string value) => _writer.Write(Encoding.Default.GetBytes(value));

        /// <summary>
        /// 写入一个字符串，并截断或补空到指定长度
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="length">指定写入长度</param>
        public void WriteString(string value, int length)
        {
            if (length < value.Length)
                WriteString(value.Substring(0, length));
            else
            {
                WriteString(value);
                WriteZeros(length - value.Length);
            }
        }

        /// <summary>
        /// 写入字符串长度，并写入字符串
        /// </summary>
        /// <param name="value">字符串</param>
        public void WriteMapleString(string value)
        {
            WriteInt16((short) value.Length);
            WriteString(value);
        }

        /// <summary>
        /// 写入字符串长度，并写入按照给定格式生成的字符串
        /// </summary>
        /// <param name="format">字符串格式</param>
        /// <param name="args">生成字符串时使用的参数</param>
        public void WriteMapleString(string format, params object[] args) =>
            WriteMapleString(string.Format(format, args));

        /// <summary>
        /// 写入指定数量的值为0的字节
        /// </summary>
        /// <param name="count">字节数</param>
        public void WriteZeros(int count)
        {
            if (count < 0)
                throw new ArgumentException("count");

            for (var i = 0; i < count; i++)
                WriteByte();
        }

        /// <summary>
        /// 写入时间戳
        /// </summary>
        /// <param name="value">时间</param>
        public void WriteDateTime(DateTime value) => _writer.Write(value.ToFileTimeUtc());


        /// <summary>
        /// 自定义销毁方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MyOnDisposing(object sender, EventArgs args) => _writer.Dispose();
    }
}
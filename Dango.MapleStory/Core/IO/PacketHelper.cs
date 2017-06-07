using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Core.IO
{
    /// <summary>
    /// 写入或读取封包用的帮助类的基类
    /// </summary>
    public abstract class PacketHelper : IDisposable
    {
        /// <summary>
        /// 销毁事件，在销毁实例时发生
        /// </summary>
        public event EventHandler Disposing;

        /// <summary>
        /// 内存中的字节流
        /// </summary>
        protected MemoryStream Stream;

        /// <summary>
        /// 流的字节长度
        /// </summary>
        public int Length => (int)Stream.Length;

        /// <summary>
        /// 获取或设置当前在流中的位置
        /// </summary>
        public int Position
        {
            get => (int) Stream.Position;
            set => Stream.Position = value;
        }

        /// <summary>
        /// 剩余的流的长度
        /// </summary>
        public int Remaining => Length - Position;

        /// <summary>
        /// 在流中跳过指定长度
        /// </summary>
        /// <param name="count">需要跳过的字节数</param>
        public void Skip(int count) => Position += count;

        /// <summary>
        /// 获取流的字节数列
        /// </summary>
        /// <returns>字节数列</returns>
        public byte[] ToArray() => Stream.ToArray();

        /// <summary>
        /// 获取流的16进制字符串
        /// </summary>
        /// <returns>16进制表示的字符串</returns>
        public override string ToString() => ToArray().Aggregate(string.Empty, (_, b) => _ + $"{b:X2}");

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            OnDisposing();
            Stream.Dispose();
        }

        /// <summary>
        /// 在销毁实例时触发委托
        /// </summary>
        protected void OnDisposing() => Disposing?.Invoke(this, EventArgs.Empty);
    }
}

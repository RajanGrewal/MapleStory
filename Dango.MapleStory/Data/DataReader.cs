using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 数据读取器
    /// </summary>
    public class DataReader : IDisposable
    {
        private BinaryReader _reader;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="reader"></param>
        public DataReader(BinaryReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            _reader.Dispose();
        }

        #region Basics

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
        /// 读取一个无符号短整数
        /// </summary>
        /// <returns>16比特无符号整数</returns>
        public ushort ReadUInt16() => _reader.ReadUInt16();

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
        /// 读取一个字符串，字符串有长度作为前缀。
        /// </summary>
        /// <returns></returns>
        public string ReadString() => _reader.ReadString();

        #endregion

        #region Advance

        /// <summary>
        /// 读取数据列表
        /// </summary>
        /// <typeparam name="T">指定数据类型</typeparam>
        /// <returns>数据列表</returns>
        public List<T> ReadList<T>() where T : Data, new()
        {
            var dataList = new List<T>();
            var count = _reader.ReadInt32();
            while (count-- > 0)
            {
                dataList.Add(Read<T>());
            }
            return dataList;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="data">数据</param>
        public T Read<T>() where T : Data, new()
        {
            var data = new T();
            data.Load(this);
            return data;
        }

        #endregion
    }
}
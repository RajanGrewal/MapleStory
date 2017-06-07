using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 数据写入器
    /// </summary>
    public class DataWriter : IDisposable
    {
        private BinaryWriter _writer;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="writer"></param>
        public DataWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            _writer.Dispose();
        }

        #region basics

        /// <summary>
        /// 写入字节数组
        /// </summary>
        /// <param name="buffer">字节数组</param>
        public void Write(byte[] buffer) => _writer.Write(buffer);

        /// <summary>
        /// 写入一个无符号字节
        /// </summary>
        /// <param name="value">无符号字节</param>
        public void Write(byte value) => _writer.Write(value);

        /// <summary>
        /// 写入一个布尔值
        /// </summary>
        /// <param name="value">布尔值</param>
        public void Write(bool value = false) => _writer.Write(value);

        /// <summary>
        /// 写入一个无符号短整数
        /// </summary>
        /// <param name="value">16比特无符号整数</param>
        public void Write(ushort value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个短整数
        /// </summary>
        /// <param name="value">16比特整数</param>
        public void Write(short value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个整数
        /// </summary>
        /// <param name="value">32比特整数</param>
        public void Write(int value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个长整数
        /// </summary>
        /// <param name="value">64比特整数</param>
        public void Write(long value = 0) => _writer.Write(value);

        /// <summary>
        /// 写入一个点结构
        /// </summary>
        /// <param name="point">点结构</param>
        public void Write(Point point)
        {
            Write(point.X);
            Write(point.Y);
        }

        /// <summary>
        /// 写入一个字符串
        /// </summary>
        /// <param name="value">字符串</param>
        public void Write(string value) => _writer.Write(value);

        #endregion

        #region advance

        /// <summary>
        /// 写入数据列表
        /// </summary>
        /// <param name="dataList">数据列表</param>
        public void Write<T>(List<T> dataList) where T : Data
        {
            _writer.Write(dataList.Count);
            foreach (var data in dataList)
            {
                Write<T>(data);
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="data"></param>
        public void Write<T>(T data) where T : Data
        {
            data.Save(this);
        }

        #endregion
    }
}
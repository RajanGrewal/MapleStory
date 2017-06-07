using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Settings;

namespace Dango.MapleStory.Core.Cryptography
{
    /// <summary>
    /// 用于加密或解密
    /// </summary>
    public sealed class MapleCryptograph : IDisposable
    {
        /// <summary>
        /// 指定加密还是解密的枚举类
        /// </summary>
        public enum TransformDirection : byte
        {
            Encrypt,
            Decrypt
        }

        /// <summary>
        /// 初始化向量长度
        /// </summary>
        public readonly int IvLength = 4;

        #region private fields

        /// <summary>
        /// 类似于AES块加密第一个步骤中的S矩阵，16*16=256维，可以用1个字节进行索引
        /// </summary>
        private static readonly byte[] ShuffleBox =
        {
            0xEC, 0x3F, 0x77, 0xA4, 0x45, 0xD0, 0x71, 0xBF, 0xB7, 0x98, 0x20, 0xFC, 0x4B, 0xE9, 0xB3, 0xE1,
            0x5C, 0x22, 0xF7, 0x0C, 0x44, 0x1B, 0x81, 0xBD, 0x63, 0x8D, 0xD4, 0xC3, 0xF2, 0x10, 0x19, 0xE0,
            0xFB, 0xA1, 0x6E, 0x66, 0xEA, 0xAE, 0xD6, 0xCE, 0x06, 0x18, 0x4E, 0xEB, 0x78, 0x95, 0xDB, 0xBA,
            0xB6, 0x42, 0x7A, 0x2A, 0x83, 0x0B, 0x54, 0x67, 0x6D, 0xE8, 0x65, 0xE7, 0x2F, 0x07, 0xF3, 0xAA,
            0x27, 0x7B, 0x85, 0xB0, 0x26, 0xFD, 0x8B, 0xA9, 0xFA, 0xBE, 0xA8, 0xD7, 0xCB, 0xCC, 0x92, 0xDA,
            0xF9, 0x93, 0x60, 0x2D, 0xDD, 0xD2, 0xA2, 0x9B, 0x39, 0x5F, 0x82, 0x21, 0x4C, 0x69, 0xF8, 0x31,
            0x87, 0xEE, 0x8E, 0xAD, 0x8C, 0x6A, 0xBC, 0xB5, 0x6B, 0x59, 0x13, 0xF1, 0x04, 0x00, 0xF6, 0x5A,
            0x35, 0x79, 0x48, 0x8F, 0x15, 0xCD, 0x97, 0x57, 0x12, 0x3E, 0x37, 0xFF, 0x9D, 0x4F, 0x51, 0xF5,
            0xA3, 0x70, 0xBB, 0x14, 0x75, 0xC2, 0xB8, 0x72, 0xC0, 0xED, 0x7D, 0x68, 0xC9, 0x2E, 0x0D, 0x62,
            0x46, 0x17, 0x11, 0x4D, 0x6C, 0xC4, 0x7E, 0x53, 0xC1, 0x25, 0xC7, 0x9A, 0x1C, 0x88, 0x58, 0x2C,
            0x89, 0xDC, 0x02, 0x64, 0x40, 0x01, 0x5D, 0x38, 0xA5, 0xE2, 0xAF, 0x55, 0xD5, 0xEF, 0x1A, 0x7C,
            0xA7, 0x5B, 0xA6, 0x6F, 0x86, 0x9F, 0x73, 0xE6, 0x0A, 0xDE, 0x2B, 0x99, 0x4A, 0x47, 0x9C, 0xDF,
            0x09, 0x76, 0x9E, 0x30, 0x0E, 0xE4, 0xB2, 0x94, 0xA0, 0x3B, 0x34, 0x1D, 0x28, 0x0F, 0x36, 0xE3,
            0x23, 0xB4, 0x03, 0xD8, 0x90, 0xC8, 0x3C, 0xFE, 0x5E, 0x32, 0x24, 0x50, 0x1F, 0x3A, 0x43, 0x8A,
            0x96, 0x41, 0x74, 0xAC, 0x52, 0x33, 0xF0, 0xD9, 0x29, 0x80, 0xB1, 0x16, 0xD3, 0xAB, 0x91, 0xB9,
            0x84, 0x7F, 0x61, 0x1E, 0xCF, 0xC5, 0xD1, 0x56, 0x3D, 0xCA, 0xF4, 0x05, 0xC6, 0xE5, 0x08, 0x49
        };

        /// <summary>
        /// 客户端的版本号
        /// </summary>
        private static short MajorVersion;

        /// <summary>
        /// 初始化向量
        /// </summary>
        private readonly byte[] _iv;

        /// <summary>
        /// 加密方法或解密方法之一
        /// </summary>
        private Action<byte[]> _transformer;


        #endregion

        #region public functions

        /// <summary>
        /// 加密解密类初始化
        /// </summary>
        /// <param name="iv">初始化向量</param>
        /// <param name="direction">操作方向</param>
        public MapleCryptograph(byte[] iv, TransformDirection direction)
        {
            _iv = new byte[IvLength];
            Buffer.BlockCopy(iv, 0, _iv, 0, IvLength); // 从iv直接clone的话是浅层副本，最好用这个
            switch (direction)
            {
                case TransformDirection.Encrypt:
                    unchecked
                    {
                        MajorVersion = (short) (0xFFFF - ServerSettings.MapleVersion);
                    }
                    _transformer = Encrypt;
                    break;
                case TransformDirection.Decrypt:
                    MajorVersion = ServerSettings.MapleVersion;
                    _transformer = Decrypt;
                    break;
            }

        }

        /// <summary>
        /// 实施加密或解密操作
        /// </summary>
        /// <param name="data"></param>
        public void Transform(byte[] data)
        {
            _transformer(data);
            Shuffle(_iv);
        }

        /// <summary>
        /// 计算封包头
        /// </summary>
        /// <param name="length">封包内数据内容的长度</param>
        /// <returns></returns>
        public byte[] GetPacketHeader(int length)
        {
            var a = _iv[3] & 0xFF;
            a |= (_iv[2] << 8) & 0xFF00;
            a ^= MajorVersion;
            var b = a ^ length;

            var header = new byte[4];
            header[0] = (byte) (ShiftRight(a, 8) & 0xFF);
            header[1] = (byte) (a & 0xFF);
            header[2] = (byte) (ShiftRight(b, 8) & 0xFF);
            header[3] = (byte) (b & 0xFF);
            return header;
        }

        /// <summary>
        /// 由封包头计算封包真正内容的长度
        /// </summary>
        /// <param name="packetHeader">封包头</param>
        /// <returns></returns>
        public static int GetPacketLength(byte[] packetHeader)
        {
            return (packetHeader[0] + (packetHeader[1] << 8)) ^ (packetHeader[2] + (packetHeader[3] << 8));
        }

        /// <summary>
        /// 检测收取到的封包头是否满足理论上的约束条件
        /// </summary>
        /// <param name="packet">收到的封包</param>
        /// <returns></returns>
        public bool IsValidHeader(byte[] packet)
        {
            var a = packet[0] ^ _iv[2];
            var b = (MajorVersion >> 8) & 0xFF;
            var c = packet[1] ^ _iv[3];
            var d = MajorVersion & 0xFF;
            return a == b && c == d;
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public void Dispose()
        {
            _transformer = null;
        }

        #endregion

        #region private functions

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="data"></param>
        private void Encrypt(byte[] data)
        {
            ShandaCryptograph.Encrypt(data);
            AesCryptograh.Transform(data, _iv);
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="data"></param>
        private void Decrypt(byte[] data)
        {
            AesCryptograh.Transform(data, _iv);
            ShandaCryptograph.Decrypt(data);
        }

        /// <summary>
        /// 打乱初始化变量
        /// </summary>
        /// <param name="iv">初始化变量</param>
        /// <returns></returns>
        private void Shuffle(byte[] iv)
        {
            var newIv = new byte[] {0xF2, 0x53, 0x50, 0xC6};
            for (var i = 0; i < IvLength; i++)
            {
                var inputByte = iv[i];
                var boxByte = ShuffleBox[inputByte];

                newIv[0] += (byte) (ShuffleBox[newIv[1]] - inputByte);
                newIv[1] -= (byte) (newIv[2] ^ boxByte);
                newIv[2] ^= (byte) (ShuffleBox[newIv[3]] + inputByte);
                newIv[3] -= (byte) (newIv[0] - boxByte);

                var a = BitConverter.ToUInt32(newIv, 0);
                var b = a >>= 0x1D;
                b <<= 0x03;
                a |= b;
                newIv[0] = (byte)(a & 0xFF);
                newIv[1] = (byte)((a >> 8) & 0xFF);
                newIv[2] = (byte)((a >> 16) & 0xFF);
                newIv[3] = (byte)((a >> 24) & 0xFF);
            }
            Buffer.BlockCopy(newIv, 0, _iv, 0, IvLength);
        }

        private static int ShiftRight(int value, int shift)
        {
            if (shift == 0) return value;

            var mask = 0x7FFFFFFF;
            value >>= 1;
            value &= mask;
            value >>= shift - 1;
            return value;
        }

        #endregion
    }
}
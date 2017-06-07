using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Core.Cryptography
{
    /// <summary>
    /// 加密解密类（盛大的算法）
    /// </summary>
    public sealed class ShandaCryptograph
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="data">明文数据</param>
        public static void Encrypt(byte[] data)
        {
            var length = data.Length;
            int j;
            byte a, c;
            for (var i = 0; i < 3; i++)
            {
                a = 0;
                for (j = length; j > 0; j--)
                {
                    c = data[length - j];
                    c = RollLeft(c, 3);
                    c = (byte)(c + j);
                    c ^= a;
                    a = c;
                    c = RollRight(a, j);
                    c ^= 0xFF;
                    c += 0x48;
                    data[length - j] = c;
                }
                a = 0;
                for (j = data.Length; j > 0; j--)
                {
                    c = data[j - 1];
                    c = RollLeft(c, 4);
                    c = (byte)(c + j);
                    c ^= a;
                    a = c;
                    c ^= 0x13;
                    c = RollRight(c, 3);
                    data[j - 1] = c;
                }
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="data">密文数据</param>
        public static void Decrypt(byte[] data)
        {
            var length = data.Length;
            int j;
            byte a, b, c;
            for (var i = 0; i < 3; i++)
            {
                a = 0;
                b = 0;
                for (j = length; j > 0; j--)
                {
                    c = data[j - 1];
                    c = RollLeft(c, 3);
                    c ^= 0x13;
                    a = c;
                    c ^= b;
                    c = (byte)(c - j);
                    c = RollRight(c, 4);
                    b = a;
                    data[j - 1] = c;
                }
                a = 0;
                b = 0;
                for (j = length; j > 0; j--)
                {
                    c = data[length - j];
                    c -= 0x48;
                    c ^= 0xFF;
                    c = RollLeft(c, j);
                    a = c;
                    c ^= b;
                    c = (byte)(c - j);
                    c = RollRight(c, 3);
                    b = a;
                    data[length - j] = c;
                }
            }
        }

        private static byte RollLeft(byte value, int shift)
        {
            var num = (uint) (value << (shift % 8));
            return (byte) ((num & 0xff) | (num >> 8));
        }

        private static byte RollRight(byte value, int shift)
        {
            var num = (uint) ((value << 8) >> (shift % 8)); // 相当于右移 8 - (shift % 8)
            return (byte) ((num & 0xff) | (num >> 8));
        }
    }
}

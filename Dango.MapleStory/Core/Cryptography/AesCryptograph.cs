using System;
using System.Security.Cryptography;

namespace Dango.MapleStory.Core.Cryptography
{
    /// <summary>
    /// AES加密解密类
    /// </summary>
    public sealed class AesCryptograh
    {
        /// <summary>
        /// AES加密解密时使用的密钥
        /// </summary>
        private static readonly byte[] Key =
        {
            0x13, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0xB4, 0x00, 0x00, 0x00,
            0x1B, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x33, 0x00, 0x00, 0x00, 0x52, 0x00, 0x00, 0x00
        };

        private static ICryptoTransform _transformer;

        /// <summary>
        /// 构造ECB模式AES加密器
        /// </summary>
        public AesCryptograh()
        {
            var aes = new RijndaelManaged()
            {
                Key = Key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            using (aes)
            {
                _transformer = aes.CreateEncryptor();
            }
        }

        /// <summary>
        /// 块加密
        /// </summary>
        /// <param name="data">明文</param>
        /// <param name="iv">4字节初始化向量</param>
        public static void Transform(byte[] data, byte[] iv)
        {
            var morphKey = new byte[16];    // 用于强化ECB模式的密钥
            var remaining = data.Length;    // 记录还未加密的明文长度
            var position = 0;               // 记录块在明文中的位置
            var length = 0x5B0;             // 明文块大小，初始值为1456 TODO: 不知为什么这么设置

            while (remaining > 0)
            {
                // 重置强化密钥
                for (var i = 0; i < 16; i++)
                    morphKey[i] = iv[i % 4];

                if (remaining < length)
                    length = remaining;

                for (var offset = 0; offset < length; offset++)
                {
                    var mod = offset % 16;
                    // 每16字节就修改一次强化用密钥，避免ECB模式明文块与密文块一一对应的问题
                    if (mod == 0)
                        _transformer.TransformBlock(morphKey, 0, 16, morphKey, 0);
                    data[position + offset] ^= morphKey[mod];
                }

                position += length;
                remaining -= length;
                length = 0x5B4; // 修改明文块大小为1460
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Global;

namespace Dango.MapleStory.Core.Cryptography
{
    /// <summary>
    /// 哈希值生成器
    /// </summary>
    public static class HashGenerator
    {
        /// <summary>
        /// 生成MD5哈希值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns></returns>
        public static string GenerateMD5(string input = null)
        {
            input = input ?? Constants.Random.Next().ToString();
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(input)))
                .Replace("-", "").ToLower();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Core.Cryptography
{
    /// <summary>
    /// SHA加密
    /// </summary>
    public static class Sha256Cryptograph
    {
        /// <summary>
        /// 密码加密类
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <param name="salt">密码盐</param>
        /// <returns></returns>
        public static string Encrypt(string password, string salt)
        {
            using (var sha = new SHA256Managed())
                return BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(password + salt))).Replace("-", "").ToUpper();
        }
    }
}
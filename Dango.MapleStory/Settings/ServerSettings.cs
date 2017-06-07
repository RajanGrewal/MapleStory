using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Settings
{
    /// <summary>
    /// 服务器设置
    /// </summary>
    public static class ServerSettings
    {
        /// <summary>
        /// 冒险岛版本
        /// </summary>
        public const short MapleVersion = 79;

        /// <summary>
        /// 补丁版本
        /// </summary>
        public const string MaplePatch = "1";

        /// <summary>
        /// 地域  1:韩国，2:韩国测试服，3:日本，4:中国，5:中国/国际测试服，6:台湾，7:新加坡，8:国际，9:欧洲
        /// </summary>
        public const byte Locale = 4;

        /// <summary>
        /// 频道数量
        /// </summary>
        public const byte ChannelCount = 1;

        /// <summary>
        /// TODO:
        /// </summary>
        public const int BacklogLimit = 20;

        /// <summary>
        /// 服务器名
        /// </summary>
        public const string ServerName = "MapleStory";

        /// <summary>
        /// 服务器端口
        /// </summary>
        public const int ServerPort = 8484;

        /// <summary>
        /// 频道端口
        /// </summary>
        public const int ChannelPort = 7575;

        /// <summary>
        /// TODO:服务器广告
        /// </summary>
        public const string ServerAdvertisement = "";

        /// <summary>
        /// 每个账号最多创建的角色数
        /// </summary>
        public const int MaxCharacterNumber= 6;

    }
}

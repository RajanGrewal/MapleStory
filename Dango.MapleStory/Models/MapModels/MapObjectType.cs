namespace Dango.MapleStory.Models.MapModels
{
    /// <summary>
    /// 地图物体的种类
    /// </summary>
    public enum MapObjectType
    {
        /// <summary>
        /// 角色人物
        /// </summary>
        Character,

        /// <summary>
        /// 掉落物体
        /// </summary>
        Drop,

        /// <summary>
        /// 怪物
        /// </summary>
        Mob,

        /// <summary>
        /// 非玩家角色
        /// </summary>
        Npc,

        /// <summary>
        /// 反应器，像任务用的木箱打完就没了
        /// </summary>
        Reactor,

        /// <summary>
        /// 地图传送门
        /// </summary>
        Portal,

        /// <summary>
        /// 商店
        /// </summary>
        Shop,

        /// <summary>
        /// 雇佣商人
        /// </summary>
        HiredMerchant,

        /// <summary>
        /// 五目石
        /// </summary>
        Omok
    }
}
namespace Dango.MapleStory.Enums
{
    /// <summary>
    /// 背包栏类型
    /// </summary>
    public enum InventoryType : byte
    {
        /// <summary>
        /// 未定义
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// 装备
        /// </summary>
        Equipment = 1,

        /// <summary>
        /// 消耗
        /// </summary>
        Usable = 2,

        /// <summary>
        /// 设置
        /// </summary>
        Setup = 3,

        /// <summary>
        /// 其他
        /// </summary>
        Etc = 4,

        /// <summary>
        /// TODO: 大概是现金装备栏？
        /// </summary>
        Cash = 5,

        /// <summary>
        /// 着装  TODO: 这个在Destiny里面写成Count，不知道为什么
        /// </summary>
        Equipped = 6
    }
}
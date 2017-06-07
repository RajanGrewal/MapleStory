using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 背包装备物品模型
    /// </summary>
    [Table("InventoryEquipments")]
    public class InventoryEquipment : InventoryItem
    {
        /// <summary>
        /// TODO: 升级次数？
        /// </summary>
        public byte UpgradeSlots { get; set; }

        /// <summary>
        /// TODO: 被锁定
        /// </summary>
        public byte Locked { get; set; }

        /// <summary>
        /// 要求等级
        /// </summary>
        public byte RequiredLevel { get; set; }

        /// <summary>
        /// 需要的力量
        /// </summary>
        public short RequiredStrength { get; set; }

        /// <summary>
        /// 需要的敏捷
        /// </summary>
        public short RequiredDexterity { get; set; }

        /// <summary>
        /// 需要的智力
        /// </summary>
        public short RequiredIntelligence { get; set; }

        /// <summary>
        /// 需要的运气
        /// </summary>
        public short RequiredLuck { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        public short Health { get; set; }

        /// <summary>
        /// 魔量
        /// </summary>
        public short Mana { get; set; }

        /// <summary>
        /// 武器攻击力
        /// </summary>
        public short WeaponAttack { get; set; }

        /// <summary>
        /// 魔法攻击力
        /// </summary>
        public short MagicAttack { get; set; }

        /// <summary>
        /// 武器防御力
        /// </summary>
        public short WeaponDefence { get; set; }

        /// <summary>
        /// 魔法防御力
        /// </summary>
        public short MagicDefence { get; set; }

        /// <summary>
        /// 精准
        /// </summary>
        public short Accuracy { get; set; }

        /// <summary>
        /// 闪避
        /// </summary>
        public short Avoid { get; set; }

        /// <summary>
        /// TODO: 不知道是啥，双手？
        /// </summary>
        public short Hands { get; set; }

        /// <summary>
        /// 移动速度
        /// </summary>
        public short Speed { get; set; }

        /// <summary>
        /// 跳跃力
        /// </summary>
        public short Jump { get; set; }

        /// <summary>
        /// TODO: 不知道是啥
        /// </summary>
        public short Vicious { get; set; }

        /// <summary>
        /// 是否为耳环
        /// </summary>
        public bool IsRing { get; set; }

        /// <summary>
        /// TODO: 不知道是啥
        /// </summary>
        public byte Flag { get; set; }
    }
}
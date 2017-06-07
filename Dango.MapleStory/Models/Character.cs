using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dango.MapleStory.Enums;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 角色模型
    /// </summary>
    [Table("Characters")]
    public class Character
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 账号->角色的一对多链接
        /// </summary>
        [Required]
        public Account Account { get; set; }

        /// <summary>
        /// 保存账号的ID的外键
        /// </summary>
        [ForeignKey(nameof(Account))]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountId { get; set; }

        /// <summary>
        /// 世界ID
        /// </summary>
        public byte WorldId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色职业
        /// </summary>
        public Job Job { get; set; }

        /// <summary>
        /// 角色管理员等级
        /// </summary>
        public GameManagerLevel GameManagerLevel { get; set; }

        /// <summary>
        /// 角色性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 角色等级
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// 角色金钱
        /// </summary>
        public int Meso { get; set; }

        /// <summary>
        /// 角色经验值
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// 角色运气值
        /// </summary>
        public short Luck { get; set; }

        /// <summary>
        /// 角色敏捷值
        /// </summary>
        public short Dexterity { get; set; }

        /// <summary>
        /// 角色智力值
        /// </summary>
        public short Intelligence { get; set; }

        /// <summary>
        /// 角色力量值
        /// </summary>
        public short Strength { get; set; }

        /// <summary>
        /// 角色当前血量
        /// </summary>
        public short Health { get; set; }

        /// <summary>
        /// 角色血量上限
        /// </summary>
        public short MaxHealth { get; set; }

        /// <summary>
        /// 角色魔量
        /// </summary>
        public short Mana { get; set; }

        /// <summary>
        /// 角色魔量上限
        /// </summary>
        public short MaxMana { get; set; }

        /// <summary>
        /// 角色脸型码
        /// </summary>
        public int Face { get; set; }

        /// <summary>
        /// 角色肤色码
        /// </summary>
        public byte Skin { get; set; }

        /// <summary>
        /// 角色人气值
        /// </summary>
        public short Fame { get; set; }

        /// <summary>
        /// 角色所在地图ID
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// 角色复活点
        /// </summary>
        public byte SpawnPoint { get; set; }

        /// <summary>
        /// 角色组队ID，空表示未组队
        /// </summary>
        public int? PartyId { get; set; }

        /// <summary>
        /// 角色剩余能力点
        /// </summary>
        public short RemainingAbilityPoint { get; set; }

        /// <summary>
        /// 角色剩余技能点
        /// </summary>
        public short RemainingSkillPoint { get; set; }

        /// <summary>
        /// 角色是否已经结婚
        /// </summary>
        public bool IsMarried { get; set; }

        /// <summary>
        /// 自动红药 TODO: 为啥是int，表示物品ID？
        /// </summary>
        public int AutomaticHealthPotion { get; set; }

        /// <summary>
        /// 自动蓝药
        /// </summary>
        public int AutomaticManaPotion { get; set; }

        /// <summary>
        /// 装备栏格子数
        /// </summary>
        public byte EquipmentSlotNumber { get; set; }

        /// <summary>
        /// 消耗栏格子数
        /// </summary>
        public byte UsableSlotNumber { get; set; }

        /// <summary>
        /// 其他栏格子数
        /// </summary>
        public byte EtcSlotNumber { get; set; }

        /// <summary>
        /// TODO: 大概是现金物品栏格子数
        /// </summary>
        public byte CashSlotNumber { get; set; }

        /// <summary>
        /// 角色背包中所有物品
        /// </summary>
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
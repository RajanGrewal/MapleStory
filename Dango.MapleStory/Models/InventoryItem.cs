using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using Dango.MapleStory.Enums;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 背包物品模型 TODO: 到底是啥
    /// </summary>
    [Table("InventoryItems")]
    public class InventoryItem
    {
        /// <summary>
        /// 物品独一无二的ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 角色->物品一对多链接
        /// </summary>
        [Required]
        public Character Character { get; set; }
        
        /// <summary>
        /// 保存角色ID的外链
        /// </summary>
        [ForeignKey(nameof(Character))]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterId { get; set; }

        /// <summary>
        /// TODO: 不知道是啥。。
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 所处背包类型
        /// </summary>
        public InventoryType InventoryType { get; set; }

        /// <summary>
        /// TODO: 不知道是啥
        /// </summary>
        public byte Position { get; set; }

        /// <summary>
        /// 物品数量
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// TODO: What?
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 过期时间点
        /// </summary>
        public DateTimeOffset? ExpireDate { get; set; }

        /// <summary>
        /// TODO: 这又是啥。。
        /// </summary>
        public int UniqueId { get; set; }

        /// <summary>
        /// TODO: 不懂
        /// </summary>
        public byte PetSlot { get; set; }

    }
}
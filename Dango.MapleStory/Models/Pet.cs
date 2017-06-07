using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 宠物模型
    /// </summary>
    [Table("Pets")]
    public class Pet
    {
        /// <summary>
        /// 宠物ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 宠物名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 宠物等级
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// 亲密度
        /// </summary>
        public short Closeness { get; set; }

        /// <summary>
        /// 满腹度
        /// </summary>
        public byte Fullness { get; set; }

        /// <summary>
        /// TODO: 不知道是啥
        /// </summary>
        public int UniqueId { get; set; }
    }
}

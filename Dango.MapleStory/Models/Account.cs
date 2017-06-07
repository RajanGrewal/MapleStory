using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Enums;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 数据库中账号表对应的模型类
    /// </summary>
    [Table("Accounts")]
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 密码盐
        /// </summary>
        public Guid PasswordSalt { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 用户生日日期
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 用户注册日期
        /// </summary>
        public DateTimeOffset RegisterDate { get; set; }

        /// <summary>
        /// 用户性别，可空
        /// </summary>
        public bool? Gender { get; set; }

        /// <summary>
        /// 账号管理员等级，若为<see cref="Enums.GameManagerLevel.None"/>则非管理员
        /// </summary>
        public GameManagerLevel GameManagerLevel { get; set; }

        /// <summary>
        /// 账号点卡
        /// </summary>
        public int NexonPoint { get; set; }

        /// <summary>
        /// TODO: 大概是枫叶数量？
        /// </summary>
        public int MaplePoint { get; set; }

        /// <summary>
        /// 账号抵用券
        /// </summary>
        public int ShoppingPoint { get; set; }

        /// <summary>
        /// 账号最后登陆IP TODO: 这里设置long真的好吗
        /// </summary>
        public long LastLoginIp { get; set; }

        /// <summary>
        /// 账号最后登陆MAC
        /// </summary>
        public string LastLogInMac { get; set; }

        /// <summary>
        /// 账号登陆状态
        /// </summary>
        public LogInState LogInState { get; set; }

        /// <summary>
        /// 是否被永久封号
        /// </summary>
        public bool IsPermanentBanned { get; set; }

        /// <summary>
        /// 临时封号时长
        /// </summary>
        public DateTime? TempraryBanDate { get; set; }

        /// <summary>
        /// 封号理由
        /// </summary>
        public string BanReason { get; set; }

        /// <summary>
        /// 账号下的所有角色
        /// </summary>
        public virtual ICollection<Character> Characters { get; set; }
    }
}

using Dango.MapleStory.Data;

namespace Dango.MapleStory.Models
{
    /// <summary>
    /// 可移动物体的接口
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 站姿
        /// </summary>
        byte Stance { get; set; }

        /// <summary>
        /// 立足点
        /// </summary>
        short Foothold { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// 是否面向左边
        /// </summary>
        bool FacesLeft { get; }
    }
}

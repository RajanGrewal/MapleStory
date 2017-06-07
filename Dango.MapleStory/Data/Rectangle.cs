using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 自定义矩阵结构
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// 左上点
        /// </summary>
        public Point LeftTop { get; set; }

        /// <summary>
        /// 右下点
        /// </summary>
        public Point RightBottom { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="leftTop">左上点</param>
        /// <param name="rightBottom">右下点</param>
        public Rectangle(Point leftTop, Point rightBottom)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }
    }
}

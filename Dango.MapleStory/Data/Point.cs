using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 自定义点结构
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// 横坐标
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// 纵坐标
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        public Point(short x, short y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        public Point(int x, int y) : this((short) x, (short) y)
        {
        }

        /// <summary>
        /// 到另一个点的距离
        /// </summary>
        /// <param name="point">另一个点</param>
        /// <returns></returns>
        public double DistanceFrom(Point point)
        {
            return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
        }

        /// <summary>
        /// 是否在指定矩形内
        /// </summary>
        /// <param name="rectangle">矩形</param>
        /// <returns></returns>
        public bool IsInRectangle(Rectangle rectangle)
        {
            return X >= rectangle.LeftTop.X &&
                   Y >= rectangle.LeftTop.Y &&
                   X <= rectangle.RightBottom.X &&
                   Y <= rectangle.RightBottom.Y;
        }

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);
    }
}
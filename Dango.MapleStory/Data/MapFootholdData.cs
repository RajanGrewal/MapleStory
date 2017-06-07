namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 地图立足处数据，立足处基本可以当作是一条线段
    /// </summary>
    public sealed class MapFootholdData : Data
    {
        /// <summary>
        /// 立足处ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// 立足处的一个顶点
        /// </summary>
        public Point Point1 { get; set; }

        /// <summary>
        /// 立足处的一个顶点
        /// </summary>
        public Point Point2 { get; set; }

        /// <summary>
        /// 下一个立足处ID
        /// </summary>
        public short NextId { get; set; }

        /// <summary>
        /// 上一个立足处ID
        /// </summary>
        public short PreviousId { get; set; }


        public override void Load(DataReader reader)
        {

            Id = reader.ReadInt16();
            Point1 = reader.ReadPoint();
            Point2 = reader.ReadPoint();
            NextId = reader.ReadInt16();
            PreviousId = reader.ReadInt16();
        }

        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(Point1);
            writer.Write(Point2);
            writer.Write(NextId);
            writer.Write(PreviousId);
        }
    }
}

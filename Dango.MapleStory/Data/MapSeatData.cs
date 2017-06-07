namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 地图座椅数据
    /// </summary>
    public sealed class MapSeatData : Data
    {
        /// <summary>
        /// 座椅ID
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// 座椅位置
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// 读取座椅数据
        /// </summary>
        /// <param name="reader"></param>
        public override void Load(DataReader reader)
        {
            Id = reader.ReadInt16();
            Position = reader.ReadPoint();
        }

        /// <summary>
        /// 保存座椅数据
        /// </summary>
        /// <param name="writer"></param>
        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(Position);
        }
    }
}
namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 传送门数据类
    /// </summary>
    public sealed class MapPortalData : Data
    {
        /// <summary>
        /// 传送门ID
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// 传送门标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 目标地图 TODO: 大概是ID，为啥变成int了
        /// </summary>
        public int DestinationMapId { get; set; }

        /// <summary>
        /// 目标地图标签 TODO: 还是传送门标签？
        /// </summary>
        public string DestinationLabel { get; set; }

        /// <summary>
        /// TODO: 脚本？
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public Point Position { get; set; }

        public override void Load(DataReader reader)
        {
            Id = reader.ReadByte();
            Label = reader.ReadString();
            DestinationMapId = reader.ReadInt32();
            DestinationLabel = reader.ReadString();
            Script = reader.ReadString();
            Position = reader.ReadPoint();
        }

        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(Label);
            writer.Write(DestinationMapId);
            writer.Write(DestinationLabel);
            writer.Write(Script);
            writer.Write(Position);
        }
    }
}

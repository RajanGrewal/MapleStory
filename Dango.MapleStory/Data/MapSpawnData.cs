namespace Dango.MapleStory.Data
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class MapSpawnData : Data
    {
        /// <summary>
        /// TODO:
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public short FootholdId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool Flip { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool Hide { get; set; }

        public override void Load(DataReader reader)
        {
            Id = reader.ReadInt32();
            FootholdId = reader.ReadInt16();
            Position = reader.ReadPoint();
            Flip = reader.ReadBoolean();
            Hide = reader.ReadBoolean();
        }

        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(FootholdId);
            writer.Write(Position);
            writer.Write(Flip);
            writer.Write(Hide);
        }
    }
}
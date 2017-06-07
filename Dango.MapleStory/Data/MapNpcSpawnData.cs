namespace Dango.MapleStory.Data
{
    /// <summary>
    /// TODO: NPC数据
    /// </summary>
    public sealed class MapNpcSpawnData : MapSpawnData
    {
        public short MinimumClickX { get; set; }

        public short MaximumClickX { get; set; }

        public override void Load(DataReader reader)
        {

            base.Load(reader);

            MinimumClickX = reader.ReadInt16();
            MaximumClickX = reader.ReadInt16();
        }

        public override void Save(DataWriter writer)
        {
            base.Save(writer);
            
            writer.Write(MinimumClickX);
            writer.Write(MaximumClickX);
        }
    }
}
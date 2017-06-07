namespace Dango.MapleStory.Data
{
    /// <summary>
    /// TODO:
    /// </summary>
    public sealed class MapMobSpawnData : MapSpawnData
    {
        public int RespawnTime { get; set; }

        public override void Load(DataReader reader)
        {
            base.Load(reader);

            RespawnTime = reader.ReadInt32();
        }

        public override void Save(DataWriter writer)
        {
            base.Save(writer);

            writer.Write(RespawnTime);
        }
    }
}
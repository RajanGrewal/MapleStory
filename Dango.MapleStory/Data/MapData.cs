using System.Collections.Generic;

namespace Dango.MapleStory.Data
{
    public sealed class MapData : Data
    {
        /// <summary>
        /// TODO: 地图ID?
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 返回地图ID
        /// </summary>
        public int ReturnMapId { get; set; }

        /// <summary>
        /// 强制返回地图ID
        /// </summary>
        public int ForcedReturnMapId { get; set; }

        /// <summary>
        /// 立足处数据列表
        /// </summary>
        public List<MapFootholdData> Footholds { get; set; }

        /// <summary>
        /// 怪物刷新数据列表
        /// </summary>
        public List<MapMobSpawnData> Mobs { get; set; }

        /// <summary>
        /// NPC TODO:
        /// </summary>
        public List<MapNpcSpawnData> Npcs { get; set; }

        /// <summary>
        /// 传送门数据列表
        /// </summary>
        public List<MapPortalData> Portals { get; set; }

        /// <summary>
        /// 反应器数据列表
        /// </summary>
        public List<MapReactorData> Reactors { get; set; }

        /// <summary>
        /// 座椅数据列表
        /// </summary>
        public List<MapSeatData> Seats { get; set; }

        public override void Load(DataReader reader)
        {
            Id = reader.ReadInt32();
            ReturnMapId = reader.ReadInt32();
            ForcedReturnMapId = reader.ReadInt32();
            Footholds = reader.ReadList<MapFootholdData>();
            Mobs = reader.ReadList<MapMobSpawnData>();
            Npcs = reader.ReadList<MapNpcSpawnData>();
            Portals = reader.ReadList<MapPortalData>();
            Reactors = reader.ReadList<MapReactorData>();
            Seats = reader.ReadList<MapSeatData>();
        }

        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(ReturnMapId);
            writer.Write(ForcedReturnMapId);
            writer.Write(Footholds);
            writer.Write(Mobs);
            writer.Write(Npcs);
            writer.Write(Portals);
            writer.Write(Reactors);
            writer.Write(Seats);
        }
        
    }
}
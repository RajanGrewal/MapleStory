using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Models.MapModels
{
    public sealed class MapModel
    {
        /// <summary>
        /// TODO: 大概是地图ID?
        /// </summary>
        public int Id { get; private set; }

        public MapData Data { get; private set; }
    }
}

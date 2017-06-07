using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Dango.MapleStory.Models;
using Dango.MapleStory.Settings;

namespace Dango.MapleStory.Database
{
    /// <summary>
    /// 应用整体的数据库模型
    /// </summary>
    public sealed class MapleDbContext : DbContext
    {
        public MapleDbContext() : base(ServerSettings.ServerName) { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
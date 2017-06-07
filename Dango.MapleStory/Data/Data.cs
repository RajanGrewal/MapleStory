
namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 数据接口类
    /// </summary>
    public abstract class Data
    {
        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="reader"></param>
        public abstract void Load(DataReader reader);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="writer"></param>
        public abstract void Save(DataWriter writer);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Core.IO;
using Dango.MapleStory.Network;

namespace Dango.MapleStory.Core.Network
{
    /// <summary>
    /// 对客户端封包进行读取处理操作的代理
    /// </summary>
    /// <param name="client">客户端</param>
    /// <param name="reader">读取器</param>
    public delegate void PacketHandler(MapleClient client, ClientPacketReader reader);

    /// <summary>
    /// 对客户端封包进行处理的类 TODO: 可以用字典实现
    /// </summary>
    public sealed class PacketProcesser
    {
        private readonly PacketHandler[] _handlers;

        /// <summary>
        /// 处理器标签
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// 处理器中包含的处理方法的数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 处理器的构造方法
        /// </summary>
        /// <param name="label">标签</param>
        public PacketProcesser(string label)
        {
            Label = label;
            _handlers = new PacketHandler[0xFFFF];
        }

        /// <summary>
        /// 根据操作码索引处理方法
        /// </summary>
        /// <param name="operationCode"></param>
        /// <returns></returns>
        public PacketHandler this[ReceiveOperationCodes operationCode] => _handlers[(short) operationCode];

        /// <summary>
        /// 对特定操作码添加新的处理方法
        /// </summary>
        /// <param name="operationCode"></param>
        /// <param name="handler"></param>
        public void Add(ReceiveOperationCodes operationCode, PacketHandler handler)
        {
            var code = (short) operationCode;
            if (_handlers[code] != null)
                throw new InvalidOperationException($"Operation code {operationCode} has been registered!");
            _handlers[code] = handler;
            Count++;
        }
    }
}
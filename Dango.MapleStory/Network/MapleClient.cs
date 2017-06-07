using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Dango.MapleStory.Core.IO;
using Dango.MapleStory.Core.Network;
using Dango.MapleStory.Database.Models;
using DataReceivedEventArgs = Dango.MapleStory.Core.Network.DataReceivedEventArgs;

namespace Dango.MapleStory.Network
{
    /// <summary>
    /// 客户端会话
    /// </summary>
    public sealed class MapleClient : Client
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public Account Acount { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// 最后登陆的用户名 TODO: 这用来干嘛
        /// </summary>
        public string LastUserName { get; set; }

        /// <summary>
        /// 最后使用的密码 TODO: 用来干嘛
        /// </summary>
        public string LastPassword { get; set; }

        /// <summary>
        /// 世界ID
        /// </summary>
        public byte WorldId { get; set; }

        /// <summary>
        /// 频道号
        /// </summary>
        public byte Channel { get; set; }

        /// <summary>
        /// 针对每一个操作码进行处理的方法集合
        /// </summary>
        private PacketProcesser _processer;

        public MapleClient(TcpClient client, PacketProcesser processer) : base(client)
        {
            _processer = processer;
            Disposing += MyOnDisposing;
            DataReceived += MyOnDataReceived;
        }

        private void MyOnDataReceived(object sender, DataReceivedEventArgs e)
        {
            using (var reader = new ClientPacketReader(e.ReceivedData))
            {
                var handler = _processer[reader.OperationCode];

                if (handler != null)
                    handler(this, reader);
                else
                    Debug.Write($"[{_processer.Label}]Unhandled packet from {ClientIp} : {reader}");
            }
        }

        private void MyOnDisposing(object sender, EventArgs e)
        {
            if (Character != null)
            {
                throw NotImplementedException();  //TODO
            }
        }
    }
}

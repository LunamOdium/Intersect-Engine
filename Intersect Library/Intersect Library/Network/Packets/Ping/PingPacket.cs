﻿using Intersect.Memory;

namespace Intersect.Network.Packets.Ping
{
    public class PingPacket : AbstractPacket
    {
        public bool RequestPong { get; set; }
    
        public PingPacket(IConnection connection)
            : base(connection, PacketGroups.Ping)
        {
            RequestPong = false;
        }

        public override bool Read(ref IBuffer buffer)
        {
            if (!base.Read(ref buffer)) return false;

            RequestPong = buffer.ReadBoolean();

            return true;
        }

        public override bool Write(ref IBuffer buffer)
        {
            if (!base.Write(ref buffer)) return false;

            buffer.Write(RequestPong);

            return true;
        }
    }
}
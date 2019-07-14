using System;
using System.Collections.Generic;

namespace PubNubAPI
{
    internal class ExceptionHandlerEventArgs : EventArgs
    {
        private List<ChannelEntity> channelEntities;
        private bool reconnectMaxTried;
        private PNOperationType responseType;

        internal PNOperationType ResponseType { get => responseType; set => responseType = value; }
        internal bool ReconnectMaxTried { get => reconnectMaxTried; set => reconnectMaxTried = value; }
        internal List<ChannelEntity> ChannelEntities { get => channelEntities; set => channelEntities = value; }
    }
}
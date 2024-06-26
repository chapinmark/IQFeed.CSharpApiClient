﻿using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Level2
{
    public interface ILevel2Client : IStreamingClient, ILevel2Event, ILevel2Snapshot
    {
        void ReqWatch(string symbol);
        void ReqWatchMarketByPrice(string symbol);
        void ReqWatchMarketByOrder(string symbol);
        void ReqMarketMakerNameById(string mmid);
        void ReqServerConnect();
        void ReqServerDisconnect();
    }
}
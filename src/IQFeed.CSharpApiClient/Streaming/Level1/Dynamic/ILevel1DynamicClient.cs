using IQFeed.CSharpApiClient.Common;
using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Level1.Dynamic
{
    public interface ILevel1DynamicClient : IStreamingClient, ILevel1DynamicEvent, ILevel1DynamicSnapshot
    {
        void ReqWatch(string symbol);
        void ReqTradesOnlyWatch(string symbol);
        void ReqForcedRefresh(string symbol);
        void ReqTimestamp();
        void ReqTimestamps(bool on);
        void ReqRegionalWatch(string symbol);
        void ReqRegionalUnwatch(string symbol);
        void ReqNews(bool on);
        void ReqStats();
        void ReqFundamentalFieldnames();
        void ReqUpdateFieldnames();
        void ReqCurrentUpdateFieldNames();        
        void SetLogLevels(params LoggingLevel[] logLevels);
        void ReqServerConnect();
        void ReqServerDisconnect();
    }
}
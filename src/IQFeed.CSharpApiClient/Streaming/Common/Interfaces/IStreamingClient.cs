using IQFeed.CSharpApiClient.Common.Interfaces;
namespace IQFeed.CSharpApiClient.Streaming.Common.Interfaces
{
    public interface IStreamingClient : IClient, IStreamingEvent
    {
        void SetClientName(string clientName);
        void ReqWatchList();
        void ReqUnwatch(string symbol);
        void ReqUnwatchAll();
    }
}
using IQFeed.CSharpApiClient.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Common.Interfaces
{
    public interface IStreamingClient : IClient
    {
        void SetClientName(string clientName);
    }
}
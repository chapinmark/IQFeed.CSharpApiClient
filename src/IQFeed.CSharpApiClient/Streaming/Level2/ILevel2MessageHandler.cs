using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Level2
{
    public interface ILevel2MessageHandler : ILevel2Event, IStreamingEvent
    {
        void ProcessMessages(byte[] messageBytes, int count);
    }
}
using System;
using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;
using IQFeed.CSharpApiClient.Streaming.Common.Messages;
using IQFeed.CSharpApiClient.Streaming.Derivative.Messages;

namespace IQFeed.CSharpApiClient.Streaming.Derivative
{
    public interface IDerivativeEvent : IStreamingEvent
    {
        event Action<IntervalBarMessage> IntervalBar;
    }
}
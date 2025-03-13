using System;
using IQFeed.CSharpApiClient.Streaming.Common.Messages;

namespace IQFeed.CSharpApiClient.Streaming.Common.Interfaces
{
    public interface IStreamingEvent
    {   event Action<SystemMessage> System;
        event Action<SymbolNotFoundMessage> SymbolNotFound;
        event Action<ErrorMessage> Error;
    }
}
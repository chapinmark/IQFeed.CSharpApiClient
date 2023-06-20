using System;
using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Derivative
{
    public interface IDerivativeClient: IStreamingClient, IDerivativeEvent
    {

        void ReqBarWatch(string symbol, int interval, DateTime? beginDate = null, int? maxDaysOfDatapoints = null, int? maxDatapoints = null, TimeSpan? beginFilterTime = null, 
            TimeSpan? endFilterTime = null, string requestId = null, DerivativeIntervalType? intervalType = null, int? updateInterval = null);

        void ReqBarUnwatch(string symbol, string requestId);
    }
}
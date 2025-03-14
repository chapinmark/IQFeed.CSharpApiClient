﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IQFeed.CSharpApiClient.Common;
using IQFeed.CSharpApiClient.Lookup.Common;
using IQFeed.CSharpApiClient.Lookup.MarketSummary.Messages;
using IQFeed.CSharpApiClient.Lookup.Symbol;

namespace IQFeed.CSharpApiClient.Lookup.MarketSummary.Facades
{
    public class MarketSummaryFacade : BaseLookupFacade, IMarketSummaryFacade<IEnumerable<MarketSummaryMessage>, IEnumerable<MarketSummaryMessage>, IEnumerable<MarketSummaryMessage>>
    {
        private readonly MarketSummaryRequestFormatter _marketSummaryRequestFormatter;

        public MarketSummaryFacade(
            MarketSummaryRequestFormatter marketSummaryRequestFormatter,
            LookupDispatcher lookupDispatcher,
            LookupRateLimiter lookupRateLimiter,
            ExceptionFactory exceptionFactory,
            MarketSummaryFileFacade marketSummaryFileFacade,
            TimeSpan timeout) : base(lookupDispatcher, lookupRateLimiter, exceptionFactory, timeout)
        {
            _marketSummaryRequestFormatter = marketSummaryRequestFormatter;
            File = marketSummaryFileFacade;
        }

        public MarketSummaryFileFacade File { get; }

        public Task<IEnumerable<MarketSummaryMessage>> GetEndOfDaySummaryAsync(SecurityType securityType, int listedMarketGroupId, DateTime date, string requestId = null)
        {
            var request = _marketSummaryRequestFormatter.ReqEndOfDaySummary(securityType, listedMarketGroupId, date, requestId);
            var marketSummaryHandler = new MarketSummaryHandler();
            return string.IsNullOrEmpty(requestId) ? GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessages) : GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessagesWithRequestId);
        }

        public Task<IEnumerable<MarketSummaryMessage>> GetEndOfDayFundamentalSummaryAsync(SecurityType securityType, int listedMarketGroupId, DateTime date, string requestId = null)
        {
            var request = _marketSummaryRequestFormatter.ReqFundamentalSummary(securityType, listedMarketGroupId, date, requestId);
            var marketSummaryHandler = new MarketSummaryHandler();
            return string.IsNullOrEmpty(requestId) ? GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessages) : GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessagesWithRequestId);
        }

        public Task<IEnumerable<MarketSummaryMessage>> Get5MinuteSnapshotSummaryAsync(SecurityType securityType, int listedMarketGroupId, string requestId = null)
        {
            var request = _marketSummaryRequestFormatter.Req5MinuteSnapshotSummary(securityType, listedMarketGroupId, requestId);
            var marketSummaryHandler = new MarketSummaryHandler();
            return string.IsNullOrEmpty(requestId) ? GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessages) : GetMessagesAsync(request, marketSummaryHandler.GetMarketSummaryMessagesWithRequestId);
        }
    }
}
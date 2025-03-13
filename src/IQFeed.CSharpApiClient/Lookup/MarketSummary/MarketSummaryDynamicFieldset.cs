namespace IQFeed.CSharpApiClient.Lookup.MarketSummary
{
    public enum MarketSummaryDynamicFieldset
    {
        RequestId,
        LM,         // Protocol 6.2 DataId Constant 'LM'
        Symbol,
        Exchange,   // ExchangeId
        Type,       // SecurityType
        Last,
        TradeSize,
        TradedMarket,
        TradeDate,
        TradeTime,
        Open,
        High,
        Low,
        Close,
        Bid,
        BidMarket,
        BidSize,
        Ask,
        AskMarket,
        AskSize,
        Volume,
        PDayVolume,
        UpVolume,
        DownVolume,
        NeutralVolume,
        TradeCount,
        UpTrades,
        DownTrades,
        NeutralTrades,
        VWAP,
        MutualDiv,
        SevenDayYield,
        OpenInterest,
        Settlement,
        SettlementDate,
        ExpirationDate,
        Strike
    }
}

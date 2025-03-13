using System;
using IQFeed.CSharpApiClient.Streaming.Common.Messages;
using IQFeed.CSharpApiClient.Streaming.Level2.Messages;

namespace IQFeed.CSharpApiClient.Streaming.Level2
{
    public interface ILevel2Event
    {
        event Action<UpdateSummaryMessage> Summary;
        event Action<UpdateSummaryMessage> Update;
        event Action<MarketMakerNameMessage> Query;
        event Action<TimestampMessage> Timestamp;

        //protocol 6.2 events
        event Action<OrderAddUpdateSummaryMessage> OrderAdd;
        event Action<OrderAddUpdateSummaryMessage> OrderUpdate;
        event Action<OrderAddUpdateSummaryMessage> OrderSummary;
        event Action<OrderDeleteMessage> OrderDelete;
        event Action<PriceLevelOrderMessage> PriceLevelOrder;
        event Action<PriceLevelUpdateSummaryMessage> PriceLevelSummary;
        event Action<PriceLevelUpdateSummaryMessage> PriceLevelUpdate;
        event Action<PriceLevelDeleteMessage> PriceLevelDelete;
    }
}
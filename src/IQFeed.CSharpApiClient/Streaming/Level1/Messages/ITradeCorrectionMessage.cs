﻿using System;

namespace IQFeed.CSharpApiClient.Streaming.Level1.Messages
{
    public interface ITradeCorrectionMessage
    {
        string Symbol { get; }
        string CorrectionType { get; }
        DateTime TradeDate { get;  }
        TimeSpan TradeTime { get; }
        double TradePrice { get; }
        int TradeSize { get;  }
        int TickId { get;  }
        string TradeConditions { get; }
        int TradeMarketCentre { get; }

        DateTime TradeDateTime { get; }
    }
}

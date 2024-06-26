﻿using System;
using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;
using IQFeed.CSharpApiClient.Streaming.Common.Messages;
using IQFeed.CSharpApiClient.Streaming.Level1.Messages;

namespace IQFeed.CSharpApiClient.Streaming.Level1
{
    public interface ILevel1EventCommon : IStreamingEvent
    {
        event Action<FundamentalMessage> Fundamental;
        event Action<TimestampMessage> Timestamp;
        event Action<RegionalUpdateMessage> Regional;
        event Action<NewsMessage> News;
    }
}
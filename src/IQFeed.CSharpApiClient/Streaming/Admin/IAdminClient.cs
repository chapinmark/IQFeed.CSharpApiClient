﻿using IQFeed.CSharpApiClient.Streaming.Common.Interfaces;

namespace IQFeed.CSharpApiClient.Streaming.Admin
{
    public interface IAdminClient: IStreamingClient, IAdminMessage
    {
        void RegisterClientApp(string productId, string productVersion);
        void RemoveClientApp(string productId, string productVersion);
        void SetLoginId(string userLoginId);
        void SetPassword(string userPassword);
        void SetSaveLoginInfo(bool on = true);
        void SetAutoconnect(bool on = true);
        void ReqServerConnect();
        void ReqServerDisconnect();
        void SetClientStats(bool on = true);


        // TODO: should be part from another interface
        void SetProtocol(string version);
    }
}
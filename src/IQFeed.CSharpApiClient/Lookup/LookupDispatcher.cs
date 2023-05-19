﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IQFeed.CSharpApiClient.Common.Interfaces;
using IQFeed.CSharpApiClient.Socket;

namespace IQFeed.CSharpApiClient.Lookup
{
    public class LookupDispatcher
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly List<SocketClient> _socketClients;
        private readonly Queue<SocketClient> _socketClientsAvailable;
        private readonly string _protocol;
        private readonly IRequestFormatter _requestFormatter;

        public LookupDispatcher(string host, int port, int bufferSize, string protocol, int numberOfClients, IRequestFormatter requestFormatter)
        {
            _protocol = protocol;
            _semaphoreSlim = new SemaphoreSlim(0, numberOfClients);
            _socketClients = new List<SocketClient>(GetSocketClients(host, port, bufferSize, numberOfClients));
            _socketClientsAvailable = new Queue<SocketClient>();
            _requestFormatter = requestFormatter;
        }

        private IEnumerable<SocketClient> GetSocketClients(string host, int port, int bufferSize, int numberOfClients)
        {
            for (var i = 0; i < numberOfClients; i++)
            {
                var socketClient = new SocketClient(host, port, bufferSize);
                socketClient.MessageReceived += OnMessageReceived;
                socketClient.Connected += OnConnected;
                yield return socketClient;
            }
        }

        public void ConnectAll()
        {
            foreach (var socketClient in _socketClients)
            {
                socketClient.Connect();
            }
        }

        public void DisconnectAll()
        {
            foreach (var socketClient in _socketClients)
            {
                socketClient.Disconnect();
            }
        }

        public async Task<SocketClient> TakeAsync()
        {
            await _semaphoreSlim.WaitAsync();
            lock (_socketClientsAvailable)
            {
                return _socketClientsAvailable.Dequeue();
            }
        }

        public async Task<SocketClient> TakeAsync(int timeout)
        {
            await _semaphoreSlim.WaitAsync(timeout);
            lock (_socketClientsAvailable)
            {
                return _socketClientsAvailable.Dequeue();
            }
        }

        public void Add(SocketClient socketClient)
        {
            lock (_socketClientsAvailable)
            {
                _socketClientsAvailable.Enqueue(socketClient);
            }
            _semaphoreSlim.Release();
        }

        private void OnConnected(object sender, EventArgs eventArgs)
        {
            var socketClient = (SocketClient)sender;
            socketClient.Send(_requestFormatter.SetProtocol(_protocol));
            socketClient.Connected -= OnConnected;
        }

        private void OnMessageReceived(object sender, SocketMessageEventArgs socketMessageEventArgs)
        {
            var socketClient = (SocketClient)sender;
            socketClient.MessageReceived -= OnMessageReceived;  // TODO: validate the protocol confirmation
            Add(socketClient);
        }
    }
}
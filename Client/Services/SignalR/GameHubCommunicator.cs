﻿using BlazorGameTemplate.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace BlazorGameTemplate.Client.Services.SignalR
{
    public class GameHubCommunicator : HubCommunicator, IGameHub
    {
        public GameHubCommunicator(NavigationManager navigationManager) : base("/GameHub", navigationManager)
        {

        }

        public async Task AddToGroupAsync(string groupId) => await _hubConnection.InvokeAsync("AddToGroupAsync", groupId);

        public async Task RemoveFromGroupAsync(string groupId) => await _hubConnection.InvokeAsync("RemoveFromGroupAsync", groupId);

        public async Task SendGameMessageAsync(string gameId, GameMessage chatMessage) => await _hubConnection.InvokeAsync("SendGameMessageAsync", gameId, chatMessage);

        public async Task UpdateGameAsync(string gameId) => await _hubConnection.InvokeAsync("UpdateGameAsync", gameId);
    }
}
using Microsoft.AspNetCore.SignalR.Client;
using CarMarket.Shared;
using CarMarket.Shared.Models;
using CarMarket.Client.Services.SignalR;

namespace CarMarket.Client.Services.SignalR;

public class ChatHub : IAsyncDisposable
{
    private HubConnection hub;

    public event Action Reconnecting;
    public event Action Reconnected;
    public event Action<ChatMessage> ChatHandler;

    public async Task Subscribe()
    {
        hub = new HubConnectionBuilder()
            .WithUrl($"{ChatHubRoutes.ServerUrl}{ChatHubRoutes.SignalRUrl}")
            .WithAutomaticReconnect(new RetryPolicy())
            .Build();

        hub.Reconnecting += OnReconnecting;
        hub.Reconnected += OnReconnected;


        hub.On<ChatMessage>(ChatHubRoutes.ChatMethod, (chatMessage) =>
        {
            ChatHandler?.Invoke(chatMessage);
        });

        await hub.StartAsync();
    }

    private Task OnReconnecting(Exception exception)
    {
        Reconnecting?.Invoke();
        return Task.CompletedTask;
    }

    private Task OnReconnected(string arg)
    {
        Reconnected?.Invoke();
        return Task.CompletedTask;
    }

    public bool IsConnected => hub?.State == HubConnectionState.Connected;

    public async ValueTask DisposeAsync()
    {
        if (hub != null)
            await hub.DisposeAsync();
    }
}

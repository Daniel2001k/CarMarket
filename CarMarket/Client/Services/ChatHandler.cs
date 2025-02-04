﻿using CarMarket.Shared.Models;
using CarMarket.Client.Services.SignalR;
using MudBlazor;

namespace CarMarket.Client.Services;

public class ChatHandler(ChatHub chatHub, ISnackbar snackbar)
{
    private readonly ISnackbar snackbar = snackbar;
    private readonly ChatHub chatHub = chatHub;

    public List<ChatMessage> Messages { get; private set; } = [];
    public event Action OnChange;

    public bool ConnectionStatus => chatHub?.IsConnected ?? false;
    public void NotifyStateHasChanged() => OnChange?.Invoke();

    public async Task SubscribeChat()
    {
        try
        {
            await DisposeAsync();

            chatHub.Reconnecting += OnReconnecting;
            chatHub.Reconnected += OnReconnected;
            chatHub.ChatHandler += OnMessageGet;

            await chatHub.Subscribe();

            snackbar.Add("Udało połączyć się z chatem", Severity.Success);
        }
        catch (Exception ex)
        {
            snackbar.Add($"Nie udało się połączyć z chatem", Severity.Error);
            Console.WriteLine(ex);
        }
    }
    private void OnReconnected()
    {


    }
    private void OnReconnecting()
    {

    }
    public async Task DisposeAsync()
    {
        chatHub.ChatHandler -= OnMessageGet;

        await chatHub.DisposeAsync();
    }

    private void OnMessageGet(ChatMessage chatMessage)
    {



    }
}

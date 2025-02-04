using Microsoft.AspNetCore.SignalR.Client;

namespace CarMarket.Client.Services.SignalR;

public class RetryPolicy : IRetryPolicy
{
    public TimeSpan? NextRetryDelay(RetryContext retryContext) => TimeSpan.FromSeconds(5);
}

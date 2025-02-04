using CarMarket.Server.SignalRHubs;
using CarMarket.Shared;
using CarMarket.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CarMarket.Server.Controllers;


[ApiController]
[AllowAnonymous]
[Route($"api/{Routes.ChatMessageApi}/[action]")]
public class ChatMessageController(ILogger<ChatMessageController> logger, IHubContext<BroadcastHub> signalR) : ControllerBase
{
    private readonly ILogger<ChatMessageController> _logger = logger;
    private readonly IHubContext<BroadcastHub> _signalR = signalR;

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessage chatMessage)
    {
		try
        {
            await _signalR.Clients.All.SendAsync(ChatHubRoutes.ChatMethod, chatMessage);
            return Ok();
        }
		catch (Exception ex)
        {
            _logger.LogError("Exception - \n\tType: {type}\n\tMessage: {message}", ex.GetType(), ex.Message);
            return BadRequest(ex.Message);
        }
    }
}

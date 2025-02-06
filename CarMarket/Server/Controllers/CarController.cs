using CarMarket.Server.Data;
using CarMarket.Shared;
using CarMarket.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarMarket.Server.Controllers;

[ApiController]
[AllowAnonymous]
[Route($"api/{Routes.CarApi}/[action]")]
public class CarController(ILogger<ChatMessageController> logger) : ControllerBase
{
    private readonly ILogger<ChatMessageController> _logger = logger;
}

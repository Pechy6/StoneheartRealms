using Microsoft.AspNetCore.Mvc;
using StoneheartRealms.Services.DTOs.World;
using StoneheartRealms.Services.Services.World;

namespace StoneheartRealms.Api.Controllers.World;

[ApiController]
[Route("api/GameTime")]
public class GameTimeController(IGameTimeService gameTimeService) : ControllerBase
{
    private readonly IGameTimeService _gameTimeService = gameTimeService;

    // GET
    [HttpGet]
    public async Task<IActionResult> GetCurrentGameTime()
    {
        var gameTime = await _gameTimeService.GetCurrentGameTime();
        return Ok(gameTime);
    }
}
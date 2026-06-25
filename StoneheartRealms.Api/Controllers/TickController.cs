using Microsoft.AspNetCore.Mvc;
using StoneheartRealms.Services.Services.TickSystem;

namespace StoneheartRealms.Api.Controllers;

[ApiController]
[Route("api/tick")]
public class TickController(ITickService tickService) : ControllerBase
{
    private readonly ITickService _tickService = tickService;

    [HttpPost]
    public async Task<IActionResult> Tick()
    {
        await _tickService.Tick();
        return Ok();
    }
}
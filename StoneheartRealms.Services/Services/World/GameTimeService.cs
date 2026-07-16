using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.World.Time;
using StoneheartRealms.Services.DTOs.World;

namespace StoneheartRealms.Services.Services.World;

public class GameTimeService(StoneheartRealmsDbContext context): IGameTimeService
{
    private readonly StoneheartRealmsDbContext _context = context;
    public async Task<GameTimeDto> GetCurrentGameTime()
    {
        var gameTime = await _context.GameTimes.FirstOrDefaultAsync();
        if (gameTime == null)
        {
            throw new InvalidOperationException("GameTime not found.");
        }

        return new GameTimeDto
        {
            Day = gameTime.Day,
            Hour = gameTime.Hour
        };
    }
}
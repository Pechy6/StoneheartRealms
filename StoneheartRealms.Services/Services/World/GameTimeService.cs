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
        var gameTime = await GetGameTime();

        return new GameTimeDto
        {
            Day = gameTime.Day,
            Hour = gameTime.Hour,
            CurrentTimeOfDay = gameTime.CurrentTimeOfDay
        };
    }

    public async Task ChangeGameTime()
    {
        var gameTime = await GetGameTime();
        
        gameTime.Hour++;
        if (gameTime.Hour >= 24)
        {
            gameTime.Hour = 0;
            gameTime.Day++;
        }
    }
    
    private async Task<GameTime> GetGameTime()
    {
        var gameTime = await _context.GameTimes.FirstOrDefaultAsync();
        if (gameTime == null)
        {
            throw new InvalidOperationException("Game time was not found");
        }

        return gameTime;
    }
}
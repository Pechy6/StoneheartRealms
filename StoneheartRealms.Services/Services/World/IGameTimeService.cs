using StoneheartRealms.Data.Entities.World.Time;
using StoneheartRealms.Services.DTOs.World;

namespace StoneheartRealms.Services.Services.World;

public interface IGameTimeService
{
    public Task<GameTimeDto> GetCurrentGameTime();
}
using StoneheartRealms.Data.Entities.World.Time;

namespace StoneheartRealms.Services.DTOs.World;

public class GameTimeDto
{
    public int Day { get; set; }
    public int Hour { get; set; }
    public TimeOfDay CurrentTimeOfDay { get; set; }
}
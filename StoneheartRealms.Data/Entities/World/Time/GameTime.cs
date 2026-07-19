namespace StoneheartRealms.Data.Entities.World.Time;

public enum TimeOfDay
{
    Day,
    Night
}

public class GameTime
{
    public int Id { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }

    public TimeOfDay CurrentTimeOfDay => Hour is >= 6 and < 22
        ? TimeOfDay.Day
        : TimeOfDay.Night;
}
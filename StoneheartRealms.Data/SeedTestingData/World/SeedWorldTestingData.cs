using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.World.Time;

namespace StoneheartRealms.Data.SeedTestingData.World;

public static class SeedWorldTestingData
{
    public static void SeedTime(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<GameTime>().
            HasData(
                new GameTime
                {
                    Id = 1,
                    Day = 1,
                    Hour = 6
                }
            );
    }
}
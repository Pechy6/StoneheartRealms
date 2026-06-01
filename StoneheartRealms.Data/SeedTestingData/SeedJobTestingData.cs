using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.SeedTestingData;

public static class SeedJobTestingData
{
    public static void SeedJob(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<Job>().
            HasData(
                new Job
                {
                    Id = 1,
                    Name = "Farmer",
                    Description = "This is a farmer"
                },
                new Job
                {
                    Id = 2,
                    Name = "Miner",
                    Description = "This is a miner"
                },
                new Job
                {
                    Id = 3,
                    Name = "Cook",
                    Description = "This is a cook"
                }
            );
    }
}
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
                    Description = "This is a farmer",
                },
                new Job
                {
                    Id = 2,
                    Name = "Fisher",
                    Description = "This is a fisher"
                },
                new Job
                {
                    Id = 3,
                    Name = "Hunter",
                    Description = "This is a hunter"
                },
                new Job
                    {
                        Id = 4,
                        Name = "Cook",
                        Description = "This is a cook"
                    },
                new Job
                {
                    Id = 5,
                    Name = "Miner",
                    Description = "This is a miner"
                },
                new Job
                {
                    Id = 6,
                    Name = "Blacksmith",
                    Description = "This is a blacksmith"
                },
                new Job
                {
                    Id = 7,
                    Name = "Woodcutter",
                    Description = "This is a woodcutter"
                },
                new Job
                {
                    Id = 8,
                    Name = "Administrator",
                    Description = "This is a administrator of the colony"
                }
            );
    }
}
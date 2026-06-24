using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Data.SeedTestingData.StorageData;

public static class SeedResourceTypeTestingData
{
    public static void SeedResourceType(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<ResourceType>().
            HasData(
                new ResourceType
                {
                    Id = 1,
                    Name = "Gold"
                },
                new ResourceType
                {
                    Id = 2,
                    Name = "Iron"
                },
                new ResourceType
                {
                    Id = 3,
                    Name = "Stone"
                },
                new ResourceType
                {
                    Id = 4,
                    Name = "Wood"
                },
                new ResourceType
                {
                    Id = 5,
                    Name = "Fish"
                },
                new ResourceType
                {
                    Id = 6,
                    Name = "Meat"
                },
                new ResourceType
                {
                    Id = 7,
                    Name = "Wheat"
                },
                new ResourceType
                {
                    Id = 8,
                    Name = "Food"
                }
            );
    }
}
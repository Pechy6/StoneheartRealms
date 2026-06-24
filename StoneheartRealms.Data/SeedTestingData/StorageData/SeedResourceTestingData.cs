using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Data.SeedTestingData.StorageData;

public static class SeedResourceTestingData
{
    public static void SeedResource(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<Resource>().
            HasData(
                new Resource
                {
                    Id = 1,
                    ResourceTypeId = 1,
                    StorageId = 1,
                    Amount = 500
                },
                new Resource
                {
                    Id = 2,
                    ResourceTypeId = 2,
                    StorageId = 1,
                    Amount = 150
                },
                new Resource
                {
                    Id = 3,
                    ResourceTypeId = 3,
                    StorageId = 1,
                    Amount = 200
                },
                new Resource
                {
                    Id = 4,
                    ResourceTypeId = 4,
                    StorageId = 1,
                    Amount = 300
                },
                new Resource
                {
                    Id = 5,
                    ResourceTypeId = 5,
                    StorageId = 1,
                    Amount = 50
                },
                new Resource
                {
                    Id = 6,
                    ResourceTypeId = 6,
                    StorageId = 1,
                    Amount = 50
                },
                new Resource
                {
                    Id = 7,
                    ResourceTypeId = 7,
                    StorageId = 1,
                    Amount = 100
                },
                new Resource
                {
                    Id = 8,
                    ResourceTypeId = 8,
                    StorageId = 1,
                    Amount = 200
                }
            );
    }
}
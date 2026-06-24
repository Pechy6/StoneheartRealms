using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Data.SeedTestingData.StorageData;

public static class SeedStorageTestingData
{
    public static void SeedStorage(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<Storage>().
            HasData(
                new Storage
                {
                    Id = 1, Name = "Main Storage"
                }
            );
    }
}
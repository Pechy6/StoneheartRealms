using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Data.Entities.Jobs;
using StoneheartRealms.Data.Entities.Storage;
using StoneheartRealms.Data.Entities.World.Time;
using StoneheartRealms.Data.SeedTestingData;
using StoneheartRealms.Data.SeedTestingData.StorageData;
using StoneheartRealms.Data.SeedTestingData.World;

namespace StoneheartRealms.Data.Data;

public class StoneheartRealmsDbContext(DbContextOptions<StoneheartRealmsDbContext> options) : DbContext(options)
{
    public DbSet<Dwarf> Dwarves { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<ResourceType> ResourceTypes { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<GameTime> GameTimes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoneheartRealmsDbContext).Assembly);

        //Dwarf and Job
        SeedDwarfTestingData.SeedDwarf(modelBuilder);
        SeedJobTestingData.SeedJob(modelBuilder);

        //Storage
        SeedStorageTestingData.SeedStorage(modelBuilder);
        SeedResourceTestingData.SeedResource(modelBuilder);
        SeedResourceTypeTestingData.SeedResourceType(modelBuilder);

        //World
        SeedWorldTestingData.SeedTime(modelBuilder);
    }
}
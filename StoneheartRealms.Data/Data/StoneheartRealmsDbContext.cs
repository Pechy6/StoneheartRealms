using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Data.Entities.Jobs;
using StoneheartRealms.Data.SeedTestingData;

namespace StoneheartRealms.Data.Data;

public class StoneheartRealmsDbContext(DbContextOptions<StoneheartRealmsDbContext> options) : DbContext(options)
{
    public DbSet<Dwarf> Dwarves { get; set; }
    public DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoneheartRealmsDbContext).Assembly);
        
        SeedDwarfTestingData.SeedDwarf(modelBuilder);
        SeedJobTestingData.SeedJob(modelBuilder);
    }
}


using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.Data;

public class StoneheartRealmsDbContext(DbContextOptions<StoneheartRealmsDbContext> options) : DbContext(options)
{
    public DbSet<Dwarf> Dwarves { get; set; }
    public DbSet<Job> Jobs { get; set; }
}


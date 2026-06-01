using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Data.SeedTestingData;

public static class SeedDwarfTestingData
{
    public static void SeedDwarf(ModelBuilder modelBuilder)
    {
        modelBuilder.
            Entity<Dwarf>().
            HasData(
                new Dwarf
                {
                    Id = 1,
                    Name = "First Dwarf",
                    Description = "This is the first dwarf",
                    Age = 186,
                    Gender = Gender.Male
                },
                new Dwarf
                {
                    Id = 2,
                    Name = "Second Dwarf",
                    Description = "This is the second dwarf",
                    Age = 186,
                    Gender = Gender.Female
                },
                new Dwarf
                {
                    Id = 3,
                    Name = "Third Dwarf",
                    Description = "This is the third dwarf",
                    Age = 186,
                    Gender = Gender.Male
                },
                new Dwarf
                {
                    Id = 4,
                    Name = "Fourth Dwarf",
                    Description = "This is the fourth dwarf",
                    Age = 186,
                    Gender = Gender.Male
                },
                new Dwarf
                {
                    Id = 5,
                    Name = "Fifth Dwarf",
                    Description = "This is the fifth dwarf",
                    Age = 186,
                    Gender = Gender.Female
                }
            );
    }
}
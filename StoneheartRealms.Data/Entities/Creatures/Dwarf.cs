using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.Entities.Creatures;

public enum Gender
{
    Male,
    Female,
}

public class Dwarf
{
    public int Id { get; init; }

    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; init; }

    public byte Energy { get; set; } = 100;
    public byte Satiety { get; set; } = 100;
    public byte Hydration { get; set; } = 100;

    public Gender Gender { get; init; }
    
    public int? JobId { get; set; }
    public Job? Job { get; set; } 
}
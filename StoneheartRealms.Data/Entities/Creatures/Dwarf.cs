using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.Entities.Creatures;

public enum Gender
{
    Male,
    Female,
}

public class Dwarf
{
    public uint Id { get; set; }

    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; set; }

    public byte Energy { get; set; } = 100;
    public byte Hunger { get; set; } = 100;
    public byte Thirst { get; set; } = 100;

    public Gender Gender { get; set; }
    
    public int JobId { get; set; }
    public Job Job { get; set; } = null!;
}
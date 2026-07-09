using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.Entities.Creatures;

public enum Gender
{
    Male,
    Female,
}

public enum DwarfState
{
    Idle,
    Working,
    Sleeping,
    Traveling,
    Fighting,
    Dead
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
    public DwarfState DwarfState { get; set; } = DwarfState.Idle;
    public Gender Gender { get; init; }

    public int? JobId { get; set; }
    public Job? Job { get; set; }
}
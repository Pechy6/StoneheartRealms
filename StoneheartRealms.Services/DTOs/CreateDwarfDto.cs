using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.DTOs;

public class CreateDwarfDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; set; }
    public Gender Gender { get; set; }
}
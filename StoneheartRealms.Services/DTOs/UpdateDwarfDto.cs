using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.DTOs;

public class UpdateDwarfDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Gender Gender { get; set; }
}
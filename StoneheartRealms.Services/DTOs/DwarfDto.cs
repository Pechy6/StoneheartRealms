using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.DTOs;

public class DwarfDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Age { get; set; }
    
    public Gender Gender { get; set; }
    
    public int Energy { get; set; }
    public int Hunger { get; set; }
    public int Thirst { get; set; }
    
    public int? JobId { get; set; }
    public string? JobName { get; set; }
}
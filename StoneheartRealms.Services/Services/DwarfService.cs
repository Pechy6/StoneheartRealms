using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.DTOs;
using StoneheartRealms.Services.Interfaces;

namespace StoneheartRealms.Services.Services;

public class DwarfService(StoneheartRealmsDbContext context) : IDwarfService
{
    private readonly StoneheartRealmsDbContext _context = context;

    public async Task<DwarfDto?> GetDwarf(int id)
    {
        var dwarf = await _context.Dwarves.FindAsync(id);
        if (dwarf == null)
            return null;
        
        var dwarfDto = new DwarfDto
        {
            Id = dwarf.Id,
            Name = dwarf.Name,
            Description = dwarf.Description,
            Age = dwarf.Age,
            Gender = dwarf.Gender,
            Energy = dwarf.Energy,
            Hunger = dwarf.Hunger,
            Thirst = dwarf.Thirst
        };
        return dwarfDto;
    }
}
using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Creatures;
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

    public async Task<IEnumerable<DwarfDto>> GetDwarves()
    {
        var dwarves = await _context.Dwarves.ToListAsync();

        return dwarves.Select(dwarf => new DwarfDto
        {
            Id = dwarf.Id,
            Name = dwarf.Name,
            Description = dwarf.Description,
            Age = dwarf.Age,
            Gender = dwarf.Gender,
            Energy = dwarf.Energy,
            Hunger = dwarf.Hunger,
            Thirst = dwarf.Thirst
        });
    }

    public async Task<DwarfDto> CreateDwarf(CreateDwarfDto dwarf)
    {
        var newDwarf = new Dwarf
        {
            Name = dwarf.Name,
            Description = dwarf.Description,
            Age = dwarf.Age,
            Gender = dwarf.Gender
        };

        _context.Dwarves.Add(newDwarf);

        await _context.SaveChangesAsync();
        return new DwarfDto
        {
            Id = newDwarf.Id,
            Name = newDwarf.Name,
            Description = newDwarf.Description,
            Age = newDwarf.Age,
            Gender = newDwarf.Gender
        };
    }

    public async Task<DwarfDto?> UpdateDwarf(int id, UpdateDwarfDto dwarf)
    {
        var updateDwarf = await _context.
            Dwarves.
            Where(d => d.Id == id).
            FirstOrDefaultAsync();

        if (updateDwarf == null)
            return null;

        updateDwarf.Name = dwarf.Name;
        updateDwarf.Description = dwarf.Description;

        await _context.SaveChangesAsync();
        return new DwarfDto
        {
            Id = updateDwarf.Id,
            Name = updateDwarf.Name,
            Description = updateDwarf.Description
        };
    }

    public async Task<bool> DeleteDwarf(int id)
    {
        var dwarfToDelete = await _context.Dwarves.FindAsync(id);

        if (dwarfToDelete == null)
        {
            return false;
        }
        
        _context.Dwarves.Remove(dwarfToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
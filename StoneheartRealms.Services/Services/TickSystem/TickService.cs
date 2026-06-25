using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.Needs;

namespace StoneheartRealms.Services.Services.TickSystem;

public class TickService(INeedDecayService needDecayService, StoneheartRealmsDbContext context): ITickService
{
    private readonly INeedDecayService _needDecayService = needDecayService;
    private readonly StoneheartRealmsDbContext _context = context;
    
    public async Task Tick()
    {
        var dwarves = await _context.Dwarves.ToListAsync();
        foreach (var dwarf in dwarves)
        {
            _needDecayService.ReduceHydration(dwarf);
            _needDecayService.ReduceEnergy(dwarf);
            _needDecayService.ReduceSatiety(dwarf);
        }
        
        await _context.SaveChangesAsync();
    }
}
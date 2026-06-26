using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.Needs;
using StoneheartRealms.Services.Services.Production;
using StoneheartRealms.Services.Services.StorageManager;

namespace StoneheartRealms.Services.Services.TickSystem;

public class TickService(INeedDecayService needDecayService, IJobProduction jobProduction, StoneheartRealmsDbContext context): ITickService
{
    private readonly INeedDecayService _needDecayService = needDecayService;
    private readonly StoneheartRealmsDbContext _context = context;
    private readonly IJobProduction _jobProduction = jobProduction;
    
    public async Task Tick()
    {
        var dwarves = await _context.Dwarves.Include(d => d.Job).ToListAsync();
        foreach (var dwarf in dwarves)
        {
            _needDecayService.ReduceHydration(dwarf);
            _needDecayService.ReduceEnergy(dwarf);
            _needDecayService.ReduceSatiety(dwarf);
            await _jobProduction.Produce(dwarf);
        }
        
        await _context.SaveChangesAsync();
    }
}
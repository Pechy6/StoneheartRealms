using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.Services.Needs;
using StoneheartRealms.Services.Services.Production;
using IResourceService = StoneheartRealms.Services.Services.Resources.IResourceService;

namespace StoneheartRealms.Services.Services.TickSystem;

public class TickService(
    INeedDecayService needDecayService,
    IJobProduction jobProduction,
    INeedRecoveryService needRecoveryService,
    StoneheartRealmsDbContext context
) : ITickService
{
    private readonly INeedDecayService _needDecayService = needDecayService;
    private readonly StoneheartRealmsDbContext _context = context;
    private readonly IJobProduction _jobProduction = jobProduction;
    private readonly INeedRecoveryService _needRecoveryService = needRecoveryService;

    public async Task Tick()
    {
        var dwarves = await _context.
            Dwarves.
            Include(d => d.Job).
            ToListAsync();

        foreach (var dwarf in dwarves)
        {
            _needDecayService.ReduceHydration(dwarf);
            _needDecayService.ReduceEnergy(dwarf);
            _needDecayService.ReduceSatiety(dwarf);
            
            await _needRecoveryService.RecoverSatiety(dwarf);
            await _needRecoveryService.RecoverHydration(dwarf);

            await _jobProduction.Produce(dwarf);
        }

        await _context.SaveChangesAsync();
    }
}
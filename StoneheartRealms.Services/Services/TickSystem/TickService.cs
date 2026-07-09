using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.Services.Needs;
using StoneheartRealms.Services.Services.Production;
using StoneheartRealms.Services.Services.States.Dwarves;
using IResourceService = StoneheartRealms.Services.Services.Resources.IResourceService;

namespace StoneheartRealms.Services.Services.TickSystem;

public class TickService(
    INeedDecayService needDecayService,
    IJobProduction jobProduction,
    INeedRecoveryService needRecoveryService,
    IDwarfStateService dwarfStateService,
    StoneheartRealmsDbContext context
) : ITickService
{
    private readonly INeedDecayService _needDecayService = needDecayService;
    private readonly StoneheartRealmsDbContext _context = context;
    private readonly IJobProduction _jobProduction = jobProduction;
    private readonly INeedRecoveryService _needRecoveryService = needRecoveryService;
    private readonly IDwarfStateService _dwarfStateService = dwarfStateService;

    public async Task Tick()
    {
        var dwarves = await _context.
            Dwarves.
            Include(d => d.Job).
            ToListAsync();

        foreach (var dwarf in dwarves)
        {
            _dwarfStateService.SetDwarfState(dwarf);
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
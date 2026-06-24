using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.Needs;

namespace StoneheartRealms.Services.Services.TickSystem;

public class TickServiceService(INeedDecayService needDecayService, List<Dwarf> dwarves): ITickService
{
    private readonly INeedDecayService _needDecayService = needDecayService;
    private readonly List<Dwarf> _dwarves = dwarves;
    
    public void Tick()
    {
        foreach (var dwarf in _dwarves)
        {
            _needDecayService.ReduceHydration(dwarf);
            _needDecayService.ReduceEnergy(dwarf);
            _needDecayService.ReduceSatiety(dwarf);
        }
    }
}
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedDecayService : INeedDecayService
{
    private readonly byte _energyDecayRate = 6;
    private readonly byte _satietyDecayRate = 5;
    private readonly byte _hydrationDecayRate = 8;

    public void ReduceEnergy(Dwarf dwarf)
    {
        if (dwarf.Energy <= 0)
            dwarf.Energy = 0;
        
        dwarf.Energy -= _energyDecayRate;
    }

    public void ReduceSatiety(Dwarf dwarf)
    {
        if (dwarf.Hunger <= 0)
            dwarf.Hunger = 0;

        dwarf.Hunger -= _satietyDecayRate;
    }

    public void ReduceHydration(Dwarf dwarf)
    {
        if (dwarf.Thirst <= 0)
            dwarf.Thirst = 0;
        
        dwarf.Thirst -= _hydrationDecayRate;
    }
}
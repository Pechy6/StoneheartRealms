using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedDecayService : INeedDecayService
{
    private readonly byte _energyDecayRate = 6;

    private readonly byte _satietyDecayRate = 5;
    private readonly byte _sleepingSatietyDecayRate = 2;

    private readonly byte _hydrationDecayRate = 8;
    private readonly byte _sleepingHydrationDecayRate = 2;

    public void ReduceEnergy(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping or DwarfState.Dead)
            return;

        dwarf.Energy = (byte)Math.Max(0, dwarf.Energy - _energyDecayRate);
    }

    public void ReduceSatiety(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping)
            dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _sleepingSatietyDecayRate);

        else
            dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _satietyDecayRate);
    }

    public void ReduceHydration(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping)
            dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _sleepingHydrationDecayRate);

        else
            dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _hydrationDecayRate);
    }
}
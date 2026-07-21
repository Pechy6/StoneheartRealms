using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedDecayService : INeedDecayService
{
    // energy
    private readonly byte _energyDecayRate = 4;
    private readonly byte _workingEnergyDecayRate = 6;

    //satiety
    private readonly byte _satietyDecayRate = 5;
    private readonly byte _workingSatietyDecayRate = 7;
    private readonly byte _sleepingSatietyDecayRate = 2;

    //hydration
    private readonly byte _hydrationDecayRate = 8;
    private readonly byte _workingHydrationDecayRate = 10;
    private readonly byte _sleepingHydrationDecayRate = 2;

    public void ReduceEnergy(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping or DwarfState.Dead)
            return;

        if (dwarf.DwarfState is DwarfState.Working)
        {
            dwarf.Energy = (byte)Math.Max(0, dwarf.Energy - _workingEnergyDecayRate);
            return;
        }

        dwarf.Energy = (byte)Math.Max(0, dwarf.Energy - _energyDecayRate);
    }

    public void ReduceSatiety(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping)
        {
            dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _sleepingSatietyDecayRate);
            return;
        }

        if (dwarf.DwarfState is DwarfState.Working)
        {
            dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _workingSatietyDecayRate);
            return;
        }

        dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _satietyDecayRate);
    }

    public void ReduceHydration(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Sleeping)
        {
            dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _sleepingHydrationDecayRate);
            return;
        }

        if (dwarf.DwarfState is DwarfState.Working)
        {
            dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _workingHydrationDecayRate);
            return;
        }

        dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _hydrationDecayRate);
    }
}
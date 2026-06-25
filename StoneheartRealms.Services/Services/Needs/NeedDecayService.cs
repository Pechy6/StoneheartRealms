using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedDecayService : INeedDecayService
{
    private readonly byte _energyDecayRate = 6;
    private readonly byte _satietyDecayRate = 5;
    private readonly byte _hydrationDecayRate = 8;

    public void ReduceEnergy(Dwarf dwarf)
    {
        dwarf.Energy = (byte)Math.Max(0, dwarf.Energy - _energyDecayRate);
    }

    public void ReduceSatiety(Dwarf dwarf)
    {
        dwarf.Hunger = (byte)Math.Max(0, dwarf.Hunger - _satietyDecayRate);
    }

    public void ReduceHydration(Dwarf dwarf)
    {
        dwarf.Thirst = (byte)Math.Max(0, dwarf.Thirst - _hydrationDecayRate);
    }
}
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
        dwarf.Satiety = (byte)Math.Max(0, dwarf.Satiety - _satietyDecayRate);
    }

    public void ReduceHydration(Dwarf dwarf)
    {
        dwarf.Hydration = (byte)Math.Max(0, dwarf.Hydration - _hydrationDecayRate);
    }
}
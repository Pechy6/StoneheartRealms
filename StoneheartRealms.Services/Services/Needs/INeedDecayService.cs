using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public interface INeedDecayService
{
    public void ReduceEnergy(Dwarf dwarf);
    public void ReduceSatiety(Dwarf dwarf);
    public void ReduceHydration(Dwarf dwarf);
}
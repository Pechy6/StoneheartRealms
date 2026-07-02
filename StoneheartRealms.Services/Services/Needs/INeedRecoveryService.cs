using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public interface INeedRecoveryService
{
    public void RecoverEnergy(Dwarf dwarf);
    public void RecoverSatiety(Dwarf dwarf);
    public void RecoverHydration(Dwarf dwarf);
}
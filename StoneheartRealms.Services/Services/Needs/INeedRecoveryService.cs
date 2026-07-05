using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public interface INeedRecoveryService
{
    public void RecoverEnergy(Dwarf dwarf);
    public Task RecoverSatiety(Dwarf dwarf);
    public Task RecoverHydration(Dwarf dwarf);
}
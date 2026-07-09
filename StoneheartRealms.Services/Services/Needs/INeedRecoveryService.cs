using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public interface INeedRecoveryService
{
    public Task RecoverSatiety(Dwarf dwarf);
    public Task RecoverHydration(Dwarf dwarf);
}
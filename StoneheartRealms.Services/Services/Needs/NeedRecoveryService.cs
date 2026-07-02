using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedRecoveryService: INeedRecoveryService
{

    private const int RecoveryEnergy = 15;
    private const int RecoverySatiety = 45;
    private const int RecoveryHydration = 30;
    
    public void RecoverEnergy(Dwarf dwarf)
    {
        if (dwarf.Energy < 45)
        {
            dwarf.Energy = (byte)Math.Min(100, dwarf.Energy + RecoveryEnergy);
        }
    }

    public void RecoverSatiety(Dwarf dwarf)
    {
        dwarf.Satiety = (byte)Math.Min(100, dwarf.Satiety + RecoverySatiety);
    }

    public void RecoverHydration(Dwarf dwarf)
    {
        dwarf.Hydration = (byte)Math.Min(100, dwarf.Hydration + RecoveryHydration);
    }
}
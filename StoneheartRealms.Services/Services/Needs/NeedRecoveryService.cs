using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.Resources;

namespace StoneheartRealms.Services.Services.Needs;

public class NeedRecoveryService(IResourceService resourceService) : INeedRecoveryService
{
    private readonly IResourceService _resourceService = resourceService;
    
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

    public async Task RecoverSatiety(Dwarf dwarf)
    {
        if (dwarf.Satiety <= 55)
        {
            var consumed = await _resourceService.TryConsumeFood(StorageTypeIds.MainStorage);
            if (consumed)
            {
                dwarf.Satiety = (byte)Math.Min(100, dwarf.Satiety + RecoverySatiety);
            }
        }
    }

    public async Task RecoverHydration(Dwarf dwarf)
    {
        if (dwarf.Hydration <= 70)
        {
            var consumed = await _resourceService.TryConsumeWater(StorageTypeIds.MainStorage);
            if (consumed)
            {
                dwarf.Hydration = (byte)Math.Min(100, dwarf.Hydration + RecoveryHydration);    
            }
        }
    }
}
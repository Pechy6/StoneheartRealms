using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.StorageManager;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.Production;

public class JobProduction(IStorageService storageService) : IJobProduction
{
    private readonly IStorageService _storageService = storageService;

    public async Task Produce(Dwarf dwarf)
    {
        ArgumentNullException.ThrowIfNull(dwarf);

        if (dwarf.Job == null)
        {
            return;
        }

        switch (dwarf.Job.Id)
        {
            case JobTypeIds.Farmer:
                await Farm(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Fisher:
                await Fish(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Hunter:
                await Hunt(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Cook:
                await Cook(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Woodcutter:
                await WoodCut(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Miner:
                await Mine(dwarf, StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Administrator:
                await Administrator(dwarf, StorageTypeIds.MainStorage);
                break;
        }
        
    }

    private async Task Farm(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Wheat, 1);
    }

    private async Task Fish(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Fish, 1);
    }

    private async Task Hunt(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Meat, 1);
    }

    private async Task Cook(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Food, 1);
    }
    
    private async Task WoodCut(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Wood, 1);
    }

    private async Task Administrator(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Gold, 1);
    }
    
    private async Task Mine(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Iron, 1);
    }
    
}
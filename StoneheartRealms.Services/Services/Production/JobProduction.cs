using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.StorageManager;

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
                await Farm(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Fisher:
                await Fish(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Hunter:
                await Hunt(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Cook:
                await Cook(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Woodcutter:
                await WoodCut(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Miner:
                await Mine(StorageTypeIds.MainStorage);
                break;
            case JobTypeIds.Administrator:
                await Administrator(StorageTypeIds.MainStorage);
                break;
        }
    }

    private async Task Farm(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Wheat, 1);
    }

    private async Task Fish(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Fish, 1);
    }

    private async Task Hunt(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Meat, 1);
    }

    private async Task Cook(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Food, 1);
    }

    private async Task WoodCut(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Wood, 1);
    }

    private async Task Administrator(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Gold, 1);
    }

    private async Task Mine(int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Iron, 1);
    }
}
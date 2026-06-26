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

        if (dwarf.JobId == JobTypeIds.Miner)
        {
            await Mine(dwarf, 1);
        }
        
    }

    private async Task Mine(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Iron, 1);
    }
}
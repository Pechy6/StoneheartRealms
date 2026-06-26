using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Services.Services.StorageManager;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.Production;

public class JobProduction(IStorageService storageService) : IJobProduction
{
    private readonly IStorageService _storageService = storageService;

    public Task Produce(Dwarf dwarf)
    {
        ArgumentNullException.ThrowIfNull(dwarf);

        if (dwarf.Job == null)
        {
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }

    private async Task Mine(Dwarf dwarf, int storageId)
    {
        await _storageService.AddResources(storageId, ResourceTypeIds.Iron, 1);
    }
}
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.Storage;

public interface IStorageService
{
    Task AddResources(int storageId, int resourceTypeId, int amount);
}
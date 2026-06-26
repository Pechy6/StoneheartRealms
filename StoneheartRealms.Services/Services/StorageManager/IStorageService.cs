using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.StorageManager;

public interface IStorageService
{
    Task AddResources(int storageId, int resourceTypeId, int amount);
    Task<Storage?> GetStorage(int id);
}
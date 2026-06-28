using StoneheartRealms.Data.Entities.Storage;
using StoneheartRealms.Services.DTOs.StorageResources;

namespace StoneheartRealms.Services.Services.StorageManager;

public interface IStorageService
{
    Task AddResources(int storageId, int resourceTypeId, int amount);
    Task <IEnumerable<ResourceDto?>> GetResources(int storageId);
}
using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.StorageManager;

public class StorageService(StoneheartRealmsDbContext context) : IStorageService
{
    private readonly StoneheartRealmsDbContext _context = context;

    public async Task AddResources(int storageId, int resourceTypeId, int amount)
    {
        var resource =
            await _context.Resources.FirstOrDefaultAsync(s =>
                s.StorageId == storageId && s.ResourceTypeId == resourceTypeId);

        if (resource == null)
        {
            throw new Exception("There is no resource in this storage.");
        }

        resource.Amount += amount;
        await _context.SaveChangesAsync();
    }

    public async Task<Storage?> GetStorage(int id)
    {
        return await _context.
            Storages.
            Include(s => s.Resources).
            ThenInclude(r => r.ResourceType).
            FirstOrDefaultAsync(s => s.Id == id);
    }
}
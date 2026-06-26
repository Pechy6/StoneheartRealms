using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.Storage;

public class StorageService(StoneheartRealmsDbContext context) : IStorageService
{
    private readonly StoneheartRealmsDbContext _context = context;

    public async Task AddResources(int storageId, int resourceTypeId, int amount)
    {
        var defaultStorage = await _context.Storages.FirstOrDefaultAsync();
        if (defaultStorage == null)
        {
            throw new Exception("There is no default storage.");
        }
        
        var resource =
            await _context.Resources.FirstOrDefaultAsync(s => s.StorageId == storageId && s.ResourceTypeId == resourceTypeId);

        if (resource == null)
        {
            throw new Exception("There is no resource in this storage.");
        }
        
        resource.Amount += amount;
        await _context.SaveChangesAsync();
    }
    
}
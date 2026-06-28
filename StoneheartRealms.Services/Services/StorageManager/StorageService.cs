using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Data.Entities.Storage;
using StoneheartRealms.Services.DTOs.StorageResources;

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

    public async Task<IEnumerable<ResourceDto?>> GetResources(int storageId)
    {
        var resources =  await _context.
            Resources.
            Include(r => r.ResourceType).
            Where(r => r.StorageId == storageId).ToListAsync();

        return resources.Select(r => new ResourceDto
        {
            ResourceName = r.ResourceType.Name,
            Amount = r.Amount
        });
    }
}
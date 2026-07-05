using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Data;

namespace StoneheartRealms.Services.Services.Resources;

public class ResourceService(StoneheartRealmsDbContext context) : IResourceService
{
    private readonly StoneheartRealmsDbContext _context = context;
    private const int ResourceToConsume = 1;

    public async Task<bool> TryConsumeFood(int storageId)
    {
        var food = await _context.Resources.FirstOrDefaultAsync(r =>
            r.StorageId == storageId && r.ResourceTypeId == ResourceTypeIds.Food);

        if (food == null || food.Amount < ResourceToConsume)
        {
            return false;
        }

        food.Amount -= ResourceToConsume;
        return true;
    }

    public async Task<bool> TryConsumeWater(int storageId)
    {
        var water = await _context.Resources.FirstOrDefaultAsync(r =>
            r.StorageId == storageId && r.ResourceTypeId == ResourceTypeIds.Water);

        if (water == null || water.Amount < ResourceToConsume)
        {
            return false;
        }

        water.Amount -= ResourceToConsume;
        return true;
    }
}
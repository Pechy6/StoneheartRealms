namespace StoneheartRealms.Services.Services.Resources;

public interface IResourceService
{
    public Task<bool> TryConsumeFood(int storageId);
    public Task<bool> TryConsumeWater(int storageId);
}
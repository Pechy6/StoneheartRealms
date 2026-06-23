namespace StoneheartRealms.Data.Entities.Storage;

public class Resources
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int StorageId { get; set; }
    public int ResourceTypeId { get; set; }
    
    public Storage Storage { get; set; }
    public ResourceType ResourceType { get; set; }
}
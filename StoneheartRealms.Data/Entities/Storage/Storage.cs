namespace StoneheartRealms.Data.Entities.Storage;

public class Storage
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    
    public ICollection<Resources> Resources { get; set; } = new List<Resources>();
}
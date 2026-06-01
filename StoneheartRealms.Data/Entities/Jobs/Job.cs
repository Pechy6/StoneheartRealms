using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Data.Entities.Jobs;


public class Job
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    
    public ICollection<Dwarf> Dwarves { get; set; } = new List<Dwarf>();
}
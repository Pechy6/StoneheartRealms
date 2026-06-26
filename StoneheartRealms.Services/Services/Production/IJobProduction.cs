using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Production;

public interface IJobProduction
{
    Task Produce(Dwarf dwarf);
}
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs.Sleep;

public interface ISleepService
{
    public void ProcessSleep(Dwarf dwarf);
}
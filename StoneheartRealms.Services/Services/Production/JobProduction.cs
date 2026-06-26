using StoneheartRealms.Data.Entities.Creatures;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Services.Services.Production;

public class JobProduction: IJobProduction
{
    public Task Produce(Dwarf dwarf)
    {
        ArgumentNullException.ThrowIfNull(dwarf);

        if (dwarf.Job == null)
        {
            return Task.CompletedTask;
        }

        switch (dwarf.JobId)
        {
            
        }
        
        return Task.CompletedTask;
    }
    
    private void Mine(Dwarf dwarf, Storage storage)
    {
        
    }
}
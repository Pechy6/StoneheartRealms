using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.Needs.Sleep;

public class SleepService : ISleepService
{
    private readonly byte _remainingEnergy = 35;
    private readonly byte _recoveryEnergy = 8;
    private readonly byte _maxEnergy = 100;

    public void ProcessSleep(Dwarf dwarf)
    {
        if (dwarf.Energy <= _remainingEnergy)
        {
            dwarf.DwarfState = DwarfState.Sleeping;
        }

        if (dwarf.DwarfState == DwarfState.Sleeping)
        {
            dwarf.Energy = (byte)Math.Min(dwarf.Energy + _recoveryEnergy, _maxEnergy);

            if (dwarf.Energy == _maxEnergy)
            {
                dwarf.DwarfState = dwarf.JobId == JobTypeIds.UnassignedJob
                    ? DwarfState.Idle
                    : DwarfState.Working;
            }
        }
    }
}
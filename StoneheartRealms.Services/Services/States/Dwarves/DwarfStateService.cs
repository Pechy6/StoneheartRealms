using StoneheartRealms.Data.Constants;
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Services.Services.States.Dwarves;

public class DwarfStateService : IDwarfStateService
{
    public void SetDwarfState(Dwarf dwarf)
    {
        if (dwarf.DwarfState is DwarfState.Dead or DwarfState.Sleeping or DwarfState.Traveling
            or DwarfState.Fighting)
        {
            return;
        }

        if (dwarf.JobId == null)
        {
            dwarf.DwarfState = DwarfState.Idle;
            return;
        }

        dwarf.DwarfState = dwarf.JobId == JobTypeIds.UnassignedJob
            ? DwarfState.Idle
            : DwarfState.Working;
    }
}
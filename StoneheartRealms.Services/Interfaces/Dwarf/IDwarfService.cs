using StoneheartRealms.Services.DTOs;
using StoneheartRealms.Services.DTOs.Job;

namespace StoneheartRealms.Services.Interfaces.Dwarf;

public interface IDwarfService
{
    public Task<DwarfDto?> GetDwarf(int id);
    public Task<IEnumerable<DwarfDto>> GetDwarves();
    public Task<DwarfDto> CreateDwarf(CreateDwarfDto dwarf);
    public Task<DwarfDto?> UpdateDwarf(int id, UpdateDwarfDto dwarf);
    public Task<bool> DeleteDwarf(int id);
    public Task AssignJob(int dwarfId, int jobId);
}
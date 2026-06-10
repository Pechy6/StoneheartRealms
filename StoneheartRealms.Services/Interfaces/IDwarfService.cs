using StoneheartRealms.Services.DTOs;

namespace StoneheartRealms.Services.Interfaces;

public interface IDwarfService
{
    public Task<DwarfDto> GetDwarf(int id);
    public Task<IEnumerable<DwarfDto>> GetDwarves();
    public Task<DwarfDto> CreateDwarf(DwarfDto dwarf);
    public Task<DwarfDto> UpdateDwarf(DwarfDto dwarf);
    public Task DeleteDwarf(int id);
}
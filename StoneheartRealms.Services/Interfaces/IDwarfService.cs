using StoneheartRealms.Services.DTOs;

namespace StoneheartRealms.Services.Interfaces;

public interface IDwarfService
{
    public Task<DwarfDto?> GetDwarf(int id);
    public Task<IEnumerable<DwarfDto>> GetDwarves();
    public Task<DwarfDto> CreateDwarf(CreateDwarfDto dwarf);
    public Task<DwarfDto?> UpdateDwarf(int id, UpdateDwarfDto dwarf);
    public Task DeleteDwarf(int id);
}
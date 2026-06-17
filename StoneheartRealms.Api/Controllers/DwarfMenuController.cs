using Microsoft.AspNetCore.Mvc;
using StoneheartRealms.Services.DTOs;
using StoneheartRealms.Services.Interfaces.Dwarf;

namespace StoneheartRealms.Api.Controllers;

[ApiController]
[Route("api/dwarves")]
public class DwarfMenuController(IDwarfService dwarfService) : ControllerBase
{
    private readonly IDwarfService _dwarfService = dwarfService;

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dwarves = await _dwarfService.GetDwarves();

        return Ok(dwarves);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDwarf(int id)
    {
        var dwarf = await _dwarfService.GetDwarf(id);
        if (dwarf == null)
        {
            return NotFound();
        }

        return Ok(dwarf);
    }


    [HttpPost]
    public async Task<IActionResult> CreateDwarf(CreateDwarfDto dwarf)
    {
        var newDwarf = await _dwarfService.CreateDwarf(dwarf);
        return Ok(newDwarf);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDwarf(int id, UpdateDwarfDto dwarf)
    {
        var updatedDwarf = await _dwarfService.UpdateDwarf(id, dwarf);
        if (updatedDwarf == null)
        {
            return NotFound();
        }

        return Ok(updatedDwarf);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDwarf(int id)
    {
        var deleted = await _dwarfService.DeleteDwarf(id);

        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    

    [HttpPut("{dwarfId:int}/job/{jobId:int}")]
    public async Task<IActionResult> AssignJob(int dwarfId, int jobId)
    {
        await _dwarfService.AssignJob(dwarfId, jobId);
        return NoContent();
    }
}
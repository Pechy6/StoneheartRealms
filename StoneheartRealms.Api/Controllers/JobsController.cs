using Microsoft.AspNetCore.Mvc;
using StoneheartRealms.Services.Interfaces.Job;

namespace StoneheartRealms.Api.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController(IJobService jobService) : ControllerBase
{
    private readonly IJobService _jobService = jobService;
    
    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        var jobs = await _jobService.GetJobs();
        if (jobs == null)
            return NotFound();

        return Ok(jobs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetJob(int id)
    {
        var job = await _jobService.GetJobById(id);
        return Ok(job);
    }
}
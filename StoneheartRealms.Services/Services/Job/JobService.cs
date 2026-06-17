using Microsoft.EntityFrameworkCore;
using StoneheartRealms.Data.Data;
using StoneheartRealms.Services.DTOs.Job;
using StoneheartRealms.Services.Interfaces.Job;

namespace StoneheartRealms.Services.Services.Job;

public class JobService(StoneheartRealmsDbContext context): IJobService
{
    private readonly StoneheartRealmsDbContext _context = context;
    public async Task<IEnumerable<JobDto>> GetJobs()
    {
        var jobs = await _context.Jobs.ToListAsync();
        return jobs.Select(job => new JobDto
        {
            Id = job.Id,
            Name = job.Name,
            Description = job.Description
        });
    }

    public async Task<JobDto?> GetAllJobs(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null)
        {
            return null;
        }

        return new JobDto
        {
            Id = job.Id,
            Name = job.Name,
            Description = job.Description
        };
    }
}
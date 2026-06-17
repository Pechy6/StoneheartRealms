using StoneheartRealms.Services.DTOs.Job;

namespace StoneheartRealms.Services.Interfaces.Job;

public interface IJobService
{
    public Task<IEnumerable<JobDto>> GetJobs();
    public Task<JobDto?> GetAllJobs(int id);
}
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.JobAggregate;
using JobFinder.Domain.JobAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using JobFinder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobFinder.Infrastructure.Common.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobFinderDbContext _context;

        public JobRepository(JobFinderDbContext context)
        {
            _context = context;
        }

        public async Task<Job> AddRequirements(Job Job, List<SkillId> Skills)
        {
            Job.AddRequirements(Skills);
            await _context.SaveChangesAsync();
            return Job;
        }

        public async Task<Job> Create(Job Job,Employer Employer)
        {
            Employer.AddJob(Job);
            await _context.SaveChangesAsync();
            return Job;
        }

        public async Task<Job> Get(JobId JobId)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == JobId);
            return job;
        }

        public async Task<Job> Get(Expression<Func<Job, bool>> expression)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(expression);
            return job;
        }

        public Task<List<Job>> GetAll()
        {
            var jobs = _context.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<List<Job>> GetAll(Expression<Func<Job, bool>> expression)
        {
            var jobs = await _context.Jobs.Where(expression).ToListAsync();
            return jobs;
        }
    }
}

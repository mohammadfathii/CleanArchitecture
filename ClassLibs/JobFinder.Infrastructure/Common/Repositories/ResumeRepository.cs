using System.Linq.Expressions;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Infrastructure.Persistence;

namespace JobFinder.Infrastructure.Common.Repositories;

public class ResumeRepository : IResumeRepository
{
    private readonly JobFinderDbContext _context;

    public ResumeRepository(JobFinderDbContext context)
    {
        _context = context;
    }

    public async Task<Resume> CreateResume(Resume resume)
    {
      await _context.Resumes.AddAsync(resume);
      await _context.SaveChangesAsync();
      return resume;
    }

    public Task<Resume> GetResume(string ResumeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Resume>> GetResumes(Expression<Func<Resume, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Resume> Resume(Expression<Func<Resume, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Resume> UpdateResume(Resume resume)
    {
        throw new NotImplementedException();
    }
}

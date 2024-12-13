using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.UserAggregate;
using JobFinder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobFinder.Infrastructure.Common.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly JobFinderDbContext _dbContext;

        public EmployerRepository(JobFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employer> Create(Employer employer)
        {
            await _dbContext.Employers.AddAsync(employer);
            await _dbContext.SaveChangesAsync();
            return employer;
        }

        public async Task<Employer> GetEmployer(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmployerExists(string Email, string CompanyName)
        {
            return await _dbContext.Employers.AnyAsync(e => e.Email == Email || e.CompanyName == CompanyName);
        }

        public async Task<Employer> Employer(Expression<Func<Employer, bool>> expression)
        {
            var employer = await _dbContext.Employers.Include(e => e.Jobs).FirstOrDefaultAsync(expression);
            return employer;
        }
    }
}

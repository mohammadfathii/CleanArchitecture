using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

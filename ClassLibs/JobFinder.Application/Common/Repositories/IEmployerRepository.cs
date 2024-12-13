namespace JobFinder.Application.Common.Repositories;

using JobFinder.Domain.EmployerAggregate;
using System.Linq.Expressions;

public interface IEmployerRepository
{
    Task<Employer> Create(Employer employer);
    Task<Employer> GetEmployer(string Id);
    Task<Employer> Employer(Expression<Func<Employer,bool>> expression);
    Task<bool> EmployerExists(string Email, string CompanyName);
}

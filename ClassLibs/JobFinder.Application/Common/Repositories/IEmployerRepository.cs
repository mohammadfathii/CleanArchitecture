namespace JobFinder.Application.Common.Repositories;

using JobFinder.Domain.EmployerAggregate;

public interface IEmployerRepository
{
    Task<Employer> Create(Employer employer);
    Task<Employer> GetEmployer(string Id);
    Task<bool> EmployerExists(string Email, string CompanyName);
}

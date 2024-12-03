namespace JobFinder.Application.Employer.Commands.Create;

using FluentResults;
using JobFinder.Application.Common.Errors;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.EmployerAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, Result<Employer>>
{

    private readonly IEmployerRepository _employerRepository;
    private readonly IPasswordEncoder _passwordHasher;

    public CreateEmployerCommandHandler(IEmployerRepository employerRepository, IPasswordEncoder passwordHasher)
    {
        _employerRepository = employerRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<Employer>> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
    {
        var exists = await _employerRepository.EmployerExists(request.employer.Email,request.employer.CompanyName);

        if (exists)
        {
            return Result.Fail(new[]
            {
                new EntityExistsError()
                {
                    Message = "the employer already exists !"
                }
            });
        }
        
        var hashPassword = _passwordHasher.HashPassword(request.employer.Password);

        var employer = await _employerRepository.Create(Employer.Create(
            request.employer.CompanyName,
            request.employer.Email,
            request.employer.PhoneNumber,
            request.employer.Address,
            request.employer.Description,
            hashPassword,
            new List<Domain.JobAggregate.Job>()));

        return employer;
    }
}

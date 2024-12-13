namespace JobFinder.Application.Employer.Queries.Login;

using JobFinder.Application.Common.Repositories;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Errors;
using JobFinder.Domain.EmployerAggregate;
using System.Threading.Tasks;
using System.Threading;
using FluentResults;
using MediatR;

public class LoginEmployerQueryHandler : IRequestHandler<LoginEmployerQuery, Result<Employer>>
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IPasswordEncoder _passwordEncoder;

    public LoginEmployerQueryHandler(IEmployerRepository employerRepository,IPasswordEncoder passwordEncoder)
    {
        _employerRepository = employerRepository;
        _passwordEncoder = passwordEncoder;
    }

    public async Task<Result<Employer>> Handle(LoginEmployerQuery request, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.Employer(e => e.Email == request.Email);

        if (employer == null)
        {
            return Result.Fail(new[]
            {
                new AuthenticationFaieldError()
                {
                    Message = "employer dosent exists !"
                }
            });
        }

        if (!_passwordEncoder.VerifyPassword(employer.Password,request.Password))
        {
            return Result.Fail(new[]
            {
                new AuthenticationFaieldError()
                {
                    Message = "employer dosent exists !"
                }
            });
        }

        return employer;
    }
}


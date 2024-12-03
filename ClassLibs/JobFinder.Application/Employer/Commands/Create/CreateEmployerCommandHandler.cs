namespace JobFinder.Application.Employer.Commands.Create;

using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.EmployerAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, Employer>
{

    private readonly IEmployerRepository _employerRepository;

    public CreateEmployerCommandHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }

    public Task<Employer> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

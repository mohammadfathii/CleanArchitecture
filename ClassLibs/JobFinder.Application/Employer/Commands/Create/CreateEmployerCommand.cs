namespace JobFinder.Application.Employer.Commands.Create;

using JobFinder.Domain.EmployerAggregate;
using MediatR;

public record CreateEmployerCommand(CreateEmployerCommandDTO employer) : IRequest<Employer>;

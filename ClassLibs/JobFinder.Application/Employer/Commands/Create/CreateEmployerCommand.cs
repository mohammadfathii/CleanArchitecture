namespace JobFinder.Application.Employer.Commands.Create;

using FluentResults;
using JobFinder.Domain.EmployerAggregate;
using MediatR;

public record CreateEmployerCommand(CreateEmployerCommandDTO employer) : IRequest<Result<Employer>>;

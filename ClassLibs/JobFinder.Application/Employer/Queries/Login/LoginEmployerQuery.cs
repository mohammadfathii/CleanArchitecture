namespace JobFinder.Application.Employer.Queries.Login;

using FluentResults;
using JobFinder.Domain.EmployerAggregate;
using MediatR;

public record LoginEmployerQuery(string Email,string Password) : IRequest<Result<Employer>>;

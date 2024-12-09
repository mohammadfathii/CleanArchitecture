namespace JobFinder.Application.User.Commands.Create;

using FluentResults;
using JobFinder.Domain.UserAggregate;
using MediatR;

public record CreateUserCommand(CreateUserCommandDTO User) : IRequest<Result<User>>;

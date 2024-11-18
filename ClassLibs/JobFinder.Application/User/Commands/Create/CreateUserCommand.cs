using FluentResults;
using MediatR;

namespace JobFinder.Application.User.Commands.Create;

public record CreateUserCommand (CreateUserCommandDTO User) : IRequest<Result<Domain.User.User>>;

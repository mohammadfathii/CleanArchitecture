using MediatR;

namespace JobFinder.Application.User.Commands.Create;

public record CreateUserCommand (CreateUserCommandDTO User,string AccessToken) : IRequest<Domain.User.User>;

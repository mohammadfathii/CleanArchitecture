using FluentResults;
using MediatR;

namespace JobFinder.Application.User.Commands.Test;

public record TestUserCommand (string username) : IRequest<Result<string>>;

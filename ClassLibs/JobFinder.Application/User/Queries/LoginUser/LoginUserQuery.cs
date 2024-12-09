namespace JobFinder.Application.User.Queries.LoginUser;

using FluentResults;
using JobFinder.Domain.UserAggregate;
using MediatR;

public record LoginUserQuery(string UserName,string Password) : IRequest<Result<User>>;

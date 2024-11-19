namespace JobFinder.Application.User.Queries.GetUser;

using MediatR;
using JobFinder.Domain.UserAggregate;

public record GetUserQuery(string userId) : IRequest<User>;

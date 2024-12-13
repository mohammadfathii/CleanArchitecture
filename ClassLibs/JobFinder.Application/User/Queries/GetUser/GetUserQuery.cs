namespace JobFinder.Application.User.Queries.GetUser;

using MediatR;
using JobFinder.Domain.UserAggregate;
using System.Linq.Expressions;

public record GetUserQuery(Expression<Func<User,bool>> expression) : IRequest<User>;

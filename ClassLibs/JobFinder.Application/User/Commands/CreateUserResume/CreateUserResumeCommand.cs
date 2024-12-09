namespace JobFinder.Application.User.Commands.CreateUserResume;

using FluentResults;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.UserAggregate;
using MediatR;

public record CreateUserResumeCommand(Resume Resume ,User User) : IRequest<Result<User>>;

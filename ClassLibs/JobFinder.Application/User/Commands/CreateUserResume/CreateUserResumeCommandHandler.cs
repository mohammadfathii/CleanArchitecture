namespace JobFinder.Application.User.Commands.CreateUserResume;

using MediatR;
using JobFinder.Domain.UserAggregate;
using FluentResults;
using System.Threading.Tasks;
using System.Threading;
using JobFinder.Application.Common.Repositories;
using JobFinder.Application.Common.Errors;
using System.Net;

public class CreateUserResumeCommandHandler : IRequestHandler<CreateUserResumeCommand, Result<User>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserResumeCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(CreateUserResumeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CreateResume(request.Resume,request.User);

        return user;
    }
}

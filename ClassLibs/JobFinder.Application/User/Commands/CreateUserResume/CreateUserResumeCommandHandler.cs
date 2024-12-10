namespace JobFinder.Application.User.Commands.CreateUserResume;

using MediatR;
using JobFinder.Domain.UserAggregate;
using FluentResults;
using System.Threading.Tasks;
using System.Threading;
using JobFinder.Application.Common.Repositories;
using JobFinder.Application.Common.Errors;
using System.Net;
using JobFinder.Domain.ResumeAggregate;

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

        if (user == null)
        {
            return Result.Fail(new[]
            {
                new EntityExistsError()
                {
                    Message = "Please Provide a Different Email !"
                }
            });
        }

        return user;
    }
}

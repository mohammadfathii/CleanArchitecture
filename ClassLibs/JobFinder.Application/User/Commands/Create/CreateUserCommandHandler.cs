namespace JobFinder.Application.User.Commands.Create;

using FluentResults;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate;
using JobFinder.Domain.UserAggregate.Enums;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("the create user executed !");
        var user = await _userRepository.Create(User.Create(
            request.User.FullName,
            request.User.UserName,
            request.User.Email,
            request.User.Password,
            UserPermission.Admin,
            new List<Domain.ResumeAggregate.Resume>()));
        return user;
        // return Result.Fail<User>(new[]{
        //     "null result"
        // });
    }
}

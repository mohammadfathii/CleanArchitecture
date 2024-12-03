namespace JobFinder.Application.User.Commands.Create;

using FluentResults;
using JobFinder.Application.Common.Errors;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;
using JobFinder.Domain.UserAggregate.Enums;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncoder _passwordEncoder;
    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordEncoder passwordEncoder)
    {
        _userRepository = userRepository;
        _passwordEncoder = passwordEncoder;
    }

    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userRepository.UserExists(request.User.UserName,request.User.Email);

        if (exists)
        {
            return Result.Fail(new[]
            {
                new EntityExistsError()
                {
                    Message = "the user already exists !"
                }
            });
        }

        var hashPassword = _passwordEncoder.HashPassword(request.User.Password);
        var user = await _userRepository.Create(User.Create(
            request.User.FullName,
            request.User.UserName,
            request.User.Email,
            hashPassword,
            UserPermission.Admin,
            new List<Domain.ResumeAggregate.Resume>()));
        return user;
    }
}

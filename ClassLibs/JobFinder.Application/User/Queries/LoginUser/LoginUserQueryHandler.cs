namespace JobFinder.Application.User.Queries.LoginUser;

using System.Linq.Expressions;
using System.Net;
using System.Threading;
using FluentResults;
using JobFinder.Application.Common.Errors;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;
using MediatR;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncoder _passwordEncoder;

    public LoginUserQueryHandler(IUserRepository userRepository, IPasswordEncoder passwordEncoder)
    {
        _userRepository = userRepository;
        _passwordEncoder = passwordEncoder;
    }

    public async Task<Result<User>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.User(u => u.UserName == request.UserName);

        if (user == null)
        {
            return Result.Fail(new[] {
                new AuthenticationFaieldError(){
                    Message = "user dosent exists !",
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            });
        }

        if (_passwordEncoder.VerifyPassword(user.Password, request.Password))
        {
            return user;
        }

        return Result.Fail(new[] {
                new AuthenticationFaieldError(){
                    Message = "user dosent exists !",
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            });

    }
}

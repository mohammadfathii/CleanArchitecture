namespace JobFinder.Application.User.Commands.Create;

using FluentResults;
using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate;
using JobFinder.Domain.UserAggregate.Enums;
using MediatR;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("the create user executed !");
        return User.Create("mohammad fathi","edovoss","mohammad@gmail.com","asdasdas",UserPermission.Admin,ResumeId.CreateUnique());
        // return Result.Fail<User>(new[]{
        //     "null result"
        // });
    }
}

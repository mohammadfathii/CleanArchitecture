using FluentResults;
using JobFinder.Domain.Resume.ValueObjects;
using JobFinder.Domain.User;
using MediatR;

namespace JobFinder.Application.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Domain.User.User>>
{
    public async Task<Result<Domain.User.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("the create user executed !");
        // return Domain.User.User.Create("mohammad fathi","edovoss","mohammad@gmail.com","asdasdas",Domain.User.Enums.UserPermission.Admin,ResumeId.CreateUnique());
        return Result.Fail<Domain.User.User>(new []{
            "null result"
        });
    }
}

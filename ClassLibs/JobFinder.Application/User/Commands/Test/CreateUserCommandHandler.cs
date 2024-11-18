using FluentResults;
using MediatR;

namespace JobFinder.Application.User.Commands.Test;

public class TestUserCommandHandler : IRequestHandler<TestUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(TestUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("the test user executed !");
        return request.username;
    }
}

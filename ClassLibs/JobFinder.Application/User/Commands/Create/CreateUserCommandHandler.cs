using JobFinder.Domain.User;
using MediatR;

namespace JobFinder.Application.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Domain.User.User>
{
    
    public async Task<Domain.User.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

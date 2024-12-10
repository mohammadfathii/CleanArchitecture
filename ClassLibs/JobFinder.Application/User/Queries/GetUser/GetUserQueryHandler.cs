namespace JobFinder.Application.User.Queries.GetUser;

using System.Threading;
using System.Threading.Tasks;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;
using MediatR;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IUserRepository _userRepository;
    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.User(u => u.UserName == request.username);
        return user;
    }
}

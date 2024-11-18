namespace JobFinder.Infrastructure.Common.Repositories;

using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;

public class UserRepository : IUserRepository
{
    public async Task<User> Create(User user)
    {
        throw new NotImplementedException();
    }
}

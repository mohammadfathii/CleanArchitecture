using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.User;

namespace JobFinder.Infrastructure.Common.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User> Create(User user)
    {
        throw new NotImplementedException();
    }
}

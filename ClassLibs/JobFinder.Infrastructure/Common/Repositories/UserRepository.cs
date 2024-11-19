namespace JobFinder.Infrastructure.Common.Repositories;

using System;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public async Task<User> Create(User user)
    {
        _users.Add(user);
        return user;
    }

    public async Task<User> GetUser(string userId)
    {
        return _users.FirstOrDefault(u => u.Id.Value.ToString() == userId);
    }
}

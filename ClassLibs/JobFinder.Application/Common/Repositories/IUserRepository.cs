namespace JobFinder.Application.Common.Repositories;

using JobFinder.Domain.UserAggregate;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetUser(string userId);
    Task<bool> UserExists(string UserName, string Email);
}

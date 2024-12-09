namespace JobFinder.Application.Common.Repositories;

using System.Linq.Expressions;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.UserAggregate;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetUser(string userId);
    Task<User> User(Expression<Func<User,bool>> expression);
    Task<bool> UserExists(string UserName, string Email);
    Task<User> CreateResume(Resume resume,User user);
}

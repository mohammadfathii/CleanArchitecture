namespace JobFinder.Infrastructure.Common.Repositories;

using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.UserAggregate;
using JobFinder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private JobFinderDbContext _context;
    public UserRepository(JobFinderDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
        return user;
    }

    public async Task<User> GetUser(string userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id.Value.ToString() == userId);
    }

    public async Task<bool> UserExists(string UserName,string Email)
    {
        return await _context.Users.AnyAsync(u => u.UserName == UserName || u.Email == Email);
    }
}

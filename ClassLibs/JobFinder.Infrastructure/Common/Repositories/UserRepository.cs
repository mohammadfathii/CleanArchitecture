namespace JobFinder.Infrastructure.Common.Repositories;

using System;
using System.Linq.Expressions;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.ResumeAggregate;
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

    public async Task<User> CreateResume(Resume resume, User user)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            // added resume to database
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            // create a new list of resumes and added the user previous resumes and new resume
            var resumes = new List<Resume>();
            resumes.AddRange(user.Resumes);
            resumes.Add(resume);

            // create a new user and added the list to it
            var newuser = JobFinder.Domain.UserAggregate.User.Create(user.FullName, user.UserName, user.Email, user.Password, user.PhoneNumber, Domain.UserAggregate.Enums.UserPermission.Admin, resumes);
            _context.Users.Update(newuser);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return newuser;
        }
    }

    public async Task<User> GetUser(string userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id.Value.ToString() == userId);
    }

    public async Task<User?> User(Expression<Func<User, bool>> expression)
    {
        var user = await _context.Users.FirstOrDefaultAsync(expression);
        return user;
    }

    public async Task<bool> UserExists(string UserName, string Email)
    {
        return await _context.Users.AnyAsync(u => u.UserName == UserName || u.Email == Email);
    }
}

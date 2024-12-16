namespace JobFinder.Infrastructure.Common.Repositories;

using System;
using System.Linq.Expressions;
using Azure.Core;
using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
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
        // check if there is any other resume that have same email for the same user
        if (user.Resumes.Any(x => x.Email == resume.Email))
        {
            return null;
        }
        if (resume.Skills == null)
        {
            resume = Resume.Create(resume.Email,resume.PhoneNumber,resume.City,new List<SkillId>());
        }
        // add the resume into the _resumes field 
        user.AddResume(resume);
        // update the database
        await _context.SaveChangesAsync();

        return user;
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

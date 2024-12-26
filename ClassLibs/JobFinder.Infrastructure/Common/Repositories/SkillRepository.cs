namespace JobFinder.Infrastructure.Common.Repositories;

using JobFinder.Application.Common.Repositories;
using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using JobFinder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public class SkillRepository : ISkillRepository
{
    private readonly JobFinderDbContext _context;

    public SkillRepository(JobFinderDbContext context)
    {
        _context = context;
    }

    public async Task<Skill> Create(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();

        return skill;
    }

    public async Task<Skill> Get(SkillId id)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

        return skill;
    }

    public async Task<Skill> Get(Expression<Func<Skill, bool>> expression)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(expression);

        return skill;
    }

    public async Task<List<Skill>> Get()
    {
        var skills = await _context.Skills.ToListAsync();
        return skills;
    }

    public async Task<bool> Remove(SkillId id)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

        if (skill == null)
        {
            return false;
        }

        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
        return true;
    }
}

namespace JobFinder.Application.Common.Repositories;

using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface ISkillRepository
{
    Task<Skill> Create(Skill skill);
    Task<Skill> Get(SkillId id);
    Task<Skill> Get(Expression<Func<Skill,bool>> expression);
    Task<List<Skill>> Get();
    Task<bool> Remove(SkillId id);
}


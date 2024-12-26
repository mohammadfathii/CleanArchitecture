namespace JobFinder.Application.Common.Repositories;

using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.JobAggregate;
using JobFinder.Domain.JobAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


public interface IJobRepository
{
    Task<Job> Create(Job Job,Employer Employer);
    Task<Job> Get(JobId JobId);
    Task<Job> Get(Expression<Func<Job,bool>> expression);
    Task<List<Job>> GetAll();
    Task<List<Job>> GetAll(Expression<Func<Job, bool>> expression);
    Task<Job> AddRequirements(Job Job,List<SkillId> Skills);
}


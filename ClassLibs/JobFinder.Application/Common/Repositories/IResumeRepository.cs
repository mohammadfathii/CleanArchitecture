namespace JobFinder.Application.Common.Repositories;

using System.Linq.Expressions;
using JobFinder.Domain.ResumeAggregate;

public interface IResumeRepository
{
  Task<Resume> CreateResume(Resume resume);
  Task<Resume> UpdateResume(Resume resume);
  Task<Resume> GetResume(string ResumeId);
  Task<Resume> Resume(Expression<Func<Resume,bool>> expression);
  Task<List<Resume>> GetResumes(Expression<Func<Resume,bool>> expression);
}

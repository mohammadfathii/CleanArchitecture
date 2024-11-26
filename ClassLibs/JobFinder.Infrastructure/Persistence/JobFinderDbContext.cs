namespace JobFinder.Infrastructure.Persistence;

using JobFinder.Domain.Common.Models;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.JobAggregate;
using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.UserAggregate;
using JobFinder.Infrastructure.Common.Interceptors;
using Microsoft.EntityFrameworkCore;

public class JobFinderDbContext : DbContext
{
  private PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

  public JobFinderDbContext(DbContextOptions<JobFinderDbContext> options,PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options) {
    _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
    .Ignore<List<IDomainEvent>>()
    .ApplyConfigurationsFromAssembly(typeof(JobFinderDbContext).Assembly);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
    base.OnConfiguring(optionsBuilder);
  }

  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Resume> Resumes { get; set; } = null!;
  public DbSet<Skill> Skills { get; set; } = null!;
  public DbSet<Job> Jobs { get; set; } = null!;
  public DbSet<Employer> Employers { get; set; } = null!;
}

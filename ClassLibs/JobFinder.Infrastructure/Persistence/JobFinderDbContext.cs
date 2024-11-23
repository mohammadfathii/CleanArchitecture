namespace JobFinder.Infrastructure.Persistence;

using JobFinder.Domain.ResumeAggregate;
using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

public class JobFinderDbContext : DbContext
{
  public JobFinderDbContext(DbContextOptions<JobFinderDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobFinderDbContext).Assembly);
  }

  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Resume> Resumes { get; set; } = null!;
  public DbSet<Skill> Skills { get; set; } = null!;
}

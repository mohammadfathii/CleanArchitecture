using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.EmployerAggregate.ValueObjects;
using JobFinder.Domain.JobAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobFinder.Infrastructure.Persistence.Configurations;

public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
{
  public void Configure(EntityTypeBuilder<Employer> builder)
  {
    builder.ToTable("Employers");

    builder.HasKey("Id");

    builder.Property(e => e.Id)
      .ValueGeneratedNever()
      .HasConversion(Id => Id.Value, Value => EmployerId.Create(Value));

    builder.OwnsMany(j => j.Jobs, jb =>
    {
      jb.ToTable("Jobs");

      jb.WithOwner().HasForeignKey("EmployerId");

      jb.HasKey("Id","EmployerId");

      jb.Property(x => x.Id)
        .HasColumnName("JobId")
        .ValueGeneratedNever()
        .HasConversion(Id => Id.Value, Value => JobId.Create(Value));

      // Configuration for back proeprty of skillIds as Requirements in job table
      // to create a new table named jobsrequirements and hold the jobid and skillid
      jb.OwnsMany(r => r.Requirements, rb =>
      {
        rb.ToTable("JobsRequirements");

        rb.Property(x => x.Value)
          .HasColumnName("SkillId")
          .ValueGeneratedNever();
      });

      jb.Navigation(x => x.Requirements).Metadata.SetField("_requirements");
      jb.Navigation(x => x.Requirements).UsePropertyAccessMode(PropertyAccessMode.Field);

    });

    builder.Metadata.FindNavigation(nameof(Employer.Jobs))!.SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}
using JobFinder.Domain.SkillAggregate;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Infrastructure.Persistence.Configurations;

public class SkillConfigurations : IEntityTypeConfiguration<Skill>
{
  public void Configure(EntityTypeBuilder<Skill> builder)
  {
    builder.HasKey("Id");

    builder.Property(t => t.Id)
      .HasColumnName("SkillId")
      .ValueGeneratedNever()
      .HasConversion(Id => Id.Value, Value => SkillId.Create(Value));

  }
}

using JobFinder.Domain.ResumeAggregate.ValueObjects;
using JobFinder.Domain.SkillAggregate.ValueObjects;
using JobFinder.Domain.UserAggregate;
using JobFinder.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobFinder.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    // change the table name to Users
    builder.ToTable("Users");

    builder.HasKey(t => t.Id);

    // define the identifier
    builder.Property(t => t.Id)
      .ValueGeneratedNever()
      .HasConversion(id => id.Value, value => UserId.Create(value));

    // other properties
    builder.Property(t => t.UserName).HasMaxLength(40);
    builder.Property(t => t.FullName).HasMaxLength(50);
    builder.Property(t => t.Password);
    builder.Property(t => t.Email).HasMaxLength(100);

    ConfigureResumesTable(builder);
  }

  public void ConfigureResumesTable(EntityTypeBuilder<User> builder)
  {

    // table splliting
    builder.OwnsMany(t => t.Resumes, rb =>
    {
      // set the table name to Resumes
      rb.ToTable("Resumes");

      // set the many to one relation between resumes and user
      // with shadow property of UserId
      rb.WithOwner().HasForeignKey("UserId");

      // define the primary key compose of Id and UserId together
      rb.HasKey("Id", "UserId");

      // change the primary key settings for this table
      rb.Property(t => t.Id)
        .HasColumnName("ResumeId")
        .ValueGeneratedNever()
        .HasConversion(id => id.Value, value => ResumeId.Create(value));

      rb.OwnsMany(t => t.Skills, sb =>
      {

        sb.Property(t => t.Value)
          .HasColumnName("SkillId")
          .ValueGeneratedNever();

      });

      rb.Navigation(r => r.Skills).Metadata.SetField("_skills");
      rb.Navigation(r => r.Skills).UsePropertyAccessMode(PropertyAccessMode.Field);

    });

    // tell the compiler that the Resumes is field and the underlying property is the _resumes
    // because the Resumes is IReadOnlyList type and cannot be changed or setted
    builder.Metadata.FindNavigation(nameof(User.Resumes))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);

  }
}

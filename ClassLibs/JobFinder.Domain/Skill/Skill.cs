using JobFinder.Domain.Common.Models;
using JobFinder.Domain.Skill.Enums;
using JobFinder.Domain.Skill.ValueObjects;

namespace JobFinder.Domain.Skill;

public sealed class Skill : AggregateRoot<SkillId>
{
    private Skill(
        SkillId Id,
        string SkillName,
        SkillRating SkillRating) : base(Id)
    {
      this.SkillName = SkillName;
      this.SkillRating = SkillRating;
    }

    public static Skill Create(string SkillName,
        SkillRating SkillRating)
    {
      return new(
          SkillId.CreateUnique(),
          SkillName,
          SkillRating);
    }

    public string SkillName { get; }
    public SkillRating SkillRating { get; }

}

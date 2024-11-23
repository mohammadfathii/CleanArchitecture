namespace JobFinder.Domain.SkillAggregate.ValueObjects;

using JobFinder.Domain.Common.Models;

public sealed class SkillId : ValueObject
{
  public Guid Value { get; set; }

  private SkillId(Guid value)
  {
    Value = value;
  }

  public static SkillId CreateUnique()
  {
    return new SkillId(Guid.NewGuid());
  }

  public static SkillId Create(Guid value){
    return new SkillId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}

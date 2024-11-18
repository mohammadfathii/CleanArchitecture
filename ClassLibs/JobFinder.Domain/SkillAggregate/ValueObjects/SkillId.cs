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
    return new(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}

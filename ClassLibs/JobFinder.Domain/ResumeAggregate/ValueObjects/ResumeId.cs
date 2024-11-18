namespace JobFinder.Domain.ResumeAggregate.ValueObjects;

using JobFinder.Domain.Common.Models;

public sealed class ResumeId : ValueObject
{
  public Guid Value { get; }

  private ResumeId(Guid value)
  {
    Value = value;
  }

  public static ResumeId CreateUnique()
  {
    return new(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
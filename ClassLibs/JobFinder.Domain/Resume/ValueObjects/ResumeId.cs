using JobFinder.Domain.Common.Models;

namespace JobFinder.Domain.Resume.ValueObjects;

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
using JobFinder.Domain.Common.Models;

namespace JobFinder.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
  public Guid Value { get; }

  private UserId(Guid value)
  {
    Value = value;
  }

  public static UserId CreateUnique()
  {
    return new(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
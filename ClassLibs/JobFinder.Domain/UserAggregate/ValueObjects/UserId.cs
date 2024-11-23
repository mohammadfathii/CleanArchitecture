namespace JobFinder.Domain.UserAggregate.ValueObjects;

using JobFinder.Domain.Common.Models;

public sealed class UserId : ValueObject
{
  public Guid Value { get; }

  private UserId(Guid value)
  {
    Value = value;
  }

  public static UserId CreateUnique()
  {
    return new UserId(Guid.NewGuid());
  }

  public static UserId Create(Guid value){
    return new UserId(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
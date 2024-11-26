using JobFinder.Domain.Common.Models;

namespace JobFinder.Domain.EmployerAggregate.ValueObjects;

public sealed class EmployerId : ValueObject
{
  public Guid Value { get; }

  private EmployerId(Guid value)
  {
    Value = value;
  }

  public static EmployerId CreateUnique()
  {
    return new(Guid.NewGuid());
  }

  public static EmployerId Create(Guid value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}

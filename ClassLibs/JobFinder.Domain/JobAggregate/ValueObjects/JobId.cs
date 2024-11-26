using JobFinder.Domain.Common.Models;

namespace JobFinder.Domain.JobAggregate.ValueObjects;

public sealed class JobId : ValueObject
{
    public Guid Value { get; }

    private JobId(Guid value)
    {
      Value = value;
    }

    public static JobId CreateUnique(){
      return new(Guid.NewGuid());
    }

    public static JobId Create(Guid value){
      return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

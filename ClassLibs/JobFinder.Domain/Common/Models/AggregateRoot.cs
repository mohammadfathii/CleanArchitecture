namespace JobFinder.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
  where TId : notnull
{
    protected AggregateRoot(TId Id) : base(Id)
    {

    }
}
namespace JobFinder.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
  where TId : notnull
{
    protected AggregateRoot(TId Id) : base(Id)
    {

    }

      #pragma warning disable CS8618
      protected AggregateRoot(){

      }
      #pragma warning restore CS8618

}
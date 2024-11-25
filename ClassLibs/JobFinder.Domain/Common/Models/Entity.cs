
namespace JobFinder.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
    where TId : notnull
{
    public TId Id { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected Entity(TId Id)
    {
        this.Id = Id;
    }

    public void AddToDomainEvents(IDomainEvent domainEvent){
        _domainEvents.Add(domainEvent);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && this.Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

#pragma warning disable CS8618
    protected Entity()
    {

    }
#pragma warning restore CS8618
}
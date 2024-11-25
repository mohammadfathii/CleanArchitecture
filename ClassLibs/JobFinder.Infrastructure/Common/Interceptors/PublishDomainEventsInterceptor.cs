using JobFinder.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobFinder.Infrastructure.Common.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
  private IPublisher _publisher;

  public PublishDomainEventsInterceptor(IPublisher publisher)
  {
    _publisher = publisher;
  }

  public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
  {
    PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
    return base.SavedChanges(eventData, result);
  }

  public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
  {
    await PublishDomainEvents(eventData.Context);
    return await base.SavedChangesAsync(eventData, result, cancellationToken);
  }

  private async Task PublishDomainEvents(DbContext? dbContext)
  {
    if (dbContext is null)
    {
      return;
    }
    // hold all the various entities with domain events
    var entitiesAndDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
      .Where(entry => entry.Entity.DomainEvents.Any())
      .Select(entry => entry.Entity).ToList();
    // hold all the various domain events
    var domainEvents = entitiesAndDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

    // clear domain events
    entitiesAndDomainEvents.ForEach(entry => entry.ClearDomainEvents());

    // publish domain events
    foreach (var domainEvent in domainEvents)
    {
      await _publisher.Publish(domainEvent);
    }
  }

}

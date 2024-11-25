using MediatR;

namespace JobFinder.Domain.Common.Models;

public interface IDomainEvent : INotification
{
    // Domain Events : are a Events that Triggeres When
    // there is change in database
    // And all the various domain events that
    // a single Aggregate have
    // if on of them get faield all of them be rolled back
}

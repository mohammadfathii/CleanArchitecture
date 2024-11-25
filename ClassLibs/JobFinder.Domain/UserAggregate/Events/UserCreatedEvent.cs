using JobFinder.Domain.Common.Models;

namespace JobFinder.Domain.UserAggregate.Events;

// call this event when ever a user created
public record UserCreatedEvent(User user) : IDomainEvent;

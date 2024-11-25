using JobFinder.Domain.UserAggregate.Events;
using MediatR;

namespace JobFinder.Application.User.Events;

public class DummyHandler : INotificationHandler<UserCreatedEvent>
{
  public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
  {
    Console.WriteLine("The Domain Event Invoked Successfully !");
    await Task.CompletedTask;
  }
}

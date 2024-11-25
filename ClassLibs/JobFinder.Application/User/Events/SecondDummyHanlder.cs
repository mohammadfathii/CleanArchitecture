using JobFinder.Domain.UserAggregate.Events;
using MediatR;

namespace JobFinder.Application.User.Events;


public class SecondDummyHanlder : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {

      Console.WriteLine("The Second Event Handler Invoked !");

      await Task.CompletedTask;
    }
}

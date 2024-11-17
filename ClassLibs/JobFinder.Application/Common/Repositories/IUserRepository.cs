using JobFinder.Domain.User;

namespace JobFinder.Application.Common.Repositories;

public interface IUserRepository
{
  Task<Domain.User.User> Create(Domain.User.User user);
}

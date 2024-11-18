namespace JobFinder.Application.Common.Interfaces;

using JobFinder.Domain.UserAggregate;

public interface ITokenGenerator
{

  string GenerateJWTToken(User user);
  string GenerateRefreshToken();
}

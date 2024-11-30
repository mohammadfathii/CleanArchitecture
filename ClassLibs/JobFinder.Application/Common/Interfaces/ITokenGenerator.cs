namespace JobFinder.Application.Common.Interfaces;

using JobFinder.Application.Common.Models;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.UserAggregate;

public interface ITokenGenerator
{

  string GenerateJWTToken(TokenGeneratorModel user);
  string GenerateUserToken(User user);
  string GenerateEmployerToken(Employer employer);
  string GenerateRefreshToken();
}

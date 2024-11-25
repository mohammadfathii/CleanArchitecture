using JobFinder.Application.Common.Interfaces;

namespace JobFinder.Infrastructure.Common.Services;

public class PasswordHasher : IPasswordHasher
{
  private readonly PasswordHasher _passwordHasher;

  public PasswordHasher(PasswordHasher passwordHasher)
  {
    _passwordHasher = passwordHasher;
  }

  public async Task<string> HashPassword(string password)
  {
    var hash = await _passwordHasher.HashPassword(password);
    return hash;
  }

  public async Task<bool> VerifyPassword(string hashedString, string password)
  {
    var verfiy = await _passwordHasher.VerifyPassword(hashedString, password);
    return verfiy;
  }
}

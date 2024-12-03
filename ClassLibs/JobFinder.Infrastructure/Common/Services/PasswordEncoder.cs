namespace JobFinder.Infrastructure.Common.Services;

using JobFinder.Application.Common.Interfaces;

public class PasswordEncoder : IPasswordEncoder
{
      public string HashPassword(string password)
      {
          var hash = BCrypt.Net.BCrypt.HashPassword(password);   
          return hash;
      }

      public bool VerifyPassword(string hashedString, string password)
      {
          var verfiy = BCrypt.Net.BCrypt.Verify(text : password,hash : hashedString);
          return verfiy;
      }
}

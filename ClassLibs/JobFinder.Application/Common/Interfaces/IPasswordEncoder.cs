namespace JobFinder.Application.Common.Interfaces;

public interface IPasswordEncoder
{
  string HashPassword(string password);
  bool VerifyPassword(string hashedString,string password);
}
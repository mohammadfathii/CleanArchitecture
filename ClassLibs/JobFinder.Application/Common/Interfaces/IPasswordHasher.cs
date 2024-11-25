namespace JobFinder.Application.Common.Interfaces;

public interface IPasswordHasher
{
  Task<string> HashPassword(string password);
  Task<bool> VerifyPassword(string hashedString,string password);
}
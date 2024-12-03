namespace JobFinder.Infrastructure.Common.Services;

using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Models;
using JobFinder.Domain.EmployerAggregate;
using JobFinder.Domain.UserAggregate;
using Microsoft.IdentityModel.Tokens;

public class TokenGenerator : ITokenGenerator
{
    public string GenerateEmployerToken(Employer employer)
    {
        return GenerateJWTToken(new TokenGeneratorModel()
        {
            Identifier = employer.Id.Value.ToString(),
            Email = employer.Email,
            Type = TokenGeneratorType.Employer,
        });
    }

    public string GenerateJWTToken(TokenGeneratorModel token)
    {
        var key = token.Type == TokenGeneratorType.User ? JwtSettings.UserSecretKey : JwtSettings.EmployerSecretKey;
        var issuer = token.Type == TokenGeneratorType.User ? JwtSettings.UserIssuer : JwtSettings.EmployerIssuer;

        var signingCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
          SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>(){
            new Claim(JwtRegisteredClaimNames.Sub,token.Identifier),
            new Claim(JwtRegisteredClaimNames.Email,token.Email),
        };

        var jwtSecurityToken = new JwtSecurityToken(
          audience: issuer,
          issuer: issuer,
          signingCredentials: signingCredentials,
          claims: claims,
          expires: DateTime.Now.AddDays(1));

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
  }

  public string GenerateRefreshToken()
  {
    var token = new byte[32];
    using (var rng = RandomNumberGenerator.Create())
    {
      rng.GetBytes(token);
    }
    return Convert.ToBase64String(token);
  }

    public string GenerateUserToken(User user)
    {
        return GenerateJWTToken(new TokenGeneratorModel()
        {
            Identifier = user.Id.Value.ToString(),
            Email = user.Email,
            Type = TokenGeneratorType.User,
        });
    }
}

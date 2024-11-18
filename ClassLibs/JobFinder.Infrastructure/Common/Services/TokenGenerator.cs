namespace JobFinder.Infrastructure.Common.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Domain.UserAggregate;
using Microsoft.IdentityModel.Tokens;

public class TokenGenerator : ITokenGenerator
{
  public string GenerateJWTToken(User user)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
      SecurityAlgorithms.HmacSha256
    );

    var claims = new List<Claim>(){
        new Claim(JwtRegisteredClaimNames.Sub,user.Id.Value.ToString()),
        new Claim(JwtRegisteredClaimNames.Email,user.Email),
        new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
    };

    var jwtSecurityToken = new JwtSecurityToken(
      audience: JwtSettings.Issuer,
      issuer: JwtSettings.Issuer,
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
}

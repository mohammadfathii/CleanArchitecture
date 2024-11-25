namespace JobFinder.Infrastructure;

using System.Text;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Repositories;
using JobFinder.Infrastructure.Common.Interceptors;
using JobFinder.Infrastructure.Common.Repositories;
using JobFinder.Infrastructure.Common.Services;
using JobFinder.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    var connectionString = "Server=localhost;DataBase=JobFinderCADDD;Trusted_Connection=True;TrustServerCertificate=True";

    services.AddScoped<PublishDomainEventsInterceptor>();
    services.AddDbContext<JobFinderDbContext>(options => options.UseSqlServer(connectionString));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ITokenGenerator,TokenGenerator>();

    services.AddAuthSettings();

    return services;
  }

  public static IServiceCollection AddAuthSettings(this IServiceCollection services)
  {
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters()
            {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = JwtSettings.Issuer,
              ValidAudience = JwtSettings.Issuer,
              IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey))
            });

    return services;
  }
}

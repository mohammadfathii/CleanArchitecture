namespace JobFinder.Infrastructure;

using System.Text;
using JobFinder.Application.Common.Interfaces;
using JobFinder.Application.Common.Repositories;
using JobFinder.Infrastructure.Common.Interceptors;
using JobFinder.Infrastructure.Common.Repositories;
using JobFinder.Infrastructure.Common.Services;
using JobFinder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    var connectionString = "Server=localhost;DataBase=JobFinderCADDD;Trusted_Connection=True;TrustServerCertificate=True";

    services.AddDbContext<JobFinderDbContext>(options => options.UseSqlServer(connectionString));

    #region Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IResumeRepository,ResumeRepository>();
    services.AddScoped<IEmployerRepository, EmployerRepository>();
    #endregion

    services.AddScoped<PublishDomainEventsInterceptor>();
    services.AddScoped<ITokenGenerator, TokenGenerator>();
    services.AddScoped<IPasswordEncoder, PasswordEncoder>();

    services.AddAuthSettings();

    return services;
  }

  public static IServiceCollection AddAuthSettings(this IServiceCollection services)
  {
    // User Scheme
        services.AddAuthentication()
            .AddJwtBearer("UserScheme",options =>
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = JwtSettings.UserIssuer,
                  ValidAudience = JwtSettings.UserIssuer,
                  IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.UserSecretKey))
                });

        // added Employer Scheme
        services.AddAuthentication()
            .AddJwtBearer("EmployerScheme", options =>
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtSettings.EmployerIssuer,
                    ValidAudience = JwtSettings.EmployerIssuer,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.EmployerSecretKey))
                });

        // added authorization policy role-based
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserRoleAdminPolicy", policy => policy.RequireClaim("Role", "Admin").AddAuthenticationSchemes("UserScheme"));
            options.AddPolicy("UserRoleOwnerPolicy", policy => policy.RequireClaim("Role", "Owner").AddAuthenticationSchemes("UserScheme"));
            options.AddPolicy("UserRoleSupervisorPolicy", policy => policy.RequireClaim("Role", "Supervisor").AddAuthenticationSchemes("UserScheme"));
        });


        return services;
    }
}

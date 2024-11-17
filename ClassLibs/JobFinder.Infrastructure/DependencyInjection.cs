using JobFinder.Application.Common.Repositories;
using JobFinder.Infrastructure.Common.Repositories;
using JobFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobFinder.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services){
    var connectionString = "Server=.;DataBase=JobFinder;Trsuted_Connection=True;TrustedServerCertificated=True";

    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    services.AddScoped<IUserRepository,UserRepository>();

    return services;
  }
}

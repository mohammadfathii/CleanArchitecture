namespace JobFinder.API;

public static class DepedencyInjection
{
  public static IServiceCollection AddWebAPI(this IServiceCollection services)
  {
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddAuthentication().AddBearerToken();

    return services;
  }
}

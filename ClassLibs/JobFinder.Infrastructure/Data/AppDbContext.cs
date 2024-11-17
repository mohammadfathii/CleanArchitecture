using Microsoft.EntityFrameworkCore;

namespace JobFinder.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

}

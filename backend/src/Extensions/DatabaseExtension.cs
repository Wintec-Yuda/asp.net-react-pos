using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;

namespace PointOfSale.Extensions;

public static class DatabaseExtension
{
  public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
  {
    // Mengonfigurasi koneksi ke PostgreSQL menggunakan variabel lingkungan
    var connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                            $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                            $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                            $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                            $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseNpgsql(connectionString);
    });
    return services;
  }
}
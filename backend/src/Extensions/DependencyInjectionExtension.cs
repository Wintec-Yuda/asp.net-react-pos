using PointOfSale.Repositories;
using PointOfSale.Repositories.Interfaces;
using PointOfSale.Services;
using PointOfSale.Services.Interfaces;

namespace PointOfSale.Extensions;

public static class DependencyInjectionExtension
{
  public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
  {
    services.AddScoped<IAuthRepository, AuthRepository>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<ITransactionRepository, TransactionRepository>();
    services.AddScoped<ITransactionService, TransactionService>();

    return services;
  }
}
using Microsoft.OpenApi.Models;

namespace TodoListApi.Extensions;
public static class SwaggerExtension
{
  public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
  {
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc("v1", new OpenApiInfo { Title = "POS Restful API", Version = "v1" });
    });

    return services;
  }
}

using dotenv.net;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Data;

var builder = WebApplication.CreateBuilder(args);

// Memuat file .env
DotEnv.Load();

// Mengonfigurasi koneksi ke PostgreSQL menggunakan variabel lingkungan
var connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                        $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                        $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                        $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                        $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

// Menambahkan koneksi PostgreSQL ke konteks database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

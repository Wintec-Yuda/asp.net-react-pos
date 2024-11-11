using dotenv.net;
using PointOfSale.Extensions;
using PointOfSale.Middlewares;
using TodoListApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Memuat file .env
DotEnv.Load();

// Menambahkan koneksi PostgreSQL ke konteks database
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RoleAuthorizationMiddleware>();

app.MapControllers()
.WithOpenApi();

app.Run();
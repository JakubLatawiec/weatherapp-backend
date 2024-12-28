using WeatherForecast.Application.Configurations;
using WeatherForecast.Infrastructure.Configurations;
using WeatherForecast.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Env
DotNetEnv.Env.Load();

// Add services to the container.

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .WithMethods("GET")
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

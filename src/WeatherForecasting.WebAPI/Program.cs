using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using WeatherForecasting.Infrastructure;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => 
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.ShortSchemaNames = true;
    });

builder.Services.AddWeatherForecasting();

var app = builder.Build();

app.UseDefaultExceptionHandler();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();

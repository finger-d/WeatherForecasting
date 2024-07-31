using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WeatherForecasting.Infrastructure")]
[assembly: InternalsVisibleTo("WeatherForecasting.Core.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace WeatherForecasting.Core
{
    public static class WeatherForecastingCoreConfigurator
    {
        public static IServiceCollection AddWeatherForecastingCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(WeatherForecastingCoreConfigurator).Assembly));

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeatherForecasting.Core;
using WeatherForecasting.Infrastructure.ApiClient;

namespace WeatherForecasting.Infrastructure;

public static class WeatherForecastingConfigurator
{
    public static IServiceCollection AddWeatherForecasting(this IServiceCollection services)
    {
        services.AddWeatherForecastingCore();

        services.AddOptions<OpenWeatherMapSettings>()
            .BindConfiguration("OpenWeatherMapSettings")
            .ValidateDataAnnotations();

        services.AddHttpClient<IWeatherService, OpenWeatherMapService>((serviceProvider, client) =>
        {
            var settings = serviceProvider
                .GetRequiredService<IOptions<OpenWeatherMapSettings>>().Value;

            client.BaseAddress = new Uri(settings.ApiUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        return services;
    }
}

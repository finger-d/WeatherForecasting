using WeatherForecasting.Core.Model;

namespace WeatherForecasting.Infrastructure;

internal interface IWeatherService
{
    Task<WeatherForecast?> GetForecastAsync(string city);
}
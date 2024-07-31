using WeatherForecasting.Core.Model;

namespace WeatherForecasting.Infrastructure;

internal interface IWeatherService
{
    Task<IEnumerable<DateWeatherForecast>> GetForecastAsync(string city);
}
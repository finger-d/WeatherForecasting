using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using WeatherForecasting.Core.Model;
using WeatherForecasting.Infrastructure.ApiClient.Model;

namespace WeatherForecasting.Infrastructure.ApiClient;

internal class OpenWeatherMapService : IWeatherService
{
    private readonly HttpClient _client;
    private readonly OpenWeatherMapSettings _settings;

    public OpenWeatherMapService(HttpClient client, IOptions<OpenWeatherMapSettings> settings)
    {
        _client = client;
        _settings = settings.Value;
    }

    public async Task<IEnumerable<DateWeatherForecast>> GetForecastAsync(string city)
    {
        var query = new Dictionary<string, string>
        {
            ["q"] = city,
            ["appid"] = _settings.ApiKey,
            ["units"] = _settings.Units
        };

        var uri = QueryHelpers.AddQueryString("", query);

        var response = await _client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<ForecastApiModel>();

            return responseModel.list.Select(x =>
                {
                    return new DateWeatherForecast
                    {
                        Date = DateTimeOffset.FromUnixTimeSeconds(x.dt).UtcDateTime,
                        Temperature = (decimal)x.main.temp,
                        Pressure = x.main.pressure,
                        Humidity = x.main.humidity,
                        WindSpeed = (decimal)x.wind.speed,
                        WeatherConditions = x.weather.FirstOrDefault()?.main
                    };
                }
            );
        }

        return [];
    }
}

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

    public async Task<WeatherForecast?> GetForecastAsync(string city)
    {
        var query = new Dictionary<string, string>
        {
            ["q"] = city,
            ["APPID"] = _settings.ApiKey
        };

        var uri = QueryHelpers.AddQueryString("", query);

        var response = await _client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var responseModel = await response.Content.ReadFromJsonAsync<Rootobject>();

            return new WeatherForecast
            {
                CurrentTemperature = (decimal)responseModel.main.temp,
                TemperatureMin = (decimal)responseModel.main.temp_min,
                TemperatureMax = (decimal)responseModel.main.temp_max
            };
        }

        return null;
    }
}

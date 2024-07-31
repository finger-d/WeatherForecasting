using System.ComponentModel.DataAnnotations;

namespace WeatherForecasting.Infrastructure;

internal class OpenWeatherMapSettings
{
    [Required]
    public string ApiUrl { get; set; }

    [Required]
    public string ApiKey { get; set; }

    public string Units { get; set; }
}


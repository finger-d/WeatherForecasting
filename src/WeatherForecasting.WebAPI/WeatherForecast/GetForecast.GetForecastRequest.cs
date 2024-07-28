namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecastRequest
{
    public const string Route = "/WeatherForecast";

    public string CityName { get; set; }
}


namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecastRequest
{
    public const string Route = "/WeatherForecast";

    public string City { get; set; }
    public DateOnly? Date { get; set; }
}


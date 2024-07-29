namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecastResponse
{
    public string City { get; set; }

    public GetForecastResponse(string city)
    {
        City = city;
    }
}

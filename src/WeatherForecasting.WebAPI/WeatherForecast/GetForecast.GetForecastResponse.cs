namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecastResponse
{
    public string CityName { get; set; }

    public GetForecastResponse(string cityName)
    {
        CityName = cityName;
    }
}

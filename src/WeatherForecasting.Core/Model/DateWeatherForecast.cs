namespace WeatherForecasting.Core.Model;

public class DateWeatherForecast
{
    public DateTime Date { get; set; }

    public decimal Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public decimal WindSpeed { get; set; }
    public string? WeatherConditions { get; set; }
}

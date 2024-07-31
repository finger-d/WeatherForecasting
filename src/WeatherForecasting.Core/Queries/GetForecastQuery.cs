using MediatR;
using WeatherForecasting.Core.Model;
using WeatherForecasting.Infrastructure;

namespace WeatherForecasting.Core.Queries;

public record GetForecastQuery(string City, DateOnly? Date) : IRequest<IEnumerable<DateWeatherForecast>>;

internal class GetForecastQueryHandler(IWeatherService service)
: IRequestHandler<GetForecastQuery, IEnumerable<DateWeatherForecast>>
{
    public async Task<IEnumerable<DateWeatherForecast>> Handle(GetForecastQuery request, CancellationToken cancellationToken)
    {
        var forecasts = await service.GetForecastAsync(request.City);

        if (request.Date.HasValue)
        {
            DateOnly filterDate = request.Date.Value;
            return forecasts.Where(f => f.Date.Date == filterDate.ToDateTime(TimeOnly.MinValue).Date);
        }
        else
        {
            DateTime todayUtc = DateTime.UtcNow.Date;
            return forecasts.Where(f => f.Date.Date == todayUtc);
        }
    }
}

using MediatR;
using WeatherForecasting.Core.Model;
using WeatherForecasting.Infrastructure;

namespace WeatherForecasting.Core.Queries;

public record GetForecastQuery(string City) : IRequest<WeatherForecast>;

internal class GetForecastQueryHandler(IWeatherService service)
: IRequestHandler<GetForecastQuery, WeatherForecast?>
{
    public async Task<WeatherForecast?> Handle(GetForecastQuery request, CancellationToken cancellationToken)
    {
        return await service.GetForecastAsync(request.City);
    }
}

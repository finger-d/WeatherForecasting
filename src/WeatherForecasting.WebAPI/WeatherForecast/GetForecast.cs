using FastEndpoints;
using MediatR;
using WeatherForecasting.Core.Model;
using WeatherForecasting.Core.Queries;

namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecast(IMediator _mediator)
    : Endpoint<GetForecastRequest, IEnumerable<DateWeatherForecast>>
{
    public override void Configure()
    {
        Get(GetForecastRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetForecastRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetForecastQuery(request.City, request.Date);

        Response = await _mediator.Send(query, cancellationToken);
    }
}


using FastEndpoints;
using MediatR;
using WeatherForecasting.Core.Queries;

namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecast(IMediator _mediator)
    : Endpoint<GetForecastRequest, Core.Model.WeatherForecast>
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
        var query = new GetForecastQuery(request.City);

        Response = await _mediator.Send(query, cancellationToken);
    }
}


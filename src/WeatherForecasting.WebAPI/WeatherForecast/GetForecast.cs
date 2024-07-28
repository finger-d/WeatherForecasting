using FastEndpoints;

namespace WeatherForecasting.WebAPI.WeatherForecast;

public class GetForecast()
    : Endpoint<GetForecastRequest, GetForecastResponse>
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
        Response = new GetForecastResponse(request.CityName);
    }
}


using FluentAssertions;
using NSubstitute;
using WeatherForecasting.Core.Model;
using WeatherForecasting.Core.Queries;
using WeatherForecasting.Infrastructure;

namespace WeatherForecasting.Core.Tests
{
    [TestFixture]
    public class GetForecastQueryHandlerTests
    {
        private IWeatherService _weatherService;
        private GetForecastQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _weatherService = Substitute.For<IWeatherService>();
            _handler = new GetForecastQueryHandler(_weatherService);
        }

        [Test]
        public async Task Handle_WhenDateIsProvided_ReturnsForecastsForSpecificDate()
        {
            // Arrange
            var city = "CityA";
            var date = new DateOnly(2024, 7, 30);
            var query = new GetForecastQuery(city, date);
            var forecast = new List<DateWeatherForecast>
            {
                new DateWeatherForecast { Date = new DateTime(2024, 7, 30), Temperature = 25 },
                new DateWeatherForecast { Date = new DateTime(2024, 7, 29), Temperature = 22 }
            };
            _weatherService.GetForecastAsync(city).Returns(forecast);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCount(1);
            result.First().Date.Should().Be(new DateTime(2024, 7, 30));
        }

        [Test]
        public async Task Handle_WhenDateIsNotProvided_ReturnsForecastsForToday()
        {
            // Arrange
            var city = "CityB";
            var today = DateTime.UtcNow.Date;
            var query = new GetForecastQuery(city, null);
            var forecast = new List<DateWeatherForecast>
            {
                new DateWeatherForecast { Date = today, Temperature = 20 },
                new DateWeatherForecast { Date = today.AddDays(1), Temperature = 18 }
            };
            _weatherService.GetForecastAsync(city).Returns(forecast);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCount(1);
            result.First().Date.Should().Be(today);
        }

        [Test]
        public async Task Handle_WhenForecastIsEmpty_ReturnsEmptyCollection()
        {
            // Arrange
            var city = "CityC";
            var date = new DateOnly(2024, 7, 30);
            var query = new GetForecastQuery(city, date);
            _weatherService.GetForecastAsync(city).Returns(Enumerable.Empty<DateWeatherForecast>());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
        }
    }
}


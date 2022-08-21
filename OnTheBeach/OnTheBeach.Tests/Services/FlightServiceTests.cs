using OnTheBeach.Services;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Tests.Services
{
    public class FlightServiceTests
    {
        private readonly IFlightService _flightService;

        public FlightServiceTests()
        {
            _flightService = new FlightService();
        }

        [Fact]
        public async void GetBestValueOrdered_Should_Return_Flights_Ordered_By_BestValue()
        {
            var result = await _flightService.GetBestValueOrdered(new List<string> { "MAN" }, "TFS", new DateTime(2023, 7, 1));

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var bestValue = result.First();
            Assert.Equal(1, bestValue.Id);
        }
    }
}

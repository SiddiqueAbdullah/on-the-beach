using Moq;
using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;
using OnTheBeach.Services;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Tests.Services
{
    public class FlightServiceTests
    {
        private readonly IFlightService _flightService;
        private readonly Mock<IFlightRepository> _flightRepositoryMock;

        public FlightServiceTests()
        {
            _flightRepositoryMock = new Mock<IFlightRepository>();
            _flightService = new FlightService(_flightRepositoryMock.Object);
        }

        [Fact]
        public async void GetBestValueOrdered_Should_Return_Flights_Ordered_By_BestValue()
        {
            _flightRepositoryMock
                .Setup(m => m.GetFilteredFlights(It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<DateTime?>()))
                .ReturnsAsync(new List<Flight> 
                {
                    new Flight
                    {
                        Id = 1,
                        Price = 500
                    },
                    new Flight
                    {
                        Id = 2,
                        Price = 300
                    },
                    new Flight
                    {
                        Id = 3,
                        Price = 900
                    },
                });

            var result = await _flightService.GetBestValueOrdered(new List<string> { "MAN" }, "TFS", new DateTime(2023, 7, 1));

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var bestValue = result.First();
            Assert.Equal(2, bestValue.Id);
        }
    }
}

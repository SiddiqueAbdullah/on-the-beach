using OnTheBeach.Data;
using OnTheBeach.Services;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Tests.Services
{
    public class HolidayServiceTests
    {
        private readonly IHolidayService _holidayService;

        private const string TravelingToMissingError = "TravelingTo cannot be null or empty";

        public HolidayServiceTests()
        {
            var flightRepository = new FlightRepository();
            var flightService = new FlightService(flightRepository);

            var hotelRepository = new HotelRepository();
            var hotelService = new HotelService(hotelRepository);

            _holidayService = new HolidayService(flightService, hotelService);
        }

        [Fact]
        public async void GetBestValue_Should_Return_Argument_Missing_Error_TravelingTo()
        {
            var result = await _holidayService.GetBestValue(new List<string> { "MAN" }, "", new DateTime(2023, 7, 1), 7);

            Assert.Equal(TravelingToMissingError, result.Error);
        }

        [Fact]
        public async void GetBestValue_Should_Return_BestValue_Holiday_Customer_1()
        {
            var result = await _holidayService.GetBestValue(new List<string> { "MAN" }, "AGP", new DateTime(2023, 7, 1), 7);

            Assert.True(string.IsNullOrEmpty(result.Error));
            Assert.NotNull(result.Holidays);
            Assert.NotEmpty(result.Holidays);

            var bestValue = result.Holidays.First();

            Assert.Equal(2, bestValue.Flight.Id);
            Assert.Equal(9, bestValue.Hotel.Id);
        }

        [Fact]
        public async void GetBestValue_Should_Return_BestValue_Holiday_Customer_2()
        {
            var result = await _holidayService.GetBestValue(new List<string> { "LGW", "LTN" }, "PMI", new DateTime(2023, 6, 15), 10);

            Assert.True(string.IsNullOrEmpty(result.Error));
            Assert.NotNull(result.Holidays);
            Assert.NotEmpty(result.Holidays);

            var bestValue = result.Holidays.First();

            Assert.Equal(6, bestValue.Flight.Id);
            Assert.Equal(5, bestValue.Hotel.Id);
        }

        [Fact]
        public async void GetBestValue_Should_Return_BestValue_Holiday_Customer_3()
        {
            var result = await _holidayService.GetBestValue(new List<string>(), "LPA", new DateTime(2022, 11, 10), 14);

            Assert.True(string.IsNullOrEmpty(result.Error));
            Assert.NotNull(result.Holidays);
            Assert.NotEmpty(result.Holidays);

            var bestValue = result.Holidays.First();

            Assert.Equal(7, bestValue.Flight.Id);
            Assert.Equal(6, bestValue.Hotel.Id);
        }

        [Fact]
        public async void GetBestValue_Should_Return_BestValue_Holiday_Customer_4()
        {
            var result = await _holidayService.GetBestValue(new List<string>(), "PMI", new DateTime(2023, 6, 15), 14);

            Assert.True(string.IsNullOrEmpty(result.Error));
            Assert.NotNull(result.Holidays);
            Assert.NotEmpty(result.Holidays);

            var bestValue = result.Holidays.First();

            Assert.Equal(6, bestValue.Flight.Id);
            Assert.Equal(3, bestValue.Hotel.Id);
        }
    }
}

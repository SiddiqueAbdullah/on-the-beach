using Moq;
using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;
using OnTheBeach.Services;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Tests.Services
{
    public class HotelServiceTests
    {
        private readonly IHotelService _hotelService;
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;

        public HotelServiceTests()
        {
            _hotelRepositoryMock = new Mock<IHotelRepository>();
            _hotelService = new HotelService(_hotelRepositoryMock.Object);
        }

        [Fact]
        public async void GetBestValueOrdered_Should_Return_Hotels_Ordered_By_BestValue()
        {
            _hotelRepositoryMock
                .Setup(m => m.GetFilteredHotels(It.IsAny<List<string>>(), It.IsAny<DateTime?>(), It.IsAny<int?>()))
                .ReturnsAsync(new List<Hotel>
                {
                    new Hotel
                    {
                        Id = 1,
                        PricePerNight = 500
                    },
                    new Hotel
                    {
                        Id = 2,
                        PricePerNight = 300
                    },
                    new Hotel
                    {
                        Id = 3,
                        PricePerNight = 900
                    },
                });

            var result = await _hotelService.GetBestValueOrdered(new List<string> { "MAN" }, new DateTime(2023, 7, 1), 7);

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var bestValue = result.First();
            Assert.Equal(2, bestValue.Id);
        }
    }
}

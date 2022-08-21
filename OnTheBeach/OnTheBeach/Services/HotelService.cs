using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> GetBestValueOrdered(List<string> localAirports, DateTime? date, int? duration)
        {
            var filteredHotels = await _hotelRepository.GetFilteredHotels(localAirports, date, duration);

            return filteredHotels.OrderBy(f => f.Price).ToList();
        }
    }
}

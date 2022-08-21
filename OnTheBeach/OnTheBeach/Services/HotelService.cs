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

        public Task<List<Hotel>> GetBestValueOrdered(List<string> localAirports, DateTime? date, int? duration)
        {
            throw new NotImplementedException();
        }
    }
}

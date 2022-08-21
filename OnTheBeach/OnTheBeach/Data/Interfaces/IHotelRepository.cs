using OnTheBeach.Models;

namespace OnTheBeach.Data.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetFilteredHotels(List<string> localAirports, DateTime? date, int? duration);
    }
}

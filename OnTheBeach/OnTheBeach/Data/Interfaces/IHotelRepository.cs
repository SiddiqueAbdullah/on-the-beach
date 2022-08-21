using OnTheBeach.Models;

namespace OnTheBeach.Data.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetFilteredHotels(List<string> arrivalAirports, DateTime? date, int? duration);
    }
}

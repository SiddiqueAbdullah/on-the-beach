using OnTheBeach.Models;

namespace OnTheBeach.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetBestValueOrdered(List<string> arrivalAirports, DateTime? date, int? duration);
    }
}

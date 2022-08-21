using OnTheBeach.Models;

namespace OnTheBeach.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetBestValueOrdered(List<string> localAirports, DateTime? date, int? duration);
    }
}

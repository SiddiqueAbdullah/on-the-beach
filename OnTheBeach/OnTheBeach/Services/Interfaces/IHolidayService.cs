using OnTheBeach.Models;

namespace OnTheBeach.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<HolidayResponse> GetBestValue(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration);
    }
}

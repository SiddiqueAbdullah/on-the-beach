using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class HolidayService : IHolidayService
    {
        public Task<HolidayResponse> GetBestValue(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            throw new NotImplementedException();
        }
    }
}

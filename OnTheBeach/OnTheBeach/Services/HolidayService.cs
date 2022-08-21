using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class HolidayService : IHolidayService
    {
        private const string TravelingToMissingError = "TravelingTo cannot be null or empty";

        public async Task<HolidayResponse> GetBestValue(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            var error = ValidateParameters(travelingTo);

            if (!string.IsNullOrEmpty(error))
            {
                return new HolidayResponse { Error = error };
            }

            return new HolidayResponse();
        }

        private string ValidateParameters(string travelingTo)
        {
            return string.IsNullOrEmpty(travelingTo) ? TravelingToMissingError : string.Empty;
        }
    }
}

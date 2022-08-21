using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IFlightService _flightService;
        private readonly IHotelService _hotelService;

        private const string TravelingToMissingError = "TravelingTo cannot be null or empty";

        public HolidayService(IFlightService flightService, IHotelService hotelService)
        {
            _flightService = flightService;
            _hotelService = hotelService;
        }

        public async Task<HolidayResponse> GetBestValue(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            var error = ValidateParameters(travelingTo);

            if (!string.IsNullOrEmpty(error))
            {
                return new HolidayResponse { Error = error };
            }

            var flights = await _flightService.GetBestValueOrdered(departingFrom, travelingTo, departureDate);
            var hotels = await _hotelService.GetBestValueOrdered(new List<string> { travelingTo }, departureDate, duration);

            var result = new HolidayResponse
            {
                Holidays = new List<Holiday>()
            };

            foreach(var flight in flights)
            {
                foreach(var hotel in hotels)
                {
                    result.Holidays.Add(new Holiday
                    {
                        Flight = flight,
                        Hotel = hotel
                    });
                }
            }

            result.Holidays = result.Holidays.OrderBy(h => h.TotalPrice).ToList();

            return result;
        }

        private string ValidateParameters(string travelingTo)
        {
            return string.IsNullOrEmpty(travelingTo) ? TravelingToMissingError : string.Empty;
        }
    }
}

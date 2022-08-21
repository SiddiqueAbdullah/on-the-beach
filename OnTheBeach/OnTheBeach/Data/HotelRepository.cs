using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;

namespace OnTheBeach.Data
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<List<Hotel>> GetFilteredHotels(List<string> arrivalAirports, DateTime? date, int? duration)
        {
            return Database.Hotels.Where(h => (date == null || date == h.ArrivalDate) && 
                                                (duration == null || duration == h.Nights) &&
                                                (arrivalAirports == null || !arrivalAirports.Any() || arrivalAirports.Intersect(h.LocalAirports).Any())).ToList();
        }
    }
}

using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;

namespace OnTheBeach.Data
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<List<Hotel>> GetFilteredHotels(List<string> localAirports, DateTime? date, int? duration)
        {
            return Database.Hotels.Where(h => (date == null || date == h.ArrivalDate) && 
                                                (duration == null || duration == h.Nights) &&
                                                (localAirports == null || !localAirports.Any() || localAirports.Intersect(h.LocalAirports).Any())).ToList();
        }
    }
}

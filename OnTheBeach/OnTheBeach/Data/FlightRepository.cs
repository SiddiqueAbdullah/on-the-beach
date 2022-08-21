using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;

namespace OnTheBeach.Data
{
    public class FlightRepository : IFlightRepository
    {
        public async Task<List<Flight>> GetFilteredFlights(List<string> from, string to, DateTime? date)
        {
            return Database.Flights.Where(f => (from == null || !from.Any() || from.Contains(f.DepartingFrom)) && 
                                                (string.IsNullOrEmpty(to) || to == f.TravalingTo) && 
                                                (date == null || date == f.Date)).ToList();
        }
    }
}

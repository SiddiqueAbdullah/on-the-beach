using OnTheBeach.Models;

namespace OnTheBeach.Data.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetFilteredFlights(List<string> from, string to, DateTime? date);
    }
}

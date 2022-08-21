using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class FlightService : IFlightService
    {
        public Task<List<Flight>> GetBestValueOrdered(List<string> from, string to, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

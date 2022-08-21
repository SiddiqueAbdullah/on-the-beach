using OnTheBeach.Data.Interfaces;
using OnTheBeach.Models;
using OnTheBeach.Services.Interfaces;

namespace OnTheBeach.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<Flight>> GetBestValueOrdered(List<string> from, string to, DateTime date)
        {
            var filteredFlights = await _flightRepository.GetFilteredFlights(from, to, date);

            return filteredFlights.OrderBy(f => f.Price).ToList();
        }
    }
}

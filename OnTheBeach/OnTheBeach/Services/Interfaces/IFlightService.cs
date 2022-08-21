using OnTheBeach.Models;

namespace OnTheBeach.Services.Interfaces
{
    public interface IFlightService
    {
        Task<List<Flight>> GetBestValueOrdered(List<string> from, string to, DateTime date);
    }
}

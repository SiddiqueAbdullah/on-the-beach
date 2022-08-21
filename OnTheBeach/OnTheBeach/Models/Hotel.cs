using Newtonsoft.Json;

namespace OnTheBeach.Models
{
    public class Hotel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "arrival_date")]
        public DateTime ArrivalDate { get; set; }

        [JsonProperty(PropertyName = "price_per_night")]
        public decimal PricePerNight { get; set; }

        [JsonProperty(PropertyName = "local_airports")]
        public List<string> LocalAirports { get; set; }

        [JsonProperty(PropertyName = "nights")]
        public int Nights { get; set; }
    }
}

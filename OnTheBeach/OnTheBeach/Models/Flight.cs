using Newtonsoft.Json;

namespace OnTheBeach.Models
{
    public class Flight
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "airline")]
        public string Airline { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string DepartingFrom { get; set; }

        [JsonProperty(PropertyName = "to")]
        public string TravalingTo { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "departure_date")]
        public DateTime Date { get; set; }
    }
}

namespace OnTheBeach.Models
{
    public class Holiday
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice 
        { 
            get 
            { 
                return Flight.Price + Hotel.Price; 
            } 
        }
    }
}

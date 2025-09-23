using System;


namespace AVi.Models
{
    public class SearchParametrs
    {
        public string FromCity { get; set; } = string.Empty;
        public string ToCity { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string FlightClass { get; set; } = "Эконом";
    }
}

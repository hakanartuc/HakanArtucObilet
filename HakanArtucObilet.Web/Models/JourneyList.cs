using System;

namespace HakanArtucObilet.Web.Models
{
    public class JourneyList
    {
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }        
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }

    }
}

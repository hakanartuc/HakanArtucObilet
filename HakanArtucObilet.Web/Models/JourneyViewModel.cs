using System;
using System.Collections.Generic;

namespace HakanArtucObilet.Web.Models
{
    public class JourneyViewModel : BaseViewModel
    {
        public JourneyViewModel()
        {
            Journeys = new List<JourneyList>();
        }
        
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }

        public List<JourneyList> Journeys { get; set; }

    }

    
}

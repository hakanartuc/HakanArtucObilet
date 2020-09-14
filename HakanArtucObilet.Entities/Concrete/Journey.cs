using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
   public class Journey
    {
        public Journey()
        {
            Stops = new List<Stop>();
            Policy = new Policy();
        }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("duration")]
        public TimeSpan? Duration { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }

        [JsonProperty("booking")]
        public string[] Booking { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("policy")]
        public Policy Policy { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        //Api de var ama dokümanda karşılığını göremedim
        [JsonProperty("available")]
        public bool? Available { get; set; }


    }
}

using HakanArtucObilet.Entities.Abstract;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
    public class BusLocation : EntityBase
    {
        public BusLocation()
        {
            GeoLocation = new GeoLocation();
        }

        [JsonProperty("parent-id")]
        public int? ParentId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tz-code")]
        public string TzCode { get; set; }

        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public string ReferenceCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

    }
}
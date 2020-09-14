using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        //api den dönen cevapta BusLocation için bir zoom nesnesi daha var neden? (Dokümanda tek gözüküyor)
        [JsonProperty("zoom")]
        public string Zoom { get; set; }
    }
}

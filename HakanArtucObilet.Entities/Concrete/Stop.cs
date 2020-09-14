using System;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
   public class Stop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public int? Station { get; set; }

        //dokümanda datetime ve string olarak geçiyor
        [JsonProperty("time")]
        public DateTime? Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}

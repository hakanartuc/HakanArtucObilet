using HakanArtucObilet.Entities.Abstract;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
    public class Feature : EntityBase
    {
        [JsonProperty("priority")]
        public byte? Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("back-color")]
        public string BackColor { get; set; }

        [JsonProperty("fore-color")]
        public string ForeColor { get; set; }
    }
}

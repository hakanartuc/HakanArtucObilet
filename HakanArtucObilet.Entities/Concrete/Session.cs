using HakanArtucObilet.Core.Entities;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Concrete
{
  public  class Session : IEntity
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        [JsonProperty("affiliate")]
        public string Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }
    }
}

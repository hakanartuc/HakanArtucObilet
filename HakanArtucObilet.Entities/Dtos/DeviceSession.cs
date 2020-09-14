using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Dtos
{
   public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}

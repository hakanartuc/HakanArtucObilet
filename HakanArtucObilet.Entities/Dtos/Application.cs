using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Dtos
{
   public class Application
    {
        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
        public string Version { get; set; }
    }
}

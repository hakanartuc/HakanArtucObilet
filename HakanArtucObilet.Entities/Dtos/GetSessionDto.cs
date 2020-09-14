using HakanArtucObilet.Core.Entities;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Dtos
{
    public class GetSessionDto :BaseDto, IApiDto
    {
        public GetSessionDto()
        {
            Connection = new Connection();
            Application = new Application();
        }
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public object Data { get; set; }
    }
}
using System;
using HakanArtucObilet.Core.Entities;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Dtos
{
    public class BaseApiDto : BaseDto, IApiDto
    {
        public object Data { get; set; }

        [JsonProperty("device-session")] public DeviceSession DeviceSession { get; set; }
        public DateTime Date => DateTime.Now;
        public string Language => "tr-TR";
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
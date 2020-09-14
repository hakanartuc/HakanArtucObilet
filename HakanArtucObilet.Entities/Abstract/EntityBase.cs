using HakanArtucObilet.Core.Entities;
using Newtonsoft.Json;

namespace HakanArtucObilet.Entities.Abstract
{
    public abstract  class EntityBase : IEntity
    {
        //Dokümanda BusLocation için id int gözüküyorken Journey için string denmiş.
        //Ama dönen id ler ikisi için de int dokümanda bir yanlışlık olabilir.
        //Her ihtimale karşı ikisini de karşılaması için string yapıldı.
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

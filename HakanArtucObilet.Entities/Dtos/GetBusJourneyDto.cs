using System;

namespace HakanArtucObilet.Entities.Dtos
{
   public class GetBusJourneyDto : BaseApiDto
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

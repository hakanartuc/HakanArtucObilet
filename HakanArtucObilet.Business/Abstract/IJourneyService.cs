using System.Collections.Generic;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Abstract
{
   public interface IJourneyService
    {
        IDataResult<IEnumerable<BusJourneys>> GetBusJourneys(GetBusJourneyDto busJourneyDto);
    }
}

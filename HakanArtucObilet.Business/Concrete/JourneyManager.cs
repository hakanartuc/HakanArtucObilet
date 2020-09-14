using System.Collections.Generic;
using HakanArtucObilet.Business.Abstract;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Concrete
{
   public class JourneyManager : IJourneyService
   {
       private readonly IJourneyDal _journeyDal;

       public JourneyManager(IJourneyDal journeyDal)
       {
           _journeyDal = journeyDal;
       }

       public IDataResult<IEnumerable<BusJourneys>> GetBusJourneys(GetBusJourneyDto busJourneyDto)
        {
            return _journeyDal.GetBusJourneys(busJourneyDto);
        }
    }
}

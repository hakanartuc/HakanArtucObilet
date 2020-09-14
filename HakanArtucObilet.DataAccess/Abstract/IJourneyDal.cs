using System.Collections.Generic;
using HakanArtucObilet.Core.DataAccess;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Abstract
{
   public interface IJourneyDal : IEntityRepository<BaseDto>
    {
        IDataResult<IEnumerable<BusJourneys>> GetBusJourneys(GetBusJourneyDto dto);
    }
}

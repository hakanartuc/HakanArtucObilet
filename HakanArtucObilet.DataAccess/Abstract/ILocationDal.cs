using System.Collections.Generic;
using HakanArtucObilet.Core.DataAccess;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Abstract
{
    public interface ILocationDal : IEntityRepository<BaseDto>
    {
        IDataResult<IEnumerable<BusLocation>> GetBusLocations(GetBusLocationDto apiDto);
    }
}

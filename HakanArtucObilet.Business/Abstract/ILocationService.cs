using System.Collections.Generic;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Abstract
{
  public  interface ILocationService
  {
      IDataResult<IEnumerable<BusLocation>> GetBusLocations(GetBusLocationDto busLocationDto);
  }
}

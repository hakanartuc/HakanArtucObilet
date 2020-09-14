using System.Collections.Generic;
using HakanArtucObilet.Business.Abstract;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Concrete
{
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public IDataResult<IEnumerable<BusLocation>> GetBusLocations(GetBusLocationDto busLocationDto)
        {
           return  _locationDal.GetBusLocations(busLocationDto);
        }
    }
}

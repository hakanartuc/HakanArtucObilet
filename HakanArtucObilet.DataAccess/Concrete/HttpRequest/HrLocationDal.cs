using System.Collections.Generic;
using HakanArtucObilet.Core.DataAccess.HttpRequest;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.DataAccess.Concrete.HttpRequest.Contexts;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Concrete.HttpRequest
{
  public  class HrLocationDal : HrEntityRepositoryBase<BusLocation,BaseDto, HttpRequestContext>,ILocationDal
    {
        public IDataResult<IEnumerable<BusLocation>> GetBusLocations(GetBusLocationDto dto)
        {
            var apiDto = new BaseApiDto
            {
                Controller = "location",
                Action = "getbuslocations",
                Data = dto.Location,
                DeviceSession = dto.DeviceSession
            };

            var busLocations = GetList(apiDto);

            return (DataResult<IEnumerable<BusLocation>>)busLocations;
        }

     
    }
}

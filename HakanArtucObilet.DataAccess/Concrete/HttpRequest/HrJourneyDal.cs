using System.Collections.Generic;
using HakanArtucObilet.Core.DataAccess.HttpRequest;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.DataAccess.Concrete.HttpRequest.Contexts;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Concrete.HttpRequest
{
   public class HrJourneyDal : HrEntityRepositoryBase<BusJourneys, BaseDto, HttpRequestContext>, IJourneyDal
    {
        public IDataResult<IEnumerable<BusJourneys>> GetBusJourneys(GetBusJourneyDto dto)
        {
            var apiDto = new BaseApiDto
            {
                Controller = "journey",
                Action = "getbusjourneys",
                Data = dto,
                DeviceSession = dto.DeviceSession
            };

            var busJourneys = GetList(apiDto);

            return (DataResult<IEnumerable<BusJourneys>>)busJourneys;

        }
      
    }
}

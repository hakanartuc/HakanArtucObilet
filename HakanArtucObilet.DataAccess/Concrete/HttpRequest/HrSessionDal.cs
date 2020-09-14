using HakanArtucObilet.Core.DataAccess.HttpRequest;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.DataAccess.Concrete.HttpRequest.Contexts;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Concrete.HttpRequest
{
   public class HrSessionDal : HrEntityRepositoryBase<Session, BaseDto, HttpRequestContext>,ISessionDal
    {
        public IDataResult<Session> GetSession(GetSessionDto sessionDto)
        {
            sessionDto.Controller = "client";
            sessionDto.Action = "getsession";

            var session = Get(sessionDto);

            return (DataResult<Session>)session;
        }

        
    }
}

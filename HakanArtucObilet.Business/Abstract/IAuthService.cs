using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<Session> GetSession(GetSessionDto sessionDto);
   }
}

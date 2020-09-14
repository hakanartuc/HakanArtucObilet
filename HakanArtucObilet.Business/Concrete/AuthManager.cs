using HakanArtucObilet.Business.Abstract;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.DataAccess.Abstract;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ISessionDal _sessionDal;

        public AuthManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }


        public IDataResult<Session> GetSession(GetSessionDto sessionDto)
        {            
            return _sessionDal.GetSession(sessionDto);
        }
    }
}
using HakanArtucObilet.Core.DataAccess;
using HakanArtucObilet.Core.Utilities.Results;
using HakanArtucObilet.Entities.Concrete;
using HakanArtucObilet.Entities.Dtos;

namespace HakanArtucObilet.DataAccess.Abstract
{
    public interface ISessionDal : IEntityRepository<BaseDto>
    {
        IDataResult<Session> GetSession(GetSessionDto dto);
    }
}
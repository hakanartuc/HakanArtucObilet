using System.Collections.Generic;
using HakanArtucObilet.Core.Entities;
using HakanArtucObilet.Core.Utilities.Results;

namespace HakanArtucObilet.Core.DataAccess
{
    /// <summary>
    /// Veriye erişim işlemlerini bağımlılık olmadan tasarlamak amacıyla yarattığımız interface
    /// Kendisini implement alan class gerekli işlemleri istenen yöntem ile sağlamalı.
    /// Şuan HttpClient üzerinden api request yapıyoruz, fakat yarın tamamını veya bir kısmını SQL e geçirmek istersek HrEntityRepositoryBase benzeri class implement edip kullanmamız yetecektir.
    /// Böylece mevcut kodu bozmayıp üstüne ekleme yapıp istenen zamanda yöntem değişikliğine gidebiliyor olacağız.
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IEntityRepository<TDto> where TDto : class, new()
    {
        IDataResult<IEntity> Get(TDto dto);
        IDataResult<IEnumerable<IEntity>> GetList(TDto dto);
    }
}
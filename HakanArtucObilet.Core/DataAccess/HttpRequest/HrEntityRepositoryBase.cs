using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using HakanArtucObilet.Core.Entities;
using HakanArtucObilet.Core.Utilities;
using HakanArtucObilet.Core.Utilities.Results;
using Newtonsoft.Json;

namespace HakanArtucObilet.Core.DataAccess.HttpRequest
{
    /// <summary>
    /// Temelde IEntityRepository implement eden classımız. Gelen nesneler ve HttpClient a göre apiye istek yapıyor.      
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="THttpClient"></typeparam>
    public class HrEntityRepositoryBase<TEntity, TDto, THttpClient> : IEntityRepository<TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
        where THttpClient : class, IHttpClientFactory, new()

    {
        public IDataResult<IEntity> Get(TDto dto)
        {
            using (var client = new THttpClient().CreateClient())
            {
                var apiDto = (IApiDto)dto;
                var json = JsonConvert.SerializeObject(dto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = $"{ConstValues.API_URL}{apiDto.Controller}/{apiDto.Action}";
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ConstValues.API_TOKEN);
                var response = client.PostAsync(url, data).Result;

                if (!response.IsSuccessStatusCode) return new ErrorDataResult<TEntity>(null, ConstValues.API_REQUEST_FAILED);

                var result = response.Content.ReadAsStringAsync().Result;
                var resultDeserialized = JsonConvert.DeserializeObject<HttpApiResult<TEntity>>(result);

                DataResult<TEntity> entity;
                if (resultDeserialized.Status == ConstValues.SUCCESS)
                {
                    entity = new SuccessDataResult<TEntity>(resultDeserialized.Data, resultDeserialized.UserMessage);
                }
                else
                {
                    entity = new ErrorDataResult<TEntity>(resultDeserialized.Data, resultDeserialized.UserMessage);
                }

                return entity;

            }
        }

        public IDataResult<IEnumerable<IEntity>> GetList(TDto dto)
        {
            using (var client = new THttpClient().CreateClient())
            {
                var apiDto = (IApiDto)dto;
                var json = JsonConvert.SerializeObject(dto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = $"{ConstValues.API_URL}{apiDto.Controller}/{apiDto.Action}";
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", ConstValues.API_TOKEN);
                var response = client.PostAsync(url, data).Result;

                if (!response.IsSuccessStatusCode) return new ErrorDataResult<IEnumerable<IEntity>>(null, ConstValues.API_REQUEST_FAILED);

                var result = response.Content.ReadAsStringAsync().Result;
                var resultDeserialized = JsonConvert.DeserializeObject<HttpApiResult<IEnumerable<TEntity>>>(result);

                DataResult<IEnumerable<TEntity>> entity;
                if (resultDeserialized.Status == ConstValues.SUCCESS)
                {
                    entity = new SuccessDataResult<IEnumerable<TEntity>>(resultDeserialized.Data, resultDeserialized.UserMessage);
                }
                else
                {
                    entity = new ErrorDataResult<IEnumerable<TEntity>>(resultDeserialized.Data, resultDeserialized.UserMessage);
                }

                return entity;
            }
        }
    }
}
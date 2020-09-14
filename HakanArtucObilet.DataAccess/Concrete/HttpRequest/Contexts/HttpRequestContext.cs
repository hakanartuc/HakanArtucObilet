using System.Net.Http;

namespace HakanArtucObilet.DataAccess.Concrete.HttpRequest.Contexts
{
    public class HttpRequestContext : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient();
        }

    }
}

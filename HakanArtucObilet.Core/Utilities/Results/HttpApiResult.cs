namespace HakanArtucObilet.Core.Utilities.Results
{
    public class HttpApiResult<T> 
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }
        public string ApiRequestId { get; set; }
        public string Controller { get; set; }
        public string ClientRequestId { get; set; }
    }
}

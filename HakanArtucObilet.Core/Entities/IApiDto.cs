namespace HakanArtucObilet.Core.Entities
{
    public interface IApiDto : IDto
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public object Data { get; set; }
    }
}
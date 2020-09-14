namespace HakanArtucObilet.Core.Utilities
{
    /// <summary>
    /// Const değişkenlerimizi barındıran class. Magic string yapmamak için değerleri buraya tanımlayıp çekiyoruz
    /// </summary>
    public static class ConstValues
    {
        public const string COOKIE_LAST_JOURNEY = "LastJourney";

        public const string SESSION_API_KEY = "ApiSession";

        public const string SUCCESS = "Success";

        public const string API_REQUEST_FAILED = "Request Failed";

        //Bunları normalde appsettings vs bir dış kaynaktan çekmek daha doğru olabilir şuanlık burda
        public const string API_URL = "https://v2-api.obilet.com/api/";
        public const string API_TOKEN = "YOUR_OBILET_API_TOKEN";
    }
}

using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HakanArtucObilet.Web.Helpers
{
    public static class CookieExtensions
    {
        public static void SetCookieObjectAsJson(this HttpContext httpContext, string key, object value)
        {
            CookieOptions option = new CookieOptions {Expires = DateTime.Now.AddMonths(1)};
            httpContext.Response.Cookies.Append(key, JsonConvert.SerializeObject(value), option);
        }

        public static T GetCookieObjectFromJson<T>(this HttpContext httpContext, string key)
        {
            if (!httpContext.Request.Cookies.ContainsKey(key)) return default(T);

            var cookie= httpContext.Request.Cookies[key];
            return JsonConvert.DeserializeObject<T>(cookie);

        }
    }
}

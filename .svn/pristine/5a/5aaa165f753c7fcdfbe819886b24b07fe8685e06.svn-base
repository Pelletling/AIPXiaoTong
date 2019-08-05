using Framework.Security;
using System;
using System.Web;

namespace Framework.Common
{
    public class CookieHelper
    {
        private static string cookieKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["CookieKey"] as string; }
        }

        public static string GetCookie(string cookieKey)
        {
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request.Cookies[cookieKey] != null)
                return System.Web.HttpContext.Current.Request.Cookies[cookieKey].Value;
            else if (HttpRuntime.Cache.Get(cookieKey) != null)
                return HttpRuntime.Cache.Get(cookieKey).ToString();
            else
                return null;
        }

        [Obsolete]
        public static void SetCooke(string Key, string value, long seconds = 0)
        {
            HttpCookie cook = new HttpCookie(Key);
            cook.Value = value;
            if (seconds != 0)
            {
                cook.Expires = DateTime.Now.AddSeconds(seconds);
            }
            System.Web.HttpContext.Current.Response.Cookies.Add(cook);
        }

        public static void SetCookie(string Key, string value, long seconds = 0)
        {
            HttpCookie cook = new HttpCookie(Key);
            cook.Value = value;
            if (seconds != 0)
            {
                cook.Expires = DateTime.Now.AddSeconds(seconds);
            }
            System.Web.HttpContext.Current.Response.Cookies.Add(cook);
        }

        public static string DecryptCookie(string str)
        {
            var base64 = Crypt.Decrypt(str, cookieKey);

            string result = Base64Encoding.DecodeBase64(base64);

            return result;
        }

        public static string EncryptCookie(string value)
        {
            var base64 = Base64Encoding.EncodeBase64(value);

            return Crypt.Encrypt(base64, cookieKey);
        }

    }
}

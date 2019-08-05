using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Common
{
    public class SessionHelper
    {
        public static void Clear(string key)
        {
            HttpContext.Current?.Session?.Remove(key);
        }

        public static void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static object GetSession(string name)
        {
            return HttpContext.Current?.Session?[name];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace Framework.Cache
{
    //public static class CacheHelper
    //{
    //    static ObjectCache cache;

    //    static CacheHelper()
    //    {
    //        cache = new ObjectCache();
    //    }
    //    public static void SetCache(string key, string value)
    //    {
    //        var policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(10) };
    //        cache.Set(key, value, policy);
    //    }

    //    public static void SetCache(string key, string value, DateTimeOffset datetime)
    //    {
    //        var policy = new CacheItemPolicy() { AbsoluteExpiration = datetime };
    //        cache.Set(key, value, policy);
    //    }

    //    public static string GetCache(string key)
    //    {
    //        string value = cache[key] as string;
    //        return value;
    //    }
    //}

    public sealed class CacheHelper
    {
        private static ObjectCache cache = MemoryCache.Default;
        private static CacheHelper _instance = null;
        private static readonly object SynObject = new object();

        CacheHelper()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static CacheHelper Instance
        {
            get
            {
                // Syn operation.
                lock (SynObject)
                {
                    return _instance ?? (_instance = new CacheHelper());
                }
            }
        }

        public static void SetCache(string key, object value)
        {
            var policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(10) };
            cache.Set(key, value, policy);
        }

        public static void SetCache(string key, object value, DateTimeOffset datetime)
        {
            var policy = new CacheItemPolicy() { AbsoluteExpiration = datetime };
            cache.Set(key, value, policy);
        }

        public static object GetCache(string key)
        {
            return cache[key]; 
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        public static bool CleanCache()
        {
            try
            {
                foreach (var c in cache)
                {
                    cache.Remove(c.Key);
                }
                return true;
            }
            catch
            {
                return false ;
            }
        }
    }
}

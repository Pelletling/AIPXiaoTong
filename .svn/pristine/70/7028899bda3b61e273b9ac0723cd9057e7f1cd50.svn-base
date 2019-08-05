using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.Common
{
   public static class StreamHelper
    {
        /// <summary>
        /// InputStream转String
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string InputStreamToString(this Stream stream)
        { 
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);

            string str = sr.ReadToEnd();

            return str;
        }
    }
}

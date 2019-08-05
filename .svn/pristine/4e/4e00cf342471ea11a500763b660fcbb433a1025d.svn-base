using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Common
{
    public class HTMLHelper
    {
        public static string VirtualPath(string path)
        {
            var VirtualPath = HttpRuntime.AppDomainAppVirtualPath;
            if (VirtualPath == "/")
            {
                VirtualPath = "";
            }
            return VirtualPath + path;
        }
         
    }
}

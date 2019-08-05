﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace PingAnAPI
{
    public class PingAnConfig
    {
        public static string url { get; set; }
        public static string returnUrl { get; set; }
        public static string sha1Key { get; set; }
        public static string redirectUrl { get; set; }
        public static string privateKey { get; set; }      
        public static string publicKey { get; set; }
        public static string autoLoginUrl { get; set; }
        public static string autoLoginPublicKey { get; set; }

    }
}
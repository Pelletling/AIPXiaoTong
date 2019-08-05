using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TltApi
{
    public class TltConfig
    {
        public static string _privateKey, _publicKey;

        public static string url { get; set; }
        public static string privateKeyPassword { get; set; }
        public static string userName { get; set; }
        public static string userPassword { get; set; }
        public static string merchantId{ get; set; }

        public static string privateKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_privateKey))
                    return AppDomain.CurrentDomain.BaseDirectory + @"Tlt\" + userName + ".p12";
                else
                    return _privateKey;
            }

            set
            {
                _privateKey = value;
            }
        }
        public static string publicKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_publicKey))
                    return AppDomain.CurrentDomain.BaseDirectory + @"Tlt\" + userName + ".cer";
                else
                    return _publicKey;
            }

            set
            {
                _publicKey = value;
            }
        }
    }
}

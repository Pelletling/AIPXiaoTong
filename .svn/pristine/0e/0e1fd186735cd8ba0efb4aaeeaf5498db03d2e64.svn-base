using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class AuthenticationToOpenAccountCheckResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 电子账号
            /// </summary>
            [XmlElement("EAcNo")]
            public string EAcNo { get; set; }

            /// <summary>
            /// II、III类户标志位（0-II类账户，1-III类账户）
            /// </summary>
            [XmlElement("AccountFlag")]
            public string AccountFlag { get; set; }            
        }
    }
}
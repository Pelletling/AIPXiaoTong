using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class AuthenticationToOpenAccountResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 合作伙伴交易请求流水号（唯一标识）
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 交易所属日期
            /// </summary>
            [XmlElement("BookDate")]
            public string BookDate { get; set; }

            /// <summary>
            /// 交易受理状态 （S-已受理，F-受理失败）
            /// </summary>
            [XmlElement("State")]
            public string State { get; set; }            
        }
    }
}
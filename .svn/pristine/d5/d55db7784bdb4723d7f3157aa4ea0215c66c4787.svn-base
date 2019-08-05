using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class QueryFreezeCombinationResponse : BaseResponse
    {
       
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 总笔数
            /// </summary>
            [XmlElement("Count")]
            public string Count { get; set; }

            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 列表
            /// </summary>
            [XmlElement("List")]
            public List<FreezeList> List { get; set; }
            public class FreezeList
            {
                public string FreezeNo { get; set; }
                public string TransDate { get; set; }

                public string TransTime { get; set; }
                public string FreezeType { get; set; }
                public string AcNoType { get; set; }
                public string ClientAcNo { get; set; }
                public string CustomZhName { get; set; }
                public string AcNo { get; set; }
                public string FreezeAmount { get; set; }
                public string IsCheck { get; set; }
                public string StartDate { get; set; }
                public string UnfreezeDate { get; set; }
            }

        }
    }
}
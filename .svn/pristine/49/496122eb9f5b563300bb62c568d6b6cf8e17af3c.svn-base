using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BTrsVeriAmountResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 合作伙伴交易请求流水号
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 交易状态（0：成功、1：失败、2：未明 3:超出查证时间范围）
            /// </summary>
            [XmlElement("TrsState")]
            public string TrsState { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            [XmlElement("Reserve1")]
            public string Reserve1 { get; set; }

            /// <summary>
            /// 预留字段
            /// </summary>
            [XmlElement("Reserve2")]
            public string Reserve2 { get; set; }
            
        }
    }
}
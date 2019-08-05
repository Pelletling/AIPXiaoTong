using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class EComGAmountResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 提现金额
            /// </summary>
            [XmlElement("Amount")]
            public decimal Amount { get; set; }

            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 币种
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 提现流水号
            /// </summary>
            [XmlElement("ChannelSeq")]
            public string ChannelSeq { get; set; }

            /// <summary>
            /// 客户姓名
            /// </summary>
            [XmlElement("CifName")]
            public string CifName { get; set; }

            /// <summary>
            /// 收款方银行账号
            /// </summary>
            [XmlElement("WDAcNo")]
            public string WDAcNo { get; set; }

            /// <summary>
            /// 收款方行号
            /// </summary>
            [XmlElement("WDBankNo")]
            public string WDBankNo { get; set; }

            /// <summary>
            /// 收款方银行开户行名称
            /// </summary>
            [XmlElement("WDBankName")]
            public string WDBankName { get; set; }

            /// <summary>
            /// 预留字段
            /// </summary>
            [XmlElement("Reserve1")]
            public string Reserve1 { get; set; }

            /// <summary>
            /// 预留字段
            /// </summary>
            [XmlElement("Reserve2")]
            public string Reserve2 { get; set; }

            /// <summary>
            /// 预留字段
            /// </summary>
            [XmlElement("Reserve3")]
            public string Reserve3 { get; set; }
        }
    }
}

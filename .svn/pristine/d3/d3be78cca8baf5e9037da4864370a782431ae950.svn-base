using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BJUnionPayPaymentResponse : BaseResponse
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
            /// 合作伙伴交易请求流水号
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 交易所属日期
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 币种
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 收款人账号
            /// </summary>
            [XmlElement("PayeeAcNo")]
            public string PayeeAcNo { get; set; }

            /// <summary>
            /// 收款人姓名
            /// </summary>
            [XmlElement("PayeeName")]
            public string PayeeName { get; set; }

            /// <summary>
            /// 收款行行名
            /// </summary>
            [XmlElement("PayeeBankName")]
            public string PayeeBankName { get; set; }

            /// <summary>
            /// 收款行行号
            /// </summary>
            [XmlElement("PayeeBankNo")]
            public string PayeeBankNo { get; set; }

            /// <summary>
            /// 转入账户类型
            /// </summary>
            [XmlElement("AcType")]
            public string AcType { get; set; }

            /// <summary>
            /// 交易金额
            /// </summary>
            [XmlElement("Amount")]
            public string Amount { get; set; }

            /// <summary>
            /// 转账手续费
            /// </summary>
            [XmlElement("ChannelSeq")]
            public string TransferFee { get; set; }

            /// <summary>
            /// 摘要
            /// </summary>
            [XmlElement("Remark")]
            public string Remark { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve1")]
            public string Reserve1 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve2")]
            public string Reserve2 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve3")]
            public string Reserve3 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve4")]
            public string Reserve4 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve5")]
            public string Reserve5 { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class UnfrozenFixedDepositResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 活转定交易所属日期或活期资金冻结交易所属日期
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 活转定交易流水号或活期资金冻结交易流水号
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 冻结类型    0-金额冻结 1-冻结(只进不出) 2-封闭冻结(不进不出)
            /// </summary>
            [XmlElement("FreezeType")]
            public string FreezeType { get; set; }

            /// <summary>
            /// 冻结金额
            /// </summary>
            [XmlElement("FreezeAmount")]
            public string FreezeAmount { get; set; }

            /// <summary>
            /// 解冻日期
            /// </summary>
            [XmlElement("UnFreezeDate")]
            public string UnFreezeDate { get; set; }

            /// <summary>
            /// 操作标志
            /// </summary>
            [XmlElement("ManageFlag")]
            public string ManageFlag { get; set; }

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

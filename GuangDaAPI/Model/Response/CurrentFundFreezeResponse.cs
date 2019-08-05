﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class CurrentFundFreezeResponse : BaseResponse
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
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 余额（电子账户）
            /// </summary>
            [XmlElement("Balance")]
            public decimal Balance { get; set; }

            /// <summary>
            /// 账户中文名
            /// </summary>
            [XmlElement("AcName")]
            public string AcName { get; set; }

            /// <summary>
            /// 资金解冻日期（即该日期当天凌晨资金会解冻）
            /// </summary>
            [XmlElement("UnFreezeDate")]
            public string UnFreezeDate { get; set; }

            /// <summary>
            /// 冻结状态 S成功 F失败 U未明
            /// </summary>
            [XmlElement("FreezeState")]
            public string FreezeState { get; set; }

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

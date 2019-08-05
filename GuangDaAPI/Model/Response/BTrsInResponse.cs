﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BTrsInResponse : BaseResponse
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
            /// 光大生成的交易流水号
            /// </summary>
            [XmlElement("EbankJnlNo")]
            public string EbankJnlNo { get; set; }

            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 资金转入金额（转账成功之后光大返回的金额）
            /// </summary>
            [XmlElement("Amount")]
            public decimal Amount { get; set; }

            /// <summary>
            /// 交易类型（0-充值，1-返利T+0，2-退款，5-返利T+1，6-定向申购，7-定向赎回，13-非绑定卡转入，14-贷款发放）
            /// </summary>
            [XmlElement("TrsType")]
            public int TrsType { get; set; }

            /// <summary>
            /// 币种
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 交易受理时间（转账完成的时间）
            /// </summary>
            [XmlElement("CebTrsTime")]
            public string CebTrsTime { get; set; }

            /// <summary>
            /// 摘要
            /// </summary>
            [XmlElement("Remark")]
            public string Remark { get; set; }

            /// <summary>
            /// 账务流水号
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

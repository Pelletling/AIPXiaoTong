﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class EComGAmountRequest : IBaseRequest<EComGAmountResponse>
    {
        /// <summary>
        /// 提现，五万以下，普通提现
        /// </summary>
        public EComGAmountRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "EComGAmount"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("Amount", Body.Amount);
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("Currency", Body.Currency);
            dic.Add("ChannelSeq", Body.ChannelSeq);
            dic.Add("TrsDate", Body.TrsDate);
            dic.Add("WDType", Body.WDType);
            dic.Add("Remark", Body.Remark);
            dic.Add("WDName", Body.WDName);
            dic.Add("IdType", Body.IdType);
            dic.Add("IdNo", Body.IdNo);
            dic.Add("WDAcNo", Body.WDAcNo);
            dic.Add("WDBankNo", Body.WDBankNo);
            dic.Add("WDInnerBankFlag", Body.WDInnerBankFlag);
            dic.Add("Reserve1", Body.Reserve1);
            dic.Add("Reserve2", Body.Reserve2);
            dic.Add("Reserve3", Body.Reserve3);

            return dic;
        }

        public string Sort(string signContent)
        {
            return signContent;
        }

        [XmlElement("Head")]
        public HEAD Head { get; set; }

        [XmlElement("Body")]
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 提现金额
            /// </summary>
            [XmlElement("Amount")]
            public string Amount { get; set; }

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
            /// 提现流水号（流水号+当天日期 保证唯一）
            /// </summary>
            [XmlElement("ChannelSeq")]
            public string ChannelSeq { get; set; }

            /// <summary>
            /// 交易所属日期（YYYYMMDD）
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 提现方式（0-转出到对公账户，1-转出到绑定卡）
            /// </summary>
            [XmlElement("WDType")]
            public string WDType { get; set; }

            /// <summary>
            /// 摘要（如果提现方式选择1，同时该绑定卡为非光大银行，该字段必输）
            /// </summary>
            [XmlElement("Remark")]
            public string Remark { get; set; }

            /// <summary>
            ///（转出到绑定卡） 客户姓名
            /// </summary>
            [XmlElement("WDName")]
            public string WDName { get; set; }

            /// <summary>
            /// （转出到绑定卡）证件类型
            /// </summary>
            [XmlElement("IdType")]
            public string IdType { get; set; }

            /// <summary>
            /// （转出到绑定卡）证件号码（走超网）
            /// </summary>
            [XmlElement("IdNo")]
            public string IdNo { get; set; }

            /// <summary>
            /// （转出到绑定卡）收款方银行账号
            /// </summary>
            [XmlElement("WDAcNo")]
            public string WDAcNo { get; set; }

            /// <summary>
            /// （转出到绑定卡）收款方行号（如果是转出到绑定卡，同时该卡发卡行为光大银行，则该字段上送值为空，即不需要输入联行号）
            /// </summary>
            [XmlElement("WDBankNo")]
            public string WDBankNo { get; set; }

            /// <summary>
            /// （转出到绑定卡）行内外标识（0：光大银行 1：非光大银行）
            /// </summary>
            [XmlElement("WDInnerBankFlag")]
            public string WDInnerBankFlag { get; set; }

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
        }
    }
}

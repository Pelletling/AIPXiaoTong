﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class CurrentFundFreezeRequest : IBaseRequest<CurrentFundFreezeResponse>
    {
        /// <summary>
        /// 冻结
        /// </summary>
        public CurrentFundFreezeRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "CurrentFundFreeze"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("TrsDate", Body.TrsDate);
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("FreezeType", Body.FreezeType);
            dic.Add("Currency", Body.Currency);
            dic.Add("CEFlag", Body.CEFlag);
            dic.Add("ThawDate", Body.ThawDate);
            dic.Add("Amount", Body.Amount);
            dic.Add("ProtocolNo", Body.ProtocolNo);
            dic.Add("GroupNo", Body.GroupNo);
            dic.Add("TravelStartDay", Body.TravelStartDay);
            dic.Add("TravelEndDay", Body.TravelEndDay);
            dic.Add("ProtocolDate", Body.ProtocolDate);
            dic.Add("Remark", Body.Remark);
            dic.Add("Reserve1", Body.Reserve1);
            dic.Add("Reserve2", Body.Reserve2);
            dic.Add("Reserve3", Body.Reserve3);
            dic.Add("Reserve4", Body.Reserve4);
            dic.Add("Reserve5", Body.Reserve5);

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
            /// 合作伙伴交易请求流水号
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 交易所属日期（YYYYMMDD）
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 接入方客户标识号（可确定资金转入的电子账户）
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 冻结类型 0-金额冻结；1-冻结(只进不出)；2-封闭冻结(不进不出)
            /// </summary>
            [XmlElement("FreezeType")]
            public string FreezeType { get; set; }

            /// <summary>
            /// 币种
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 钞汇标志 0-钞户；1-汇户
            /// </summary>
            [XmlElement("CEFlag")]
            public string CEFlag { get; set; }

            /// <summary>
            /// 解冻日期（YYYYMMDD）
            /// </summary>
            [XmlElement("ThawDate")]
            public string ThawDate { get; set; }

            /// <summary>
            /// 冻结金额（元，两位小数）
            /// </summary>
            [XmlElement("Amount")]
            public string Amount { get; set; }

            /// <summary>
            /// 协议号（8位数字，对应三方协议的协议编号）
            /// </summary>
            [XmlElement("ProtocolNo")]
            public string ProtocolNo { get; set; }

            /// <summary>
            /// 团号（60位长度，支持数字、字母、下划线、中划线）
            /// </summary>
            [XmlElement("GroupNo")]
            public string GroupNo { get; set; }

            /// <summary>
            /// 行程起始日（YYYYMMDD）
            /// </summary>
            [XmlElement("TravelStartDay")]
            public string TravelStartDay { get; set; }

            /// <summary>
            /// 行程结束日（YYYYMMDD）
            /// </summary>
            [XmlElement("TravelEndDay")]
            public string TravelEndDay { get; set; }

            /// <summary>
            /// 协议到期日
            /// </summary>
            [XmlElement("ProtocolDate")]
            public string ProtocolDate { get; set; }

            /// <summary>
            /// 冻结摘要
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
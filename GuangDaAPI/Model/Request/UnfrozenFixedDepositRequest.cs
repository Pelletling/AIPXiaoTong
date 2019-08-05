﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class UnfrozenFixedDepositRequest : IBaseRequest<UnfrozenFixedDepositResponse>
    {
        /// <summary>
        /// 解冻
        /// </summary>
        public UnfrozenFixedDepositRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "UnfrozenFixedDeposit"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("TrsDate", Body.TrsDate);
            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("ManageFlag", Body.ManageFlag);
            dic.Add("FreezeType", Body.FreezeType);
            dic.Add("FreezeAmount", Body.FreezeAmount);
            dic.Add("Currency", Body.Currency);
            dic.Add("UnFreezeDate", Body.UnFreezeDate);
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
            /// 原活转定交易所属日期或活期资金冻结交易所属日期（YYYYMMDD）
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 原活转定交易流水号或活期资金冻结交易流水号
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 操作标志 8 修改 5解冻
            /// </summary>
            [XmlElement("ManageFlag")]
            public string ManageFlag { get; set; }

            /// <summary>
            /// 冻结类型 0-金额冻结 1-冻结(只进不出) 2-封闭冻结(不进不出)
            /// </summary>
            [XmlElement("FreezeType")]
            public string FreezeType { get; set; }

            /// <summary>
            /// 冻结金额（元，两位小数）
            /// </summary>
            [XmlElement("FreezeAmount")]
            public string FreezeAmount { get; set; }

            /// <summary>
            /// 货币代号
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 解冻日期（如果ManageFlag操作标志选择为8-修改，则需要上送该字段）
            /// </summary>
            [XmlElement("UnFreezeDate")]
            public string UnFreezeDate { get; set; }

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

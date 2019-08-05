﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BTrsInRequest : IBaseRequest<BTrsInResponse>
    {
        /// <summary>
        /// 充值
        /// </summary>
        public BTrsInRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "BTrsIn"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("TrsDate", Body.TrsDate);
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("Amount", Body.Amount);
            dic.Add("TrsType", Body.TrsType);
            dic.Add("Currency", Body.Currency);
            dic.Add("Remark", Body.Remark);
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
            /// 合作伙伴交易请求流水号  注：流水号+当天日期 保证唯一
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
            /// 资金转入金额（元，两位小数）
            /// </summary>
            [XmlElement("Amount")]
            public string Amount { get; set; }

            /// <summary>
            /// 交易类型（0-充值，1-返利T+0，2-退款，5-返利T+1，6-定向申购，7-定向赎回，13-非绑定卡转入，14-贷款发放）
            /// </summary>
            [XmlElement("TrsType")]
            public string TrsType { get; set; }

            /// <summary>
            /// 币种（当前仅支持人民币）
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 摘要
            /// </summary>
            [XmlElement("Remark")]
            public string Remark { get; set; }

            /// <summary>
            /// 结算账户名称（仅当交易类型选择为6-定向申购、7-定向赎回 时上送）
            /// </summary>
            [XmlElement("Reserve1")]
            public string Reserve1 { get; set; }

            /// <summary>
            /// 结算账号（仅当交易类型选择为6-定向申购、7-定向赎回 时上送）
            /// </summary>
            [XmlElement("Reserve2")]
            public string Reserve2 { get; set; }

            /// <summary>
            /// 结算日期（仅当交易类型选择 6-定向申购时，上送该字段，日期由商户来控制，需保证结算日期必须大于当前日期，否则后续自动转出会失败）
            /// </summary>
            [XmlElement("Reserve3")]
            public string Reserve3 { get; set; }
        }
    }
}

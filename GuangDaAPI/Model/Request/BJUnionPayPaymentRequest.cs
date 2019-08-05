﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BJUnionPayPaymentRequest : IBaseRequest<BJUnionPayPaymentResponse>
    {
        /// <summary>
        /// 提现，五万以上，北京银联单笔代付
        /// </summary>
        public BJUnionPayPaymentRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "BJUnionPayPayment"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("TrsDate", Body.TrsDate);
            dic.Add("Currency", Body.Currency);
            dic.Add("AcNo", Body.AcNo);
            dic.Add("PayeeName", Body.PayeeName);
            dic.Add("PayeeBankName", Body.PayeeBankName);
            dic.Add("PayeeBankNo", Body.PayeeBankNo);
            dic.Add("AcType", Body.AcType);
            dic.Add("Amount", Body.Amount);
            dic.Add("TransferFee", Body.TransferFee);
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
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 合作伙伴交易请求流水号（流水号+当天日期 保证唯一）
            /// </summary>
            [XmlElement("CoPatrnerJnlNo")]
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 交易所属日期（YYYYMMDD）
            /// </summary>
            [XmlElement("TrsDate")]
            public string TrsDate { get; set; }

            /// <summary>
            /// 币种（目前只支持上送CNY，即人民币）
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }

            /// <summary>
            /// 账号（转入账号）
            /// </summary>
            [XmlElement("AcNo")]
            public string AcNo { get; set; }

            /// <summary>
            /// 收款人姓名
            /// </summary>
            [XmlElement("PayeeName")]
            public string PayeeName { get; set; }

            /// <summary>
            /// 收款行行名（收款账号所属银行名称）
            /// </summary>
            [XmlElement("PayeeBankName")]
            public string PayeeBankName { get; set; }

            /// <summary>
            /// 收款行行号（同普通提现收款方行号）
            /// </summary>
            [XmlElement("PayeeBankNo")]
            public string PayeeBankNo { get; set; }

            /// <summary>
            /// 转入账户类型（2-对私户）
            /// </summary>
            [XmlElement("AcType")]
            public string AcType { get; set; }

            /// <summary>
            /// 交易金额
            /// </summary>
            [XmlElement("Amount")]
            public string Amount { get; set; }

            /// <summary>
            /// 转账手续费（详细请联系光大业务）
            /// </summary>
            [XmlElement("ChannelSeq")]
            public string TransferFee { get; set; }

            /// <summary>
            /// 摘要（如果提现方式选择1，同时该绑定卡为非光大银行，该字段必输）
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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TltApi.Model
{
    [XmlRoot(ElementName = "AIPG")]
    public class SingleOntimePayRquest : IBaseRequest<SingleOntimePayResponse>
    {
        public SingleOntimePayRquest() { }
        public SingleOntimePayRquest(TltExec tltExec)
        {
            INFO = new Info(tltExec);
            TRANS = new Trans(tltExec);
        }


        [XmlElement(ElementName = "INFO")]
        public Info INFO { get; set; }

        [XmlElement(ElementName = "TRANS")]
        public Trans TRANS { get; set; }

        public class Info
        {
            private TltExec tltExec;
            public Info() { }
            public Info(TltExec tltExec)
            {
                this.tltExec = tltExec;
            }
            /// <summary>
            /// 交易代码
            /// </summary>
            public string TRX_CODE { get { return "100014"; } set { } }
            /// <summary>
            /// 版本
            /// </summary>
            public string VERSION { get { return "05"; } set { } }
            /// <summary>
            /// 数据格式
            /// </summary>
            public string DATA_TYPE { get { return "2"; } set { } }
            /// <summary>
            /// 处理级别 0-9 0最优  
            /// </summary>
            public string LEVEL { get { return "5"; } set { } }
            /// <summary>
            /// 商户代码( 商户ID，十位或十五位)
            /// </summary>
            public string MERCHANT_ID { get { return this.tltExec.merchantId; } set { } }
            /// <summary>
            /// 用户名
            /// </summary>
            public string USER_NAME { get { return this.tltExec.userName; } set { } }
            /// <summary>
            /// 用户密码
            /// </summary>
            public string USER_PASS { get { return this.tltExec.userPassword; } set { } }
            /// <summary>
            /// 交易批次号
            /// </summary>
            public string REQ_SN { get; set; }

        }
        public class Trans
        {
            private TltExec tltExec;
            public Trans() { }
            public Trans(TltExec tltExec)
            {
                this.tltExec = tltExec;
            }
            /// <summary>
            /// 业务代码
            /// </summary>
            public string BUSINESS_CODE { get; set; }
            /// <summary>
            /// 商户代码
            /// </summary>
            public string MERCHANT_ID { get { return this.tltExec.merchantId; } set { } }

            /// <summary>
            /// 提交时间 yyyyMMDDHHmmss
            /// </summary>
            public string SUBMIT_TIME { get; set; }
            /// <summary>
            /// 客户编号 可空
            /// </summary>
            public string E_USER_CODE { get; set; }
            /// <summary>
            /// 银行卡有效期 YYYYMMDD 可空
            /// </summary>
            public string VALIDATE { get; set; }
            /// <summary>
            /// 信用卡CVV2 可空
            /// </summary>
            public string CVV2 { get; set; }
            /// <summary>
            /// 银行代码 存折必须填写
            /// </summary>
            public string BANK_CODE { get; set; }
            /// <summary>
            /// 开户行名称(开户行详细名称，也叫网点，如 中国建设银行广州东山广场分理处。)
            /// </summary>
            public string BANK_NAME { get; set; }
            /// <summary>
            /// 账号类型
            /// </summary>
            public string ACCOUNT_TYPE { get; set; }
            /// <summary>
            /// 账号
            /// </summary>
            public string ACCOUNT_NO { get; set; }
            /// <summary>
            /// 账号名
            /// </summary>
            public string ACCOUNT_NAME { get; set; }
            /// <summary>
            /// 卡类别（1 一类卡 2 二类卡 3三类卡）（二类户付款时不能为空）
            /// </summary>
            public string ACCOUNT_ATTRB { get; set; }         
            /// <summary>
            /// 一类户账号
            /// </summary>
            public string FIRST_ACCTNO { get; set; }
            /// <summary>
            /// 一类户名
            /// </summary>
            public string FIRST_ACCTNAME { get; set; }
            /// <summary>
            /// 开户行所在省
            /// </summary>
            public string PROVINCE { get; set; }
            /// <summary>
            /// 开户行所在市
            /// </summary>
            public string CITY { get; set; }
            /// <summary>
            /// 账号属性 0私人，1公司。不填时，默认为私人0。
            /// </summary>
            public string ACCOUNT_PROP { get; set; }
            /// <summary>
            /// 金额 单位分
            /// </summary>
            public int AMOUNT { get; set; }
            /// <summary>
            /// 货币类型 人民币：CNY, 港元：HKD，美元：USD。不填时，默认为人民币。
            /// </summary>
            public string CURRENCY { get; set; }
            /// <summary>
            /// 开户证件类型
            /// </summary>
            public string ID_TYPE { get; set; }
            /// <summary>
            /// 证件号
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 本交易结算户
            /// </summary>
            public string SETTACCT { get; set; }
            /// <summary>
            /// 手机号
            /// </summary>
            public string TEL { get; set; }
            public string CUST_USERID { get; set; }
            public string SETTGROUPFLAG { get; set; }
            public string UNION_BANK { get; set; }
            /// <summary>
            /// 交易附言
            /// </summary>
            public string SUMMARY { get; set; }
            public string REMARK { get; set; }

        }
    }
}
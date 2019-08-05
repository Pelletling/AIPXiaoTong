using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TltApi.Model
{
    [XmlRoot(ElementName = "AIPG")]
    public class AccountVerifyRequest : IBaseRequest<AccountVerifyResponse>
    {
        public AccountVerifyRequest() { }
        public AccountVerifyRequest(TltExec tltExec)
        {
            INFO = new Info(tltExec);
            VALIDR = new Validr(tltExec);            
        }


        [XmlElement(ElementName = "INFO")]
        public Info INFO { get; set; }

        [XmlElement(ElementName = "VALIDR")]
        public Validr VALIDR { get; set; }

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
            public string TRX_CODE { get { return "211004"; } set { } }
            /// <summary>
            /// 版本
            /// </summary>
            public string VERSION { get { return "03"; } set { } }
            /// <summary>
            /// 数据格式
            /// </summary>
            public string DATA_TYPE { get { return "2"; } set { } }


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
            /// <summary>
            /// 处理级别 0-9 0最优  
            /// </summary>
            public string LEVEL { get { return "5"; } set { } }
        }

        public class Validr
        {
            private TltExec tltExec;
            public Validr() { }
            public Validr(TltExec tltExec)
            {
                this.tltExec = tltExec;
            }
            /// <summary>
            /// 商户代码
            /// </summary>
            public string MERCHANT_ID { get { return this.tltExec.merchantId; } set { } }
            /// <summary>
            /// 提交时间 yyyyMMDDHHmmss
            /// </summary>
            public string SUBMIT_TIME { get; set; }
            /// <summary>
            /// 银行代码
            /// </summary>
            public string BANK_CODE { get; set; }
            /// <summary>
            /// 账号 银行卡或存折号码
            /// </summary>
            public string ACCOUNT_NO { get; set; }
            /// <summary>
            /// 账号名 银行卡或存折上的所有人姓名
            /// </summary>
            public string ACCOUNT_NAME { get; set; }
            /// <summary>
            /// 账号属性 0私人，1公司。不填时，默认为私人0。
            /// </summary>
            public string ACCOUNT_PROP { get; set; }
            /// <summary>
            /// 开户证件类型  0：身份证,1: 户口簿，2：护照,3.军官证,4.士兵证，5. 港澳居民来往内地通行证,6. 台湾同胞来往内地通行证,7. 临时身份证,8. 外国人居留证,9. 警官证, X.其他证件
            /// </summary>
            public string ID_TYPE { get; set; }
            /// <summary>
            /// 证件号
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 手机号
            /// </summary>
            public string TEL { get; set; }
        }
    }

   

    
}

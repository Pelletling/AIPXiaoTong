using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    public class AuthenticationToOpenAccountRequest : IBaseRequest<AuthenticationToOpenAccountResponse>
    {

        /// <summary>
        /// 2.59.	鉴权开户接口
        /// </summary>
        public AuthenticationToOpenAccountRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        public string Method { get { return "AuthenticationToOpenAccount"; } }
        public string Action { get { return ""; } }

        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("CifName", Body.CifName);
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("IdType", Body.IdType);
            dic.Add("IdNo", Body.IdNo);
            dic.Add("BankCardPhoneCode", Body.BankCardPhoneCode);
            dic.Add("CifPhoneCode", Body.CifPhoneCode);
            dic.Add("CifIdExpiredDate", Body.CifIdExpiredDate);
            dic.Add("CifAddr", Body.CifAddr);
            dic.Add("CifPostCode", Body.CifPostCode);
            dic.Add("CifEnName", Body.CifEnName);
            dic.Add("CifENFName", Body.CifENFName);
            dic.Add("OperateType", Body.OperateType);
            dic.Add("NetCheckFlag", Body.NetCheckFlag);
            dic.Add("BankCardType", Body.BankCardType);
            dic.Add("BankAcNo", Body.BankAcNo);
            dic.Add("BankName", Body.BankName);
            dic.Add("SubBranchName", Body.SubBranchName);
            dic.Add("OpenChannel", Body.OpenChannel);
            dic.Add("BookDate", Body.BookDate);
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


        public HEAD Head { get; set; }

        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 合作伙伴交易请求流水号（唯一标识）
            /// </summary>
            public string CoPatrnerJnlNo { get; set; }

            /// <summary>
            /// 客户姓名
            /// </summary>
            public string CifName { get; set; }

            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            public string CifClientId { get; set; }
            
            /// <summary>
            /// 证件类型 (P00)
            /// </summary>
            public string IdType { get; set; }
            
            /// <summary>
            /// 证件号码
            /// </summary>
            public string IdNo { get; set; }

            /// <summary>
            /// 鉴权银行卡手机号
            /// </summary>
            public string BankCardPhoneCode { get; set; }

            /// <summary>
            /// 开户手机号
            /// </summary>
            public string CifPhoneCode { get; set; }

            /// <summary>
            /// 用户证件有效期
            /// </summary>
            public string CifIdExpiredDate { get; set; }

            /// <summary>
            /// 用户地址
            /// </summary>
            public string CifAddr { get; set; }
            
            /// <summary>
            /// 邮编
            /// </summary>
            public string CifPostCode { get; set; }

            /// <summary>
            /// 客户英文名
            /// </summary>
            public string CifEnName { get; set; }

            /// <summary>
            /// 客户英文\拼音姓
            /// </summary>
            public string CifENFName { get; set; }

            /// <summary>
            /// 操作类型：0 开户，1 BTA理财
            /// </summary>
            public string OperateType { get; set; }

            /// <summary>
            /// 联网核查标识（0-已核查，1-未核查）
            /// </summary>
            public string NetCheckFlag { get; set; }
            
            /// <summary>
            /// 卡类型（0-信用卡，1-I类户）
            /// </summary>
            public string BankCardType { get; set; }

            /// <summary>
            /// 银行卡卡号
            /// </summary>
            public string BankAcNo { get; set; }

            /// <summary>
            /// 银行名称
            /// </summary>
            public string BankName { get; set; }

            /// <summary>
            /// 网点名称
            /// </summary>
            public string SubBranchName { get; set; }

            /// <summary>
            /// 开户渠道（0-互联网网页 1-APP客户端）
            /// </summary>
            public string OpenChannel { get; set; }

            /// <summary>
            /// 交易所属日期
            /// </summary>
            public string BookDate { get; set; }

            /// <summary>
            /// II、III类户标志，（0-II类账户，1-III类账户）
            /// </summary>
            public string Reserve1 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve2 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve3 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve4 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve5 { get; set; }
        }
    }
}
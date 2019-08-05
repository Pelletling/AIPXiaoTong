﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace GuangDaAPI.Model
{
    public class BCifAcctNoOpenRequest : IBaseRequest<BCifAcctNoOpenResponse>
    {

        /// <summary>
        /// 开户
        /// </summary>
        public BCifAcctNoOpenRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }
        
        public string Method { get { return "BOpenAcctSignPay"; } }
        public string Action { get { return ""; } }

        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CifAddr", Body.CifAddr);
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("CifEnName", Body.CifEnName);
            dic.Add("CifIdExpiredDate", Body.CifIdExpiredDate);
            dic.Add("CifName", Body.CifName);
            dic.Add("CifPhoneCode", Body.CifPhoneCode);
            dic.Add("CifPostCode", Body.CifPostCode);
            dic.Add("IdNo", Body.IdNo);
            dic.Add("IdType", Body.IdType);
            dic.Add("OperateType", Body.OperateType);
            dic.Add("ProvinceCode", Body.ProvinceCode);
            dic.Add("CityCode", Body.CityCode);
            dic.Add("NetCheckFlag", Body.NetCheckFlag);
            dic.Add("BankCardPhoneCode", Body.BankCardPhoneCode);
            dic.Add("BankCardType", Body.BankCardType);
            dic.Add("BankAcNo", Body.BankAcNo);
            dic.Add("BankName", Body.BankName);
            dic.Add("SubBranchName", Body.SubBranchName);
            dic.Add("OpenChannel", Body.OpenChannel);
            dic.Add("Remark1", Body.Remark1);
            dic.Add("Remark2", Body.Remark2);
            dic.Add("Remark3", Body.Remark3);
            dic.Add("Remark4", Body.Remark4);
            dic.Add("Remark5", Body.Remark5);
            dic.Add("Remark6", Body.Remark6);
            dic.Add("Remark7", Body.Remark7);
            dic.Add("Remark8", Body.Remark8);
            dic.Add("Remark9", Body.Remark9);
            dic.Add("Remark10", Body.Remark10);

            return dic;
        }

        public string Sort(string signContent)
        {
            var remark9 = signContent.GetValue("Remark9=", "&");
            var remark10 = signContent.GetValue("Remark10=", "&");

            var result = signContent.Replace("&Remark10=" + remark10, "").Replace("Remark9=" + remark9, "Remark9=" + remark9 + "&Remark10=" + remark10);

            return result;
        }

        
        public HEAD Head { get; set; }
        
        public BODY Body { get; set; }

       

        public class BODY
        {
            /// <summary>
            /// 联系地址(8-30个汉字)
            /// </summary>
            public string CifAddr { get; set; }

            /// <summary>
            /// 接入方客户标识号（在同UserId下，同一套客户信息只有一个标识号）
            /// </summary>
            public string CifClientId { get; set; }   //guid

            /// <summary>
            /// 客户英文名称(三个字母以上,最长40)
            /// </summary>
            public string CifEnName { get; set; }

            /// <summary>
            /// 证件有效期
            /// </summary>
            public string CifIdExpiredDate { get; set; }

            /// <summary>
            /// 姓名
            /// </summary>
            public string CifName { get; set; }

            /// <summary>
            /// 手机号
            /// </summary>
            public string CifPhoneCode { get; set; }

            /// <summary>
            /// 邮编
            /// </summary>
            public string CifPostCode { get; set; }

            /// <summary>
            /// 证件号码
            /// </summary>
            public string IdNo { get; set; }

            /// <summary>
            /// 证件类型  只支持输入：P00（数字’0’）代表身份证
            /// </summary>
            public string IdType { get; set; }   //N

            /// <summary>
            /// 产品类型（5-开户&电子支付签约）
            /// </summary>
            public string OperateType { get; set; }   //N

            /// <summary>
            /// 客户所在省份代号（机构号由光大线下提供）
            /// </summary>
            public string ProvinceCode { get; set; }

            /// <summary>
            /// 客户所在城市代号（机构号由光大线下提供）
            /// </summary>
            public string CityCode { get; set; }

            /// <summary>
            /// 联网核查标识（0-已核查，1-未核查）
            /// </summary>
            public string NetCheckFlag { get; set; }    //N

            /// <summary>
            /// 银行卡预留手机号
            /// </summary>
            public string BankCardPhoneCode { get; set; }

            /// <summary>
            /// 卡类型（0-信用卡，1-I类户）
            /// </summary>
            public string BankCardType { get; set; }   //N

            /// <summary>
            /// 银行卡号
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
            public string OpenChannel { get; set; }   //N


            /// <summary>
            /// 是否同步中台客户标识号，可选，若需要同步，需上送数字1其他报错。
            /// </summary>
            public string Remark1 { get; set; }   //N

            /// <summary>
            /// 职业，非必输项
            /// </summary>
            public string Remark2 { get; set; }   //N

            /// <summary>
            /// 发证机关，非必输项
            /// </summary>
            public string Remark3 { get; set; }    //N

            /// <summary>
            /// II、III类户标志，非必输项 （0-II类账户，1-III类账户）
            /// </summary>
            public string Remark4 { get; set; }   //N

            /// <summary>
            /// 备用字段5，可选
            /// </summary>
            public string Remark5 { get; set; }   //N

            /// <summary>
            /// 备用字段6，可选
            /// </summary>
            public string Remark6 { get; set; }  //N

            /// <summary>
            /// 备用字段7，可选
            /// </summary>
            public string Remark7 { get; set; }

            /// <summary>
            /// 备用字段8，可选
            /// </summary>
            public string Remark8 { get; set; }

            /// <summary>
            /// 备用字段9，可选
            /// </summary>
            public string Remark9 { get; set; }

            /// <summary>
            /// 备用字段10，可选
            /// </summary>
            public string Remark10 { get; set; }

        }

    }


}
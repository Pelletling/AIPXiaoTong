﻿using Framework.Common;
using Framework.Requests;
using Framework.Security;
using GuangDaAPI;
using GuangDaAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using PingAnAPI;
using PingAnAPI.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using TltApi;
using TltApi.Model;

namespace GuangDaTest
{
    class Program
    {
        static TltExec tltExec;
        static GuangDaExec guangDaExec;
        // public PingAnExec(string url, string publicKey,string privateKey , string redirectUrl  ,string autoLoginUrl,string returnUrl, string sha1Key , string autoLoginPublicKey )
        static string url = "https://bbc-stg1.pingan.com.cn:6443/bbc/openapi/";
        static string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAy/o0tFwhKNnT4A5XMhNlOe4vE9zMmbg6/kqWxEAO5TzALA+iJ3jp++c96PgItfOVimQhkcacV0Xenn4iK0wTIlZQtVfV0k4ZJGSNj0DGgh9GIeCf2fb0D8YJ1kgtAj8SpWh4jEae7k3onBpAMyl0+8PHUDfIcgvFArMMZiMpt5MIW9LtSHLqOcaKJGTsfdZfDcP+ve3OR+k9m1iu73PBh6wGjB9yvs/eEtL9DsQmZdOPSRr48iKdCUoXTkzbt6XP55GKX/li10m/UwdhnAo5CS8HfetesF4fDowZSNQ+tYDtSM+PgSWnESQcjSHLfdFsTiezFuINGK+JhzLTK1NQrQIDAQAB";
        static string privateKey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCBB2JJ2+JVKTFF/p8YBFR2xhJYKZ36SSdffV9Aji+fq9M6IkGFE9VEbijqnoVNbBcfCeDL8+HZxg0g/gq14mmc3QFNed4rjWDawIgWOWpH661SWAmru0fxddsVfv/qPEvotpJLYLZmoB6g+wewk48QBhiZukjWK0mypj/ileUUMDecvjDB0ktP4/XUE/F+gWAL4AJdUE/UDK9KAYDRl6MSBkVPZoZVmUxQVst/1m3AENGxqJdBF8zpAwr8z3q4Yo5gtsXAUxcTWFI0Ev3LH8GVmuZA71C1zpnAWzFQ2LVgPjoFTlFiF5CJ5rlHbwVLUG4KG5pcr/gCyBRSmrqkhYJlAgMBAAECggEAMxSSQ70qAB7bo+MmZqKoMZE+h+qJ4SD+1l3SzMK9dc/XQod3OtDcOEgIKMHy8fCdwqrtdLCrM8SlQ+9unAzzVKdlsZ9SZhmFQ3S/K1U1jx1tM1EpGvR8icnnnr31YGzYfFty1SaHb19qYL6gj7YLCAPxz0IhPbBLb89DMVe4JeJTVUxKGmsZEhWz/AMbZxWH+dvQjQ174MXD0tLLgiz72Dih5qHwYBEWmkYU0t+iWWx+EEuseYvS9BRR90wQW3bGYYXMtLfkvivBSvftlndRUdEuw844GwqJaBwdGi+6jTM4yUNsosgEl8yqm0ch4bA0o7fQeKlO2z19BflPrpPzoQKBgQDSymYAzfTjYjLmwaoRnh2J2rccxGkSesUz0rUxtBsL35C5ZMiaA9KWIkKqb+tgQcOMidmytP2LbaACwdmHU1UWST9nU5c19nPQQcj+HvqfAb9DTBk+8fbnurdofwP0SuC5fKD+iU9XkIZrpE3JVduLeXDQ02BKviec0x38wOwKDQKBgQCcs8zFqvmj/L23s8Slpjl6GWbqvUNPPriA0WhT/+kMfANdNpWvH8P7UxVF08EgIbEFXgUsbSgYI90WObyoBnI+Gaes8QFeRoRFGWZXWNGm+1us2mcQ9A5u6PYIrRP8FsdJX1eM8RuV2q/qkqUEQt9WTlsyrLnmbqWnfJVDxBZ7uQKBgQCqGolcRthDkuBO1aQ/2WAu+iBhB6NfNVHkszpjpNtapoys/8beew06+OThk7XXlNqQlEHo9CPTm6DP+M1pZnc4p92RraRN+NeXDS9821UWcht93HBXGn5MnKIborx3LOHS7d8h6X7sxAWl4g6f1jh4goTnEF0ZlAB1ju0ZJjqVFQKBgAPoL7jV9Hd0O76yyrpelJxIudoscdst8yezEOjXPpZDGUpfrAe7wQUpIySkjPIiJOm/WF2tMwy3CDIfqmZ+EqcduKKFN8WD+JRId9bBrih9p+F9aIhxrVJymH/K4O6uGrXnnKU09b0cwLoWgerDSBI8zeVLjS8Dnzm3z3jrEKxxAoGAJLQNmsepFEL934zXtMteD4WWeEvM47pYZLm4g0tvQMQnSav4Xf3oTvar9VyfjXINWVrqs/qZbgjHaPGRhqXmw2RAFEkVe37Hny8uKD2i14x86Yz9u5qCveHEsPf3Gyr40JFD/zO0mt/BNezp++ECR52DewItw+yW6cIrEM+yYLE=";
        static string redirectUrl = "https://bank-static-stg.pingan.com.cn/bbc/index/landing.html";
        static string autoLoginUrl = "https://rmb-stg.pingan.com.cn/brcp/uc/cust/uc-third-auth.autoLogin.do?";
        //static string returnUrl = "https://rmb-stg.pingan.com.cn/brcp/uc/cust/uc-third-auth.autoLogin.do?";
        static string sha1Key = "b34dc091889949cc86e85978355756b4";
        static string autoLoginPublicKey = "MIGiMA0GCSqGSIb3DQEBAQUAA4GQADCBjAKBhACGeGMZ03Z7dMDgU7CcqN7Omlto1wEg+Y6g5ZvTzplhXOHSmtkyG3b3wYVg/aQeyWt2A6r7mbLaUx9TWDIdG/gKRluR7egYY1/3Ql0yp40XFn5MLXmEKXUS9th8IvdwL2KJU7sYNpR4cQ7LT21F/E6ejsUQ9DGyr7unNE4Hfk6eRCoVvQIDAQAB";

        static PingAnExec pingAnExec = new PingAnExec(url, publicKey, privateKey, autoLoginUrl, sha1Key, autoLoginPublicKey);
        //static string userid = "tlzfsh";
        //static string pwd = "111111";
        static string cifClientId = "81ac0a0c2f038fd5";

        static void Main(string[] args)
        {

            ConvTime();

            //var a=  GetEncryptedMsg();
            //var a= GetALPath();

            //PreparedFreezeOrder();

            //预下单数据
            // string signContent = "autoFreeze=00&businessName=购机业务1&cardNumber=430981199211104634&channel=1007041&freezeAmt=0.01&freezeProduct=1&freezeTimeLimit=4&mobile=15273738880&orderValidDay=4&transCode=001&userName=刘勋";
            // var sign = RSASign(signContent);

            //BBC订单查询数据
            // string queryContent = "bankOrderNo=9230081901172615314167&channel=1007041&transCode=002";
            //var orderinfo = GetBBCOrserInfo(queryContent);

            //免登跳转数据   encryptData --------------------------------------------------------------------------------
            //Dictionary<string, string> autoData = new Dictionary<string, string>();
            //// autoData.Add("accNo", "6230580000000003389");
            //autoData.Add("clientIdNo", "330219196609107006");
            //autoData.Add("clientName", "章寿尘");
            //autoData.Add("clientIdType", "1");
            //autoData.Add("telNo", "15601010001");
            //autoData.Add("thirdMid", "15601010001");
            //autoData.Add("timestamp", ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString());

            //string autoLoginContent = "";
            //string signString = "";

            //foreach (var m in autoData.OrderBy(t => t.Key))
            //{
            //    signString += "&" + m.Key + "=" + m.Value;

            //    if (m.Key != "key")
            //    {
            //        autoLoginContent += "&" + m.Key + "=" + m.Value;
            //    }
            //}
            //BBCAutoLogin(autoLoginContent.Substring(1));

            //免登跳转数据   encryptData --------------------------------------------------------------------------------



            //-----------平安开户信息返回-----------------
            //var transData = "{\"channel\":\"bank.pingan.com\",\"data\":{\"cnName\":\"张三\",\"inCardNo\":\"62298002888333\",\"inCardNoType\":\"2\",\"outCardNo\":\"62298002888355\",\"amount\":\"500000.00\"}}";
            //Dictionary<string, string> bizMap = new Dictionary<string, string>();
            //bizMap.Add("orderNo", "9230081902152615964165");
            //bizMap.Add("timestamp", "1546589922923");
            //bizMap.Add("transData", transData);

            //string predata = JsonHelper.Serialize(bizMap);
            //GetAccountResult(predata);
            //-----------平安开户信息返回-----------------


            //------------------预下单订单查询---------------------------
            //QueryMarginsOrderDetail();   //单个订单
            //QueryBatchMarginsOrderDetial(); //批量查询
            //UnFreezeMarginsOrder();  //解止付
            //---------------------------------------------



            //------------------------------------------------------------------------------------
            // string timestamp = DateTime.Now.ToString();
            // string autoLoginContent2 = "clientIdNo=330219196708213250";

            // BBCAutoLogin(autoLoginContent2);

            //--------------测试时间差----------------------
            // DateTime ti = Convert.ToDateTime("2019-02-25 00:00:00.000");
            //TimeCha(ti);
            //--------------------------------------


            // var sign = RSASign(signContent);

            //guangDaExec = new GuangDaExec(userid, AppDomain.CurrentDomain.BaseDirectory + userid + ".pfx", pwd, true);

            //开户
            //Create();

            //2.59.	鉴权开户接口
            //Create1();

            //2.60.	开户查询接口
            //Create1Check();

            //上传身份证
            //UploadIdCardImage();

            //充值
            //var bTrsInResponse = Recharge();

            //冻结
            //var currentFundFreezeResponse = Freeze();

            //解冻
            //var unfrozenFixedDepositResponse = Unfreeze(currentFundFreezeResponse.Body.CoPatrnerJnlNo);

            //提现（5万以下）
            //var eComGAmountResponse = SmallWithdraw();

            //提现（5万以上）
            //var bJUnionPayPaymentResponse = LargeWithdraw();

            //var response = BTrsVeriAmount();

            //pinyin();

            //BCifAcNoAmount();

            //QueryFreezeCombination();

            //CheckFile();

            Console.WriteLine("OK");
            Console.ReadKey();
        }

        public static int TimeCha(DateTime dateend)
        {
            int day;
            DateTime start = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime end = Convert.ToDateTime(dateend.ToShortDateString());
            TimeSpan sp = end.Subtract(start);
            day = sp.Days;

            return day;
        }

        public static string ConvTime()
        {
            var a = (int)-235.75f;

            string sorTime = "20190305";

            DateTime tagTime = DateTime.ParseExact(sorTime, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            return "ok";
        }

        public static void pinyin()
        {
            string s = "强";

            Console.WriteLine(s.GetPinYin());
        }

        public static bool xml()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Message><Head><ReqJnlNo>201811151429400256</ReqJnlNo><ResJnlNo>3905251</ResJnlNo><ResTime>2018-11-15 14:05:47</ResTime><ResCode>000000</ResCode><ResMsg></ResMsg></Head><Body><CoPatrnerJnlNo>201811151429400466</CoPatrnerJnlNo><EbankJnlNo>3905251</EbankJnlNo><CifClientId>6d57392972f663e6</CifClientId><Amount>10.02</Amount><TrsType>0</TrsType><Currency>CNY</Currency><CebTrsTime>2018-11-15 14:05:47</CebTrsTime><Remark>资金转入</Remark><Reserve1>901f37023575</Reserve1><Reserve2></Reserve2><Reserve3></Reserve3></Body></Message>";

            //xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Message><Head><ReqJnlNo>201811151429400256</ReqJnlNo><ResJnlNo>3905251</ResJnlNo><ResTime>2018-11-15 14:05:47</ResTime><ResCode>000000</ResCode><ResMsg></ResMsg></Head></Message>";

            var result = XmlHelper.XmlDeserialize<BTrsInResponse>(xml);

            return true;
        }

        public static string TltSingleOntimePay()
        {
            //SingleOntimePayRquest request = new SingleOntimePayRquest();

            //request.INFO.REQ_SN = "";

            //request.TRANS.BUSINESS_CODE = "09900";
            //request.TRANS.SUBMIT_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");
            //request.TRANS.ACCOUNT_NO = "6212826925653848264";
            //request.TRANS.ACCOUNT_NAME = "章寿尘";
            //request.TRANS.ACCOUNT_PROP = "0";
            //request.TRANS.AMOUNT = 1;


            //var response = tltExec.Exec(request);

            return "";
        }

        /// <summary>
        /// 开户
        /// </summary>
        /// <returns></returns>
        public static string Create()
        {
            BCifAcctNoOpenRequest request = new BCifAcctNoOpenRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();//"t1541553972983s1";

            request.Body.CifAddr = "北京市复兴门外大街";
            request.Body.CifClientId = cifClientId;
            request.Body.CifEnName = "quanyi";
            request.Body.CifIdExpiredDate = "20190909";
            request.Body.CifName = "廖一";
            request.Body.CifPhoneCode = "15600110011";
            request.Body.CifPostCode = "100000";
            request.Body.IdNo = "460031198806150013";
            request.Body.IdType = "P00";
            request.Body.OperateType = "0";
            request.Body.ProvinceCode = "110000";
            request.Body.CityCode = "1101001";
            request.Body.NetCheckFlag = "0";
            request.Body.BankCardPhoneCode = "15600110011";
            request.Body.BankCardType = "1";
            request.Body.BankAcNo = "6212260200000110001";
            request.Body.BankName = "工商银行";
            request.Body.SubBranchName = "北京分行";
            request.Body.OpenChannel = "1";

            var result = guangDaExec.Exec(request) as BCifAcctNoOpenResponse;

            return "OK";
        }

        /// <summary>
        /// 开户
        /// </summary>
        /// <returns></returns>
        public static string Create1()
        {
            AuthenticationToOpenAccountRequest request = new AuthenticationToOpenAccountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.CifName = "张三";
            request.Body.CifClientId = GuidHelper.To16String();
            request.Body.IdType = "P00";
            request.Body.IdNo = "110101199003074477";
            request.Body.BankCardPhoneCode = "17620132005";
            request.Body.CifPhoneCode = "17620132005";
            request.Body.CifIdExpiredDate = "20190909";
            request.Body.CifAddr = "北京市复兴门外大街";
            request.Body.CifPostCode = "100000";
            request.Body.CifEnName = "liaoyz";
            request.Body.CifENFName = "liaoyz";
            request.Body.OperateType = "0";
            request.Body.NetCheckFlag = "0";
            request.Body.BankCardType = "1";
            request.Body.BankAcNo = "6212260200000110002";
            request.Body.BankName = "工商银行";
            request.Body.SubBranchName = "北京分行";
            request.Body.OpenChannel = "1";
            request.Body.BookDate = DateTime.Now.ToString("yyyyMMdd");

            var result = guangDaExec.Exec(request) as AuthenticationToOpenAccountResponse;

            return "IsOK:" + result.IsOK;
        }

        /// <summary>
        /// 开户查询
        /// </summary>
        /// <returns></returns>
        public static string Create1Check()
        {
            AuthenticationToOpenAccountCheckRequest request = new AuthenticationToOpenAccountCheckRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.CifClientId = cifClientId;
            request.Body.BookDate = DateTime.Now.ToString("yyyyMMdd");

            var result = guangDaExec.Exec(request) as AuthenticationToOpenAccountCheckResponse;

            return "IsOK:" + result.IsOK;
        }

        /// <summary>
        /// 身份证上传
        /// </summary>
        /// <returns></returns>
        public static string UploadIdCardImage()
        {
            UploadIdCardImageRequest request = new UploadIdCardImageRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.IdCardFront = Framework.Common.ImageHelper.ToBase64(@"D:\MyProject\AIPXiaoTong\GuangDaTest\bin\Debug\QQ1.png");
            request.Body.IdCardBehind = Framework.Common.ImageHelper.ToBase64(@"D:\MyProject\AIPXiaoTong\GuangDaTest\bin\Debug\QQ2.png");
            request.Body.CifClientId = cifClientId;

            var result = guangDaExec.Exec(request) as UploadIdCardImageResponse;

            return "OK";
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public static BTrsInResponse Recharge()
        {
            BTrsInRequest request = new BTrsInRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.CifClientId = cifClientId;
            request.Body.Amount = "10.02";
            request.Body.TrsType = "0";
            request.Body.Currency = "CNY";
            request.Body.Remark = "资金转入";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";

            var result = guangDaExec.Exec(request) as BTrsInResponse;

            return result;
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <returns></returns>
        public static CurrentFundFreezeResponse Freeze()
        {
            CurrentFundFreezeRequest request = new CurrentFundFreezeRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.CifClientId = cifClientId;
            request.Body.FreezeType = "0";
            request.Body.Currency = "CNY";
            request.Body.CEFlag = "0";
            request.Body.ThawDate = DateTime.Now.AddDays(1).ToString("yyyyMMdd");
            request.Body.Amount = "10.02";
            request.Body.ProtocolNo = "";
            request.Body.GroupNo = "";
            request.Body.TravelStartDay = "";
            request.Body.TravelEndDay = "";
            request.Body.ProtocolDate = "";
            request.Body.Remark = "";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";
            request.Body.Reserve4 = "";
            request.Body.Reserve5 = "";

            var result = guangDaExec.Exec(request) as CurrentFundFreezeResponse;

            return result;
        }

        /// <summary>
        /// 解冻
        /// </summary>
        /// <returns></returns>
        public static UnfrozenFixedDepositResponse Unfreeze(string coPatrnerJnlNo)
        {
            UnfrozenFixedDepositRequest request = new UnfrozenFixedDepositRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.TrsDate = "20181115";
            request.Body.CoPatrnerJnlNo = coPatrnerJnlNo;
            request.Body.ManageFlag = "5";
            request.Body.Currency = "CNY";

            var result = guangDaExec.Exec(request) as UnfrozenFixedDepositResponse;

            return result;
        }

        /// <summary>
        /// 提现，五万以下
        /// </summary>
        /// <returns></returns>
        public static EComGAmountResponse SmallWithdraw()
        {
            EComGAmountRequest request = new EComGAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.Amount = "0.02";
            request.Body.CifClientId = cifClientId;
            request.Body.Currency = "CNY";
            request.Body.ChannelSeq = GuidHelper.GenUniqueId();
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.WDType = "1";
            request.Body.Remark = "提现";
            request.Body.WDName = "李安安";
            request.Body.IdType = "P00";
            request.Body.IdNo = "110101199003071292";
            request.Body.WDAcNo = "6212260200000110005";
            request.Body.WDBankNo = "102100099996";
            request.Body.WDInnerBankFlag = "1";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";

            var result = guangDaExec.Exec(request) as EComGAmountResponse;

            return result;
        }

        /// <summary>
        /// 提现，五万以上
        /// </summary>
        /// <returns></returns>
        public static BJUnionPayPaymentResponse LargeWithdraw()
        {
            BJUnionPayPaymentRequest request = new BJUnionPayPaymentRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CifClientId = cifClientId;
            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.Currency = "CNY";
            request.Body.AcNo = "460031198806150013";
            request.Body.PayeeName = "廖一";
            request.Body.PayeeBankName = "工商银行";
            request.Body.PayeeBankNo = "102100099996";
            request.Body.AcType = "2";
            request.Body.Amount = "0.1";
            request.Body.TransferFee = "0";
            request.Body.Remark = "提现";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";
            request.Body.Reserve4 = "";
            request.Body.Reserve5 = "";

            var result = guangDaExec.Exec(request) as BJUnionPayPaymentResponse;

            return result;
        }

        /// <summary>
        /// 对账
        /// </summary>
        /// <returns></returns>
        public static string CheckFile()
        {
            BFinFundServiceReqRequest request = new BFinFundServiceReqRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.QryDate = "20181225";
            request.Body.ServiceId = "BMerCheckJnlFileReq";

            var result = guangDaExec.Exec(request) as BFinFundServiceReqResponse;

            return "OK";
        }

        /// <summary>
        /// 2.9.资金变动查证接口
        /// </summary>
        /// <returns></returns>
        public static string BTrsVeriAmount()
        {
            BTrsVeriAmountRequest request = new BTrsVeriAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = "201812061704393760";
            request.Body.TrsDate = "20181206";

            var result = guangDaExec.Exec(request) as BTrsVeriAmountResponse;

            return "OK";
        }

        public static string BCifAcNoAmount()
        {
            BCifAcNoAmountRequest request = new BCifAcNoAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CifClientId = "81ac0a0c2f038fd5";

            var result = guangDaExec.Exec(request) as BCifAcNoAmountResponse;

            return "全部余额：" + result?.Body?.AcNoBlance;
        }

        public static string QueryFreezeCombination()
        {
            QueryFreezeCombinationRequest request = new QueryFreezeCombinationRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();
            request.Body.StartCount = 0;
            request.Body.QryCount = 99;
            request.Body.UnfreezeDate = "20190501";

            request.Body.CifClientId = "81ac0a0c2f038fd5";

            var result = guangDaExec.Exec(request) as QueryFreezeCombinationResponse;

            return "OK";
        }



        public static string GetALPath()
        {
            AutoLoginRequest request = new AutoLoginRequest();
            request.mchId = "1007041";
            request.umCode = "";
            // request.redirectUrl = "https://bank-static-stg.pingan.com.cn/bbc/index/landing.html?menuId=M001";
            // request.state = "http://127.0.0.1?orderNo=9230081801252567832175";


            request.clientIdType = "1";
            request.clientIdNo = "430981199211104634";
            request.clientName = "刘旭";
            request.telNo = "15273738880";
            request.accNo = "6230580000000003389";
            request.thirdMid = "15273738880";
            request.timestamp = "1548210608083";

            var result = pingAnExec.GetAutoLoginPath(request);

            return "ok";
        }

        private static string RSASign(string text)
        {
            string result = "";
            Program p = new Program();
            string url = "https://bbc-stg1.pingan.com.cn:6443/bbc/openapi/bron_bbc_margins.preparedFreezeOrderInfo";

            string privateKey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCBB2JJ2+JVKTFF/p8YBFR2xhJYKZ36SSdffV9Aji+fq9M6IkGFE9VEbijqnoVNbBcfCeDL8+HZxg0g/gq14mmc3QFNed4rjWDawIgWOWpH661SWAmru0fxddsVfv/qPEvotpJLYLZmoB6g+wewk48QBhiZukjWK0mypj/ileUUMDecvjDB0ktP4/XUE/F+gWAL4AJdUE/UDK9KAYDRl6MSBkVPZoZVmUxQVst/1m3AENGxqJdBF8zpAwr8z3q4Yo5gtsXAUxcTWFI0Ev3LH8GVmuZA71C1zpnAWzFQ2LVgPjoFTlFiF5CJ5rlHbwVLUG4KG5pcr/gCyBRSmrqkhYJlAgMBAAECggEAMxSSQ70qAB7bo+MmZqKoMZE+h+qJ4SD+1l3SzMK9dc/XQod3OtDcOEgIKMHy8fCdwqrtdLCrM8SlQ+9unAzzVKdlsZ9SZhmFQ3S/K1U1jx1tM1EpGvR8icnnnr31YGzYfFty1SaHb19qYL6gj7YLCAPxz0IhPbBLb89DMVe4JeJTVUxKGmsZEhWz/AMbZxWH+dvQjQ174MXD0tLLgiz72Dih5qHwYBEWmkYU0t+iWWx+EEuseYvS9BRR90wQW3bGYYXMtLfkvivBSvftlndRUdEuw844GwqJaBwdGi+6jTM4yUNsosgEl8yqm0ch4bA0o7fQeKlO2z19BflPrpPzoQKBgQDSymYAzfTjYjLmwaoRnh2J2rccxGkSesUz0rUxtBsL35C5ZMiaA9KWIkKqb+tgQcOMidmytP2LbaACwdmHU1UWST9nU5c19nPQQcj+HvqfAb9DTBk+8fbnurdofwP0SuC5fKD+iU9XkIZrpE3JVduLeXDQ02BKviec0x38wOwKDQKBgQCcs8zFqvmj/L23s8Slpjl6GWbqvUNPPriA0WhT/+kMfANdNpWvH8P7UxVF08EgIbEFXgUsbSgYI90WObyoBnI+Gaes8QFeRoRFGWZXWNGm+1us2mcQ9A5u6PYIrRP8FsdJX1eM8RuV2q/qkqUEQt9WTlsyrLnmbqWnfJVDxBZ7uQKBgQCqGolcRthDkuBO1aQ/2WAu+iBhB6NfNVHkszpjpNtapoys/8beew06+OThk7XXlNqQlEHo9CPTm6DP+M1pZnc4p92RraRN+NeXDS9821UWcht93HBXGn5MnKIborx3LOHS7d8h6X7sxAWl4g6f1jh4goTnEF0ZlAB1ju0ZJjqVFQKBgAPoL7jV9Hd0O76yyrpelJxIudoscdst8yezEOjXPpZDGUpfrAe7wQUpIySkjPIiJOm/WF2tMwy3CDIfqmZ+EqcduKKFN8WD+JRId9bBrih9p+F9aIhxrVJymH/K4O6uGrXnnKU09b0cwLoWgerDSBI8zeVLjS8Dnzm3z3jrEKxxAoGAJLQNmsepFEL934zXtMteD4WWeEvM47pYZLm4g0tvQMQnSav4Xf3oTvar9VyfjXINWVrqs/qZbgjHaPGRhqXmw2RAFEkVe37Hny8uKD2i14x86Yz9u5qCveHEsPf3Gyr40JFD/zO0mt/BNezp++ECR52DewItw+yW6cIrEM+yYLE=";
            string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAy/o0tFwhKNnT4A5XMhNlOe4vE9zMmbg6/kqWxEAO5TzALA+iJ3jp++c96PgItfOVimQhkcacV0Xenn4iK0wTIlZQtVfV0k4ZJGSNj0DGgh9GIeCf2fb0D8YJ1kgtAj8SpWh4jEae7k3onBpAMyl0+8PHUDfIcgvFArMMZiMpt5MIW9LtSHLqOcaKJGTsfdZfDcP+ve3OR+k9m1iu73PBh6wGjB9yvs/eEtL9DsQmZdOPSRr48iKdCUoXTkzbt6XP55GKX/li10m/UwdhnAo5CS8HfetesF4fDowZSNQ+tYDtSM+PgSWnESQcjSHLfdFsTiezFuINGK+JhzLTK1NQrQIDAQAB";

            var sign = Framework.Security.RSAHelper.SHA1WithRSA(text, privateKey);
            string a = text + "&sign=" + sign;

            result = Request.Post(url, text + "&sign=" + sign, System.Net.SecurityProtocolType.Tls12);

            var sortresult = p.StortJson(result);

            JObject nosign = JObject.Parse(sortresult);
            nosign.Remove("sign");
            string content = "data=" + JObject.Parse(sortresult)["data"].ToString() + "&responseCode=" + JObject.Parse(sortresult)["responseCode"].ToString() + "&responseMsg=" + JObject.Parse(sortresult)["responseMsg"].ToString() + "";

            //------------------------------------------
            //content = "";
            //var signtest = "";
            //------------------------------------------

            if (!RSAHelper.SHA1WithRSAVerify(content, JObject.Parse(sortresult)["sign"].ToString(), publicKey))
            {
                throw new Exception("error返回验签失败");
            }

            return sign;
        }

        public string StortJson(string json)
        {
            var dic = JsonConvert.DeserializeObject<SortedDictionary<string, object>>(json);
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>(dic);
            keyValues.OrderBy(m => m.Key);//升序 
            return JsonConvert.SerializeObject(keyValues);
        }

        private static string GetBBCOrserInfo(string text)
        {
            string result = "";
            string url = "https://bbc-stg1.pingan.com.cn:6443/bbc/openapi/bron_bbc_margins.qryMarginsOrderDetialByCustomer";

            string privateKey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCBB2JJ2+JVKTFF/p8YBFR2xhJYKZ36SSdffV9Aji+fq9M6IkGFE9VEbijqnoVNbBcfCeDL8+HZxg0g/gq14mmc3QFNed4rjWDawIgWOWpH661SWAmru0fxddsVfv/qPEvotpJLYLZmoB6g+wewk48QBhiZukjWK0mypj/ileUUMDecvjDB0ktP4/XUE/F+gWAL4AJdUE/UDK9KAYDRl6MSBkVPZoZVmUxQVst/1m3AENGxqJdBF8zpAwr8z3q4Yo5gtsXAUxcTWFI0Ev3LH8GVmuZA71C1zpnAWzFQ2LVgPjoFTlFiF5CJ5rlHbwVLUG4KG5pcr/gCyBRSmrqkhYJlAgMBAAECggEAMxSSQ70qAB7bo+MmZqKoMZE+h+qJ4SD+1l3SzMK9dc/XQod3OtDcOEgIKMHy8fCdwqrtdLCrM8SlQ+9unAzzVKdlsZ9SZhmFQ3S/K1U1jx1tM1EpGvR8icnnnr31YGzYfFty1SaHb19qYL6gj7YLCAPxz0IhPbBLb89DMVe4JeJTVUxKGmsZEhWz/AMbZxWH+dvQjQ174MXD0tLLgiz72Dih5qHwYBEWmkYU0t+iWWx+EEuseYvS9BRR90wQW3bGYYXMtLfkvivBSvftlndRUdEuw844GwqJaBwdGi+6jTM4yUNsosgEl8yqm0ch4bA0o7fQeKlO2z19BflPrpPzoQKBgQDSymYAzfTjYjLmwaoRnh2J2rccxGkSesUz0rUxtBsL35C5ZMiaA9KWIkKqb+tgQcOMidmytP2LbaACwdmHU1UWST9nU5c19nPQQcj+HvqfAb9DTBk+8fbnurdofwP0SuC5fKD+iU9XkIZrpE3JVduLeXDQ02BKviec0x38wOwKDQKBgQCcs8zFqvmj/L23s8Slpjl6GWbqvUNPPriA0WhT/+kMfANdNpWvH8P7UxVF08EgIbEFXgUsbSgYI90WObyoBnI+Gaes8QFeRoRFGWZXWNGm+1us2mcQ9A5u6PYIrRP8FsdJX1eM8RuV2q/qkqUEQt9WTlsyrLnmbqWnfJVDxBZ7uQKBgQCqGolcRthDkuBO1aQ/2WAu+iBhB6NfNVHkszpjpNtapoys/8beew06+OThk7XXlNqQlEHo9CPTm6DP+M1pZnc4p92RraRN+NeXDS9821UWcht93HBXGn5MnKIborx3LOHS7d8h6X7sxAWl4g6f1jh4goTnEF0ZlAB1ju0ZJjqVFQKBgAPoL7jV9Hd0O76yyrpelJxIudoscdst8yezEOjXPpZDGUpfrAe7wQUpIySkjPIiJOm/WF2tMwy3CDIfqmZ+EqcduKKFN8WD+JRId9bBrih9p+F9aIhxrVJymH/K4O6uGrXnnKU09b0cwLoWgerDSBI8zeVLjS8Dnzm3z3jrEKxxAoGAJLQNmsepFEL934zXtMteD4WWeEvM47pYZLm4g0tvQMQnSav4Xf3oTvar9VyfjXINWVrqs/qZbgjHaPGRhqXmw2RAFEkVe37Hny8uKD2i14x86Yz9u5qCveHEsPf3Gyr40JFD/zO0mt/BNezp++ECR52DewItw+yW6cIrEM+yYLE=";
            // string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAy/o0tFwhKNnT4A5XMhNlOe4vE9zMmbg6/kqWxEAO5TzALA+iJ3jp++c96PgItfOVimQhkcacV0Xenn4iK0wTIlZQtVfV0k4ZJGSNj0DGgh9GIeCf2fb0D8YJ1kgtAj8SpWh4jEae7k3onBpAMyl0+8PHUDfIcgvFArMMZiMpt5MIW9LtSHLqOcaKJGTsfdZfDcP+ve3OR+k9m1iu73PBh6wGjB9yvs/eEtL9DsQmZdOPSRr48iKdCUoXTkzbt6XP55GKX/li10m/UwdhnAo5CS8HfetesF4fDowZSNQ+tYDtSM+PgSWnESQcjSHLfdFsTiezFuINGK+JhzLTK1NQrQIDAQAB";

            var sign = Framework.Security.RSAHelper.SHA1WithRSA(text, privateKey);

            string a = text + "&sign=" + sign;

            result = Request.Post(url, text + "&sign=" + sign, System.Net.SecurityProtocolType.Tls12);

            return result;
        }

        public static string PreparedFreezeOrder()
        {
            PreparedFreezeOrderRequest request = new PreparedFreezeOrderRequest();
            request.channel = "1007041";
            request.userName = "章寿尘";
            request.cardNumber = "330219196609107006";
            request.mobile = "15601010001";
            request.businessName = "保证金流程测试01";
            request.orderValidDay = 10;
            request.freezeAmt = 0.02;
            request.freezeTimeLimit = 10;
            request.freezeProduct = 1;
            request.autoFreeze = "00";
            request.transCode = "001";
            // request.remark = "dasdasdasdsadasdas";

            var result = pingAnExec.Exec(request) as PreparedFreezeOrderResponse;

            return "OK";
        }

        /// <summary>
        /// 查询单个预下单订单接口
        /// </summary>
        /// <returns></returns>
        public static string QueryMarginsOrderDetail()
        {
            QueryMarginsOrderDetailRequest request = new QueryMarginsOrderDetailRequest();
            request.channel = "1007041";
            request.bankOrderNo = "9230081902222616264156";
            request.cardNumber = "330219196609107006";
            request.accountType = "";  //1一类户2二类户
            request.transCode = "002";

            var response = pingAnExec.Exec(request) as QueryMarginsOrderDetailResponse;

            return "ok";
        }

        /// <summary>
        /// 查询预下单订单接口(批量)
        /// </summary>
        /// <returns></returns>
        public static string QueryBatchMarginsOrderDetial()
        {
            QueryBatchMarginsOrderDetialRequest request = new QueryBatchMarginsOrderDetialRequest();
            request.channel = "1007041";
            request.transCode = "018";
            request.pageIndex = 1;
            request.pageSize = 2;
            request.commercialNoII = "";
            request.commercialOrderNo = "";
            request.bankOrderNo = "";
            request.activityNo = "";
            request.productCode = "";
            request.cardNumber = "";
            request.userName = "";
            request.freezeStartTime = "";
            request.freezeEndTime = "";

            var response = pingAnExec.Exec(request) as QueryBatchMarginsOrderDetialResponse;

            return "ok";
        }

        public static string UnFreezeMarginsOrder()
        {
            UnFreezeMarginsOrderRequest request = new UnFreezeMarginsOrderRequest();
            request.channel = "1007041";
            request.bankOrderNo = "9230081902222616264156";
            request.cardNumber = "330219196609107006";
            request.transCode = "004";

            var response = pingAnExec.Exec(request) as UnFreezeMarginsOrderResponse;

            return "ok";
        }


        private static Dictionary<string, string> GetAccountResult(string predata)
        {
            var result = new Dictionary<string, string>();

            //-------------------new key---------------------
            //string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgQdiSdviVSkxRf6fGARUdsYSWCmd+kknX31fQI4vn6vTOiJBhRPVRG4o6p6FTWwXHwngy/Ph2cYNIP4KteJpnN0BTXneK41g2sCIFjlqR+utUlgJq7tH8XXbFX7/6jxL6LaSS2C2ZqAeoPsHsJOPEAYYmbpI1itJsqY/4pXlFDA3nL4wwdJLT+P11BPxfoFgC+ACXVBP1AyvSgGA0ZejEgZFT2aGVZlMUFbLf9ZtwBDRsaiXQRfM6QMK/M96uGKOYLbFwFMXE1hSNBL9yx/BlZrmQO9Qtc6ZwFsxUNi1YD46BU5RYheQiea5R28FS1BuChuaXK/4AsgUUpq6pIWCZQIDAQAB";
            //string privateKey = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCBB2JJ2+JVKTFF/p8YBFR2xhJYKZ36SSdffV9Aji+fq9M6IkGFE9VEbijqnoVNbBcfCeDL8+HZxg0g/gq14mmc3QFNed4rjWDawIgWOWpH661SWAmru0fxddsVfv/qPEvotpJLYLZmoB6g+wewk48QBhiZukjWK0mypj/ileUUMDecvjDB0ktP4/XUE/F+gWAL4AJdUE/UDK9KAYDRl6MSBkVPZoZVmUxQVst/1m3AENGxqJdBF8zpAwr8z3q4Yo5gtsXAUxcTWFI0Ev3LH8GVmuZA71C1zpnAWzFQ2LVgPjoFTlFiF5CJ5rlHbwVLUG4KG5pcr/gCyBRSmrqkhYJlAgMBAAECggEAMxSSQ70qAB7bo+MmZqKoMZE+h+qJ4SD+1l3SzMK9dc/XQod3OtDcOEgIKMHy8fCdwqrtdLCrM8SlQ+9unAzzVKdlsZ9SZhmFQ3S/K1U1jx1tM1EpGvR8icnnnr31YGzYfFty1SaHb19qYL6gj7YLCAPxz0IhPbBLb89DMVe4JeJTVUxKGmsZEhWz/AMbZxWH+dvQjQ174MXD0tLLgiz72Dih5qHwYBEWmkYU0t+iWWx+EEuseYvS9BRR90wQW3bGYYXMtLfkvivBSvftlndRUdEuw844GwqJaBwdGi+6jTM4yUNsosgEl8yqm0ch4bA0o7fQeKlO2z19BflPrpPzoQKBgQDSymYAzfTjYjLmwaoRnh2J2rccxGkSesUz0rUxtBsL35C5ZMiaA9KWIkKqb+tgQcOMidmytP2LbaACwdmHU1UWST9nU5c19nPQQcj+HvqfAb9DTBk+8fbnurdofwP0SuC5fKD+iU9XkIZrpE3JVduLeXDQ02BKviec0x38wOwKDQKBgQCcs8zFqvmj/L23s8Slpjl6GWbqvUNPPriA0WhT/+kMfANdNpWvH8P7UxVF08EgIbEFXgUsbSgYI90WObyoBnI+Gaes8QFeRoRFGWZXWNGm+1us2mcQ9A5u6PYIrRP8FsdJX1eM8RuV2q/qkqUEQt9WTlsyrLnmbqWnfJVDxBZ7uQKBgQCqGolcRthDkuBO1aQ/2WAu+iBhB6NfNVHkszpjpNtapoys/8beew06+OThk7XXlNqQlEHo9CPTm6DP+M1pZnc4p92RraRN+NeXDS9821UWcht93HBXGn5MnKIborx3LOHS7d8h6X7sxAWl4g6f1jh4goTnEF0ZlAB1ju0ZJjqVFQKBgAPoL7jV9Hd0O76yyrpelJxIudoscdst8yezEOjXPpZDGUpfrAe7wQUpIySkjPIiJOm/WF2tMwy3CDIfqmZ+EqcduKKFN8WD+JRId9bBrih9p+F9aIhxrVJymH/K4O6uGrXnnKU09b0cwLoWgerDSBI8zeVLjS8Dnzm3z3jrEKxxAoGAJLQNmsepFEL934zXtMteD4WWeEvM47pYZLm4g0tvQMQnSav4Xf3oTvar9VyfjXINWVrqs/qZbgjHaPGRhqXmw2RAFEkVe37Hny8uKD2i14x86Yz9u5qCveHEsPf3Gyr40JFD/zO0mt/BNezp++ECR52DewItw+yW6cIrEM+yYLE=";

            //-------------------new key---------------------

            //-------------------old key---------------------
            //string publicKey = "MIGiMA0GCSqGSIb3DQEBAQUAA4GQADCBjAKBhACY3Af30G7Z0+GQA2CsK61tkeINUOSnANaeMQivdopSx+ZAtssMaPCdf02hNHUf1taqxt8Ur5QRvVkMwIt2wfY6p2u0fOs9hLTkIW6cRT3NjjrWVBBtgA3U/y0nkShZi2yEOvcyHS+88wjMWi28pw9siw0mMZpL256bgOwiqzSQXA8CQQIDAQAB";
            //string privateKey = "MIICgwIBADANBgkqhkiG9w0BAQEFAASCAm0wggJpAgEAAoGEAJjcB/fQbtnT4ZADYKwrrW2R4g1Q5KcA1p4xCK92ilLH5kC2ywxo8J1/TaE0dR/W1qrG3xSvlBG9WQzAi3bB9jqna7R86z2EtOQhbpxFPc2OOtZUEG2ADdT/LSeRKFmLbIQ69zIdL7zzCMxaLbynD2yLDSYxmkvbnpuA7CKrNJBcDwJBAgMBAAECgYMNVs4fMwIpYhMB9Tl/bMRSlnNqhA+f/zO7VD4UybxiYu1V4l2vtIyiwdQtaB18bMwI1RfsfzHlpmdZ9Id3EpABKE7PZtHOfVsI0JcKy2Hcq5uIyZ+jXBL5RiBs++4xukCFOj019DR9nJpd40eFXqy3mWLHFkdMXhBlA89/aTc91WbW0QJCDn6x6IjOMNLnuHpnUxgvp40TPj0Nsut1e9SZPHmyQweGvpg6sGTAAYI9OPTE8d4COpwzhh/MPH55XFFFGUXFBF6VAkIKi7W9IVh9b0oZ5FfpXPxyDePrKvQnMgE5OEYR2Ur7wzdyYbBA3Q1LTrHdVzSzDZy5oS1gSQFthkIiOmGOa3ZKJf0CQgNQONDj/OYyP9/usxHOlI4jdIOkpy4AHvH4jjLBytsBrG6DE99gmHd/0wjjAuYbDr1hGXIOcLxfWNSei0IUrc2q5QJCCf2CZLJjRykXtOGZ2qxJRq8b/JvLghogCJnj32LPYyPzsfsTYs9GmdHqM7o6ZWl+0Gf9OZrPrHckzZIq+yWYgPPtAkIH+7WfrtKtcO2tMJ+vcs9GOMwW+ONEHaSowAF/PVj5Rddm/MlOrqBjS3gJkG09yphH3sKt8x9Tt5X+ixuPbUvDq9U=";            
            //-------------------old key---------------------

            //-------------------正式 key---------------------
            string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAj7AZGvto8Ie5tiytqX4lKRZ55yU6MpDo2u3Ua6kuCUp+LgqGUKM85DS9GHDOOAkVloIqZx2T0n84o626xu+xpxr8uCSSdcTkWz4XrCBRSdkGemZqdjhXtvxVIST45IMe1PeLGnqxFbgUvnZp2w9orJh/nNGuhR3NBdiwqGQZQ8ehY1UhIAmdY2nS/ZZkpgUJKDzy6+MFZzfkr9Zw+IMvGWFR6JThImhN7IzERjrTG72fvLCW27YTT5SojaChCv+8H3UFB1lTSwKNx8soAVqhWqxwU34ZZFkgEcDkLJWAlcrdyfAwpqP15sJ5B7YX0t/nJo2XOffDwJhvU75XNYTdvQIDAQAB";

            string privateKey = "MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCPsBka+2jwh7m2LK2pfiUpFnnnJToykOja7dRrqS4JSn4uCoZQozzkNL0YcM44CRWWgipnHZPSfzijrbrG77GnGvy4JJJ1xORbPhesIFFJ2QZ6Zmp2OFe2/FUhJPjkgx7U94saerEVuBS+dmnbD2ismH+c0a6FHc0F2LCoZBlDx6FjVSEgCZ1jadL9lmSmBQkoPPLr4wVnN+Sv1nD4gy8ZYVHolOEiaE3sjMRGOtMbvZ+8sJbbthNPlKiNoKEK/7wfdQUHWVNLAo3HyygBWqFarHBTfhlkWSARwOQslYCVyt3J8DCmo/XmwnkHthfS3+cmjZc598PAmG9Tvlc1hN29AgMBAAECggEAfQVtIrQD391IckE3rVUsAi8jTEJw+9RoNy1eeXqPqtfdKDRSH9GYxrs4mQ517/2/geCqAmSS3UGCx6/+5t9iBRMPNy3jHYN+agGB2WuZLxcdctyv30Mw1u+BJsCjqziHWCg3KYf9kvdDXWFsw4UJv7tEte8f2YVPgbnEJBBMh1LO3xbvBHn/0tZq9i0nNAodsGEM+htzi20T3zDYsVn4/zA0Qe6mDwJT0lHcCwEy1NwosS2T/U3cnSU4/cMUHAelo/iEF7zfqj+tAPsqul0XCKw6TAyq//w+36iEmvjaIConDEDptpi928YcCo5sc3FM5ruoQnEFEl9FM/lTPACXJQKBgQD6bOAJ2vpBVCBS37XsB/6vUc0w9J2H0/abYhmFLLvXogis4fPbZJ1YBgN4yX9rwPtg59jd22mgxIf1sWedJFxfdqQGEvffQAix4yBC6rix/ow8FBjAAby1xH1Khx08Oj7SoYiNQZQOwdQSLLjUUn2MMYmvbdHJld6jPlcqPLQRqwKBgQCS4vJ/bm4Ns8F8Sf+RUTNSmA/QEQMH4HF5cmwZQB5xmlTV6j9Qlyje9OrW23d1B25F3WTPkMTKhbCiMzkJy4g5k4ygVaO5aIZiss/TfM2zVmH18TjKnmr7n+mXNyPshagR713yHUmrsW6jZ9srx6+sy2VW3FX/ifnnSvkNyFE2NwKBgHyu9KUzh+I69pUMmVFZca7stZMoV76nBGO85iPub+Ae5t7c6UNUxxpqdBQRjwWhYgePp+ReOCs5btAfcg1Fa1CEi4oSq6NWCH45LXjj0O2eZUgMYX5H3yNJH3CZ8S5peZn5nzlla0glrWcXKTddkvDYQUs9DHSnz9/LTC7VZnpdAoGAcVdhm2cQ0M3l/Qv0gqNPoOnpOboGxqsvpHDgbNOHKk3WLIJmfL9HMFN4anZKxSkItCxTv76Lu2JRm7c+ygodgaATIR00CrtXBw3HQ//HkhyT1n1ePyrijmskiiRoOfggakZ0DYD/+dYd80UOX8fkDMed2NqIGXjUNt8pMrNhxx0CgYBxhGDVyRrLtJLtXnuqQwnhhhfuroIc19jdriwiwjrApoRpn+Zdb9+/qKT0ZjpQLTxtLQeIvk2vZDjvPD9l8c3v3PiNqyt+5OxuezsSx4BLI+dvQkS/eOFGX0p9NXiR7spjyhDFH4gqzq7neaTuZnZI6r00lZThLy93v7KBBNJc5Q==";


            //-------------------正式 key---------------------

            publicKey = RSAHelper.RSAPublicKeyJava2DotNet(publicKey);
            privateKey = RSAHelper.RSAPrivateKeyJava2DotNet(privateKey);

            //publicKey = "<RSAKeyValue><Modulus>sfCDn+4kJZr7DL8aJDAYIGUYGHM6xsMl8pSVbHlUwRVTWvZyeiMELl2Xla7BLNUTm2QCSyov6dQWiHiX1F4am3tstIHPyRVSETfVkkO71O3POrdR1brDu4Qu1eYrEKW7UiWSufiNPk+E3sXFFdy4/seTAcHKr96t2muPJxeHO10=</Modulus><Exponent>AQAB</Exponent><P>9pVL8A1HrdLtI0ctwzcKmWdT+TuklXG+SqTkIjyOd4sUto7W3TF1KzgkL5DTrfWzMjDhNrLUBvHjEbo/N6hqmQ==</P><Q>uLwgmqcnPOxQJPcmd5CUqqLWCCCkozn5kptE0Rj4MAUf9Mtgh5SY8dWY7KjAU3CB2CkTirlMlVEcPQLL5c+1ZQ==</Q><DP>tCUYaFTbZBNv6dELjs38cVw6zh+TuxZxBkl23chN8OnsBP9P3CNQzXVjgliVPUb+VpG9R1/YZQZ8dKwTmU7yKQ==</DP><DQ>YXqz4aeOZvFzoO3hmHnsWNYwBn3jIlZ3QUs5VvTMEdrCcBPZTfG1evbxCQBK7DyT55JVQ4BfzvLL6c3N9ehSmQ==</DQ><InverseQ>xOmJBFhaLw6IFiQEK3O2wvET47SoYuDLD8EPNCxQYmm0EyLdhlizHdddOZduvcrwSB1a+p094MbQ7wEm1936Cg==</InverseQ><D>bpPvyDh+oBwCvXYY8botlBwe8DrToOdvMqPhg+qWn/L3vQSAOaR/Ga0x4WQbShgUOjHZNwq9gcs6QY7nk6LzVvY/UeafSdZBLpGq5HM+CAc7ntnlAW9rKwHXOwUhbMLV2li0u3jIhQwnenTZbFZ2yUXdKVY8bTyyGP59F8O7FaE=</D></RSAKeyValue>";
            // privateKey = "<RSAKeyValue><Modulus>sfCDn+4kJZr7DL8aJDAYIGUYGHM6xsMl8pSVbHlUwRVTWvZyeiMELl2Xla7BLNUTm2QCSyov6dQWiHiX1F4am3tstIHPyRVSETfVkkO71O3POrdR1brDu4Qu1eYrEKW7UiWSufiNPk+E3sXFFdy4/seTAcHKr96t2muPJxeHO10=</Modulus><Exponent>AQAB</Exponent><P>9pVL8A1HrdLtI0ctwzcKmWdT+TuklXG+SqTkIjyOd4sUto7W3TF1KzgkL5DTrfWzMjDhNrLUBvHjEbo/N6hqmQ==</P><Q>uLwgmqcnPOxQJPcmd5CUqqLWCCCkozn5kptE0Rj4MAUf9Mtgh5SY8dWY7KjAU3CB2CkTirlMlVEcPQLL5c+1ZQ==</Q><DP>tCUYaFTbZBNv6dELjs38cVw6zh+TuxZxBkl23chN8OnsBP9P3CNQzXVjgliVPUb+VpG9R1/YZQZ8dKwTmU7yKQ==</DP><DQ>YXqz4aeOZvFzoO3hmHnsWNYwBn3jIlZ3QUs5VvTMEdrCcBPZTfG1evbxCQBK7DyT55JVQ4BfzvLL6c3N9ehSmQ==</DQ><InverseQ>xOmJBFhaLw6IFiQEK3O2wvET47SoYuDLD8EPNCxQYmm0EyLdhlizHdddOZduvcrwSB1a+p094MbQ7wEm1936Cg==</InverseQ><D>bpPvyDh+oBwCvXYY8botlBwe8DrToOdvMqPhg+qWn/L3vQSAOaR/Ga0x4WQbShgUOjHZNwq9gcs6QY7nk6LzVvY/UeafSdZBLpGq5HM+CAc7ntnlAW9rKwHXOwUhbMLV2li0u3jIhQwnenTZbFZ2yUXdKVY8bTyyGP59F8O7FaE=</D></RSAKeyValue>";

            //var pub = RSAHelper.RSAPublicKeyDotNet2Java(publicKey);
            //var pri = RSAHelper.RSAPrivateKeyDotNet2Java(privateKey);

            string encryptData = byteToHexStr(SectionEncrypt(predata, publicKey)); //加密转16进制

            string decryptData = System.Text.Encoding.UTF8.GetString(SectionDecrypt(HexStrTobyte(encryptData), privateKey));  //解密


            return result;
        }

        private static string BBCAutoLogin(string text)
        {
            // string channel = "1007041";
            string mchId = "1007041";
            string url = "https://rmb-stg.pingan.com.cn/brcp/uc/cust/uc-third-auth.autoLogin.do";
            //平安分配公钥
            string publicKey = "MIGiMA0GCSqGSIb3DQEBAQUAA4GQADCBjAKBhACGeGMZ03Z7dMDgU7CcqN7Omlto1wEg+Y6g5ZvTzplhXOHSmtkyG3b3wYVg/aQeyWt2A6r7mbLaUx9TWDIdG/gKRluR7egYY1/3Ql0yp40XFn5MLXmEKXUS9th8IvdwL2KJU7sYNpR4cQ7LT21F/E6ejsUQ9DGyr7unNE4Hfk6eRCoVvQIDAQAB";
            // 平安分配加签key
            string sha1Key = "b34dc091889949cc86e85978355756b4";

            //解密私钥（平安单独给测试使用）
            string privateKey = "MIICgwIBADANBgkqhkiG9w0BAQEFAASCAm0wggJpAgEAAoGEAIZ4YxnTdnt0wOBTsJyo3s6aW2jXASD5jqDlm9POmWFc4dKa2TIbdvfBhWD9pB7Ja3YDqvuZstpTH1NYMh0b+ApGW5Ht6BhjX/dCXTKnjRcWfkwteYQpdRL22Hwi93AvYolTuxg2lHhxDstPbUX8Tp6OxRD0MbKvu6c0Tgd+Tp5EKhW9AgMBAAECgYNddu/q04BW7x/gzErFmNrE36UJiefO86afTviwj7ksY1LS/65XlZ9rNadvctzQSU/YB1Sg7IPUHFJ5q6Opd/c/rPdwNBcGy555fy5SOWzJcIt5z8L8TjEzNdarZBzmccf0I2cnTnXP6/HI9/sWIBcptmq/8N5BYKz7DLrHcqU2+hPuQQJCDGxeGTxXvAd+fRtoo7VqUBopwm5OKGjVCdFGcIEEPpNgjeEFG7Uyl++izxycz8AkPnmHzjAjpT8HEIE2UL6nZ/ybAkIK0vN84ckSDxH4oX96rMUmfnj84oGS+TiuYSgxRZaaWeBR7q/TDPfHN+BjdHuQzC0V+hbiu6bkhprRsBuuJqcJoIcCQgkyOuHRYlyk64QuwuHUjBMpmtn7j02odHMlAFCNoJe1vtanyIE/O2lvEYTg+E9tOycoDVibF/fd1RvpmkxhJUj7mwJCBClDOFBpB4tJomcb5iKDjJ/0jWva2pD7THbHh+Gz21UQGw+DAsUqgKknl7SRSIJmFtvVbocryxFAdbqZeaMcdmQDAkIElWcngyJ4zcxsjM9QjzDKRuf2e9+B0C0tzSoqUP5dQYuVykRx9QLbZyz/QR0mPiSyN0S8WJ4EcsPQ3e+59qWqwog=";

            //参数加签
            string signature = Framework.Security.Crypt.SHA1(text.ToLower() + sha1Key).ToLower();
            string predata = text + "&signature=" + signature;

            //重定向地址
            string redirectUrl = System.Web.HttpUtility.UrlEncode("https://bank-static-stg.pingan.com.cn/bbc/index/landing.html?menuId=M001", System.Text.Encoding.UTF8);

            string returnUrl = HttpUtility.UrlEncode("http://127.0.0.1?orderNo=9230081902142615914178", Encoding.UTF8);

            string state = HttpUtility.UrlEncode("returnUrl=" + returnUrl, Encoding.UTF8);

            // string ab = "clientIdNo=430981199211104634&clientIdType=1&clientName=bryce&telNo=15273738880&thirdMid=15273738880&timestamp=1548210608083&signature=aabadc7b8053e04b25cacef33803e5f3a16041cc";

            publicKey = RSAHelper.RSAPublicKeyJava2DotNet(publicKey);
            privateKey = RSAHelper.RSAPrivateKeyJava2DotNet(privateKey);

            string encryptData = byteToHexStr(SectionEncrypt(predata, publicKey));

            //-----------------------自主产生秘钥，测试加密解密方法（SectionEncrypt）RSA分段加密---------------------------------
            var keys = GenerateKeys();
            var privatekey2 = keys[0];
            var publickey2 = keys[1];

            var privatekey2java = RSAHelper.RSAPrivateKeyDotNet2Java(privatekey2);
            var publickey2java = RSAHelper.RSAPublicKeyDotNet2Java(publickey2);

            var encryptResult = SectionEncrypt(predata, publickey2);
            var decryptResult = System.Text.Encoding.UTF8.GetString(SectionDecrypt(encryptResult, privatekey2));
           // var encryptData = HexHelper.byteTo16HexStr(SectionEncrypt(predata, publicKey));
            //-------------------------------------------------------------------

            //------------------------平安公私钥加密解密测试--------------------------------------
            //var publicKey3 = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDEG6x4DxF96dc16BFWbZtJodAwFIE3280CmF1rHQBKqMfcEMe+LXvYZsTwA0Wty5Z0IzOBZQfGJhu//rpEfkIEyG3O8tLNMKNrOokECs/8/U7zdz7TecMGoDAL74GFYaQa2lQddX6d3qGWRYUrp8muCtWbxICocox+xzrD7AV+DQIDAQAB";
            //var privateKey3 = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAMQbrHgPEX3p1zXoEVZtm0mh0DAUgTfbzQKYXWsdAEqox9wQx74te9hmxPADRa3LlnQjM4FlB8YmG7/+ukR+QgTIbc7y0s0wo2s6iQQKz/z9TvN3PtN5wwagMAvvgYVhpBraVB11fp3eoZZFhSunya4K1ZvEgKhyjH7HOsPsBX4NAgMBAAECgYBwXKLPD2MoT8ldO6Bjct2crLgKNFVtWeT27bHo4279WANbVcn8bzccYJXKJzXPRGzqEhk6tFZl9APGV/8Fq4nLDhlnunWn4DK1ED1xpOgRauc/xvtbk8Vh34tJiwpsgcZErECix6VAqYhAXewuXRRXtn4zzQfVpQWbVPY8QbP0iQJBAPOvQ+QlnmntuYWOsvk9LpY3CIc2WnpSykXG4jj5/463VXlAy/lZ92y4L7GqxeehV6JBORLed85WN4C5Ksz4VAMCQQDOBN/ecISD2kTIawaQU+sxiyvI63QG4+s3uoszvcC5958di5ZCPATLfQr2Np+qBdzKd4uQTE+rUi/qHg2e1rCvAkAonGrqGMLf0Hh8o518IBAlhKJtNke53xZKrqyA5lkKxc7+2CemNLIhckiwiU9WHPNn3QrP9DdvMbsqPrG9Wx1VAkEAjaYEVmh+dDmqeTI8/Rb16saJgEeDKwmiPFriQt0AmdyLZkEHOtsRYOfElazQ8pG9UOgI6VnOnTiRASNQshliuQJAJ+a0XdtNQwm0Jk98u3ScpPJ/+W8iZI166LTv6IPiOGFpLnJfdZCsCn7U2/xByk446j5hxbSvGdfVlwAZGALb5Q==";
            //var encryptResult = RSAHelper.SectionEncrypt(predata, RSAHelper.RSAPublicKeyJava2DotNet(publicKey3));
            //var decryptResult = System.Text.Encoding.Default.GetString(RSAHelper.SectionDecrypt(encryptResult, RSAHelper.RSAPrivateKeyJava2DotNet(privateKey3)));

            // var decryptResult = SectionDecrypt(Convert.ToBase64String(SectionEncrypt(predata, publicKey)), privateKey);


            //--------------------------------------------
            //string urlpath = url + "?mchId=" + mchId + "&encryptData=" + encryptData;
            string urlpath = url + "?mchId=" + mchId + "&encryptData=" + encryptData + "&redirectUrl=" + redirectUrl + "&state=" + state;

            return urlpath;
        }


        /// <summary>
        /// RSA分段加密;用于对超长字符串加密
        /// </summary>
        /// <param name="toEncryptString">需要进行加密的字符串</param>
        /// <param name="publickKey">公钥</param>
        /// <returns>加密后的密文</returns>
        public static byte[] SectionEncrypt(string toEncryptString, string publickKey)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = System.Text.Encoding.UTF8.GetBytes(toEncryptString);

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.FromXmlString(publickKey);

            int MaxBlockSize = RSA.KeySize / 8 - 11;

            if (dataToEncrypt.Length <= MaxBlockSize)
            {
                byte[] encrytedData;

                encrytedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                return encrytedData;
            }

            MemoryStream plaiStream = new MemoryStream(dataToEncrypt);

            MemoryStream CrypStream = new MemoryStream();

            Byte[] Buffer = new Byte[MaxBlockSize];

            int BlockSize = plaiStream.Read(Buffer, 0, MaxBlockSize);

            while (BlockSize > 0)
            {
                Byte[] ToEncrypt = new Byte[BlockSize];
                Array.Copy(Buffer, 0, ToEncrypt, 0, BlockSize);

                Byte[] Cryptograph = RSAEncrypt(ToEncrypt, RSA.ExportParameters(false), false);
                CrypStream.Write(Cryptograph, 0, Cryptograph.Length);
                BlockSize = plaiStream.Read(Buffer, 0, MaxBlockSize);

            }
            return CrypStream.ToArray();
        }

        private static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.ImportParameters(RSAKeyInfo);

            return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        }

        /// <summary>
        /// RSA分段解密;用于对超长字符串解密
        /// </summary>
        /// <param name="toEncryptString">需要进行解密的字符串</param>
        /// <param name="publickKey">私钥</param>
        /// <returns>解密后的明文</returns>
        public static byte[] SectionDecrypt(byte[] toDecryptByte, string privateKey)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey);
            ;
            byte[] CiphertextData = toDecryptByte;

            int MaxBlockSize = RSA.KeySize / 8;

            if (CiphertextData.Length <= MaxBlockSize)
            {
                byte[] decryptedData;

                decryptedData = RSADecrypt(CiphertextData, RSA.ExportParameters(true), false);

                return decryptedData;
            }

            MemoryStream CrypStream = new MemoryStream(CiphertextData);

            MemoryStream PlaiStream = new MemoryStream();

            Byte[] Buffer = new Byte[MaxBlockSize];

            int BlockSize = CrypStream.Read(Buffer, 0, MaxBlockSize);

            while (BlockSize > 0)
            {
                Byte[] ToDecrypt = new Byte[BlockSize];
                Array.Copy(Buffer, 0, ToDecrypt, 0, BlockSize);

                Byte[] Plaintext = RSADecrypt(ToDecrypt, RSA.ExportParameters(true), false);
                PlaiStream.Write(Plaintext, 0, Plaintext.Length);

                BlockSize = CrypStream.Read(Buffer, 0, MaxBlockSize);
            }
            return PlaiStream.ToArray();
        }


        private static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            RSA.ImportParameters(RSAKeyInfo);

            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }

        /// <summary>
        /// generate private key and public key arr[0] for private key arr[1] for public key
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateKeys()
        {
            string[] sKeys = new String[2];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            sKeys[0] = rsa.ToXmlString(true);
            sKeys[1] = rsa.ToXmlString(false);
            return sKeys;
        }


        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 16进制转byte[]
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] HexStrTobyte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }



    }
}
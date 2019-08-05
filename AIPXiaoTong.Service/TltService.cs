﻿using Microsoft.Practices.Unity;
using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Common;
using Framework.Web.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TltApi;
using TltApi.Model;
using Framework.Models;

namespace AIPXiaoTong.Service
{
    public class TltService : ITltService
    {
        TltExec tltExec;



        public TltService()
        {
            //string url = System.Configuration.ConfigurationManager.AppSettings["TltUrl"].ToString();
            //string merchantId = System.Configuration.ConfigurationManager.AppSettings["TltMerchantId"].ToString();
            //string userName = System.Configuration.ConfigurationManager.AppSettings["TltUserName"].ToString();
            //string userPassword = System.Configuration.ConfigurationManager.AppSettings["TltUserPassword"].ToString();
            //string privateKeyPassword = System.Configuration.ConfigurationManager.AppSettings["TltPrivateKeyPassword"].ToString();

            //tltExec = new TltExec(url, merchantId, userName, userPassword, privateKeyPassword);
        }

        public void Init(string url, string TltMerchantId, string userName, string userPassword, string privateKeyPassword)
        {
            var iTLTPreferencesService = DIFactory.GetContainer().Resolve<ITLTPreferencesService>();

            var TLTPreferences = iTLTPreferencesService.Get(t => t.TltMerchantId == TltMerchantId);

            if (TLTPreferences == null)
                throw new APIException(PingAnExceptionOption.NotSetTLTParam);

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("\\"), 1);

            tltExec = new TltExec(url, TltMerchantId, userName, userPassword, privateKeyPassword, baseDirectory + TLTPreferences.TLTPrivateKeyCer, baseDirectory + TLTPreferences.TLTSecurityCer);
        }
        public bool isReady()
        {
            if (tltExec == null)
            {
                return false;
            }
            return true;
        }
        public AccountVerifyResponse AccountVerify4(string Name, string IDNumber, string BarkNumber, string Mobile)
        {

            AccountVerifyRequest request = new AccountVerifyRequest(this.tltExec);

            request.INFO.REQ_SN = GuidHelper.GenUniqueId();

            request.VALIDR.SUBMIT_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");
            request.VALIDR.ACCOUNT_NO = BarkNumber;
            request.VALIDR.ACCOUNT_NAME = Name;
            request.VALIDR.ACCOUNT_PROP = "0";
            request.VALIDR.ID_TYPE = "0";
            request.VALIDR.ID = IDNumber;
            request.VALIDR.TEL = Mobile;

            var response = tltExec.Exec(request);

            return response as AccountVerifyResponse;
        }


        //public SingleOntimePayResponse SingleOntimePay(string Name, string BarkNumber, int Amount, string REQ_SN)
        //{
        //    SingleOntimePayRquest request = new SingleOntimePayRquest();

        //    request.INFO.REQ_SN = REQ_SN;

        //    request.TRANS.BUSINESS_CODE = "09900";
        //    request.TRANS.SUBMIT_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");
        //    request.TRANS.ACCOUNT_NO = BarkNumber;
        //    request.TRANS.ACCOUNT_NAME = Name;
        //    request.TRANS.ACCOUNT_PROP = "0";
        //    request.TRANS.AMOUNT = Amount;
        //    request.TRANS.ACCOUNT_KIND = "01";


        //    var response = tltExec.Exec(request);

        //    return response as SingleOntimePayResponse;
        //}

        public SingleOntimePayResponse SingleOntimePay(OrderPaid orderPaid, PingAnOrderPaidRecharge pingAnOrderPaidRecharge)
        {
            SingleOntimePayRquest request = new SingleOntimePayRquest(this.tltExec);

            request.INFO.REQ_SN = pingAnOrderPaidRecharge.SerialNumber;

            request.TRANS.BUSINESS_CODE = "09900";
            request.TRANS.SUBMIT_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");
            request.TRANS.ACCOUNT_NO = orderPaid.Member.AccountPingAn.BankCardNumber; //银行卡号（平安二类户卡号）
            request.TRANS.ACCOUNT_NAME = orderPaid.MemberName;
            request.TRANS.ACCOUNT_PROP = "0";
            request.TRANS.AMOUNT = decimal.ToInt32(orderPaid.TransactionAmount * 100);
            request.TRANS.FIRST_ACCTNO = orderPaid.Member?.AccountPingAn.OutCardNo;   //转入银行卡号(代付出金卡)
            request.TRANS.FIRST_ACCTNAME = orderPaid.Member?.AccountPingAn.CnName;
            request.TRANS.ACCOUNT_ATTRB = "2";
            //--------------------------------------------------------------------
            request.TRANS.BANK_CODE = pingAnOrderPaidRecharge?.BankCode;
            request.TRANS.BANK_NAME = pingAnOrderPaidRecharge?.BankName;
            request.TRANS.ACCOUNT_TYPE = pingAnOrderPaidRecharge?.AccountType;
            request.TRANS.PROVINCE = pingAnOrderPaidRecharge?.Province;
            request.TRANS.CITY = pingAnOrderPaidRecharge?.City;
            request.TRANS.ACCOUNT_PROP = pingAnOrderPaidRecharge?.AccountProp ?? "0";
            request.TRANS.UNION_BANK = pingAnOrderPaidRecharge?.UnionBank;

            var response = tltExec.Exec(request);

            return response as SingleOntimePayResponse;
        }

        public QueryTltTradingResultResponse QueryTltTradingResult(string REQ_SN, string QUERY_SN, string TRX_CODE)
        {
            QueryTltTradingResultRequest request = new QueryTltTradingResultRequest(this.tltExec);
            request.INFO.TRX_CODE = TRX_CODE;
            request.INFO.REQ_SN = REQ_SN;

            request.QTRANSREQ.QUERY_SN = QUERY_SN;

            var response = tltExec.Exec(request);

            return response as QueryTltTradingResultResponse;
        }

        //public void test()
        //{
        //    //单笔实时 
        //    SingleOntimePayResponse r = new SingleOntimePayResponse();

        //    if (r.Status == StatusOption.Success)
        //    { }


        //    //--------------------------------------
        //    //查询
        //    var msg = "<?xml version=\"1.0\" encoding=\"GBK\"?><AIPG><INFO><TRX_CODE>200004</TRX_CODE><VERSION>03</VERSION><DATA_TYPE>2</DATA_TYPE><REQ_SN>LYZ_20190307_142135_335</REQ_SN><RET_CODE>0000</RET_CODE><ERR_MSG>处理完成</ERR_MSG><SIGNED_MSG>640ebbb3cf208eb8f496c5c6887b7219279d4c0c8da8d52d1847065cfa3214a715231138b48b8f93fffac7aad0e8020394e2d08c4c385bc05bd6806d60f321a213aaca9ef6108a49b9c083781a53194f665ae55c734601b2c5bce6989fa871f20395e31ab9e42fa1c01ff25350bd25a41011392ad4820e26e65429df4f38dddd3aadbb52b8711c417acd0892aa6fe857ab7dcc2b7f35fb773fe0ddcb854f388c652b34b3e1f92b6abae6cfdf1c68d68dda7f04de45beddb02f7b4f231a3378f6a99904bbc12b02a07d5a5bb3a87bcedb0afef9d6c8ea65f147f2846600a926c30e171e60f7d006cdfd98a91c97443ec48a74baa9886494dee5fc0e4704794b93</SIGNED_MSG></INFO><QTRANSRSP><QTDETAIL><BATCHID>LYZ_20190307_141732_662</BATCHID><SN>0</SN><TRXDIR>0</TRXDIR><SETTDAY>20190307</SETTDAY><FINTIME>20190307141908</FINTIME><SUBMITTIME>20190307141908</SUBMITTIME><ACCOUNT_NO>6</ACCOUNT_NO><ACCOUNT_NAME>中行1</ACCOUNT_NAME><AMOUNT>1000</AMOUNT><RET_CODE>3004</RET_CODE><ERR_MSG>无效卡号</ERR_MSG></QTDETAIL></QTRANSRSP></AIPG>";

        //    var response = XmlHelper.XmlDeserialize<QueryTltTradingResultResponse>(msg, Encoding.GetEncoding("GBK"));

        //    foreach (var q in response.QTRANSRSP.QTDETAIL)
        //    {
        //        if (q.GetStatus(response.INFO.RET_CODE) == StatusOption.Success)
        //        {

        //        }
        //    }

        //}
    }
}

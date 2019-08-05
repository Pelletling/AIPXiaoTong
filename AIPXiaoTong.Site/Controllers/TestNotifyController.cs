﻿using AIPXiaoTong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Common;
using Framework.Security;
using AIPXiaoTong.Model.Site;
using NLog;
using AIPXiaoTong.IService;
using PingAnAPI;
using AIPXiaoTong.Model.PingAnAPI;
using VSP.Pay;
using VSP.Pay.ResponseModel;
using System.Text;
using System.IO;
using System.Globalization;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class TestNotifyController : Controller
    {
        private string content = "";

        private IAccountPingAnService iAccountPingAnService;
        private IOrderPaidService iOrderPaidService;
        private IMemberService iMemberService;
        private IPingAnOrderPaidService iPingAnOrderPaidService;
        private IPreferencesService iPreferencesService;
        private IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService;

        VSPExec vspExec = null;

        public TestNotifyController(IAccountPingAnService iAccountPingAnService,
                                     IOrderPaidService iOrderPaidService,
                                     IMemberService iMemberService,
                                     IPingAnOrderPaidService iPingAnOrderPaidService,
                                     IPreferencesService iPreferencesService,
                                     IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService)
        {
            this.iAccountPingAnService = iAccountPingAnService;
            this.iOrderPaidService = iOrderPaidService;
            this.iMemberService = iMemberService;
            this.iPingAnOrderPaidService = iPingAnOrderPaidService;
            this.iPreferencesService = iPreferencesService;
            this.iPingAnOrderPaidRechargeService = iPingAnOrderPaidRechargeService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            content = Request.Form.ToString();

            if (string.IsNullOrWhiteSpace(content))
                content = Request.QueryString.ToString();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }


        /// <summary>
        /// 百富POS调订单支付通知
        /// </summary>
        public void POSOrderPaidNotify()
        {
            Dictionary<string, string> param = HttpUtility.UrlDecode(content).ToDictionary(true);

            if (!param.ContainsKey("bizseq"))
            {
                Response.Write("error");
            }

            string bizseq = param["bizseq"];

            var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == bizseq);

            if (orderPaid == null)
            {
                Response.Write("error");
                return;
            }

            //测试使用： 平安的订单，订单支付后通知转发到平安的通知方法
            if (orderPaid.Merchant.AccountBank == AccountBankOption.PingAn.ToInt())
            {
                string url = "http://112.95.232.217:8023/PingAnNotify/POSOrderPaidNotify";
                Framework.Requests.Request.Post(url, content, System.Net.SecurityProtocolType.Tls12);
                //RedirectToAction("POSOrderPaidNotify", "PingAnNotify", content);
                return;
            }

            //测试使用： 光大的订单，订单支付后通知转发到光大的通知方法
            if (orderPaid.Merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
            {
                string url = "http://112.95.232.217:8023/Notify/POSOrderPaidNotify";
                Framework.Requests.Request.Post(url, content, System.Net.SecurityProtocolType.Tls12);
                return;
            }

        }

        public void GetOrderMsg()
        {
            string bizseq = "";
            string cusid = "";
            RspObj rsp = new RspObj();

            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.Keys[i] == "bizseq")
                {
                    bizseq = Request.Form[i].ToString();
                }
                if (Request.Form.Keys[i] == "cusid")
                {
                    cusid = Request.Form[i].ToString();
                }
            }

            var orderpaid = iOrderPaidService.Get(t => t.OrderNumber == bizseq);

            Preferences preferences = iPreferencesService.Get(t => t.POSBaoMerchant == cusid);

            if (orderpaid == null)
            {
                rsp.init("9999", "订单不存在", preferences.APPID, preferences.POSBaoMerchant);
                rsp.amount = "";
                rsp.trxreserve = "";
                rsp.bizseq = "";
                rsp = BuildSignRspObj(rsp, preferences.POSBaoKey);//签名 
                Response.Write(JsonHelper.Serialize(rsp));
                return;
            }

            //Preferences preferences = iPreferencesService.Get(t => t.MerchantID == orderpaid.MerchantID);
            this.vspExec = new VSPExec(preferences.POSBaoMerchant, preferences.POSBaoKey, preferences.APPID);

            //获取支付参数
            string formString = HttpUtility.UrlDecode(Request.Form.ToString());
            Dictionary<String, String> dicReqeust = formString.ToDictionary(true);

            if (vspExec.IsVerify(dicReqeust))//验签成功
            {
                if (DateTime.Now > orderpaid.Project.Deadline)
                {
                    rsp.init("9999", "订单已过期", preferences.APPID, preferences.POSBaoMerchant);
                    rsp.amount = "";//由于nettonsoft.json会自动将空字段转化为null,因此手动赋值空字符串
                    rsp.trxreserve = "";
                    rsp.bizseq = "";
                }
                else
                {
                    rsp.init("0000", "查询成功", preferences.APPID, preferences.POSBaoMerchant);
                    rsp.amount = ((int)(orderpaid.TransactionAmount * 100)).ToString();
                    // rsp.trxreserve = "05（业务类型）##订购人姓名#广州体育西（订购人地址）#15820335584（联系电话）#TN000001#01#440992198709257433（跟踪订单号）####";
                    rsp.trxreserve = "05##" + orderpaid.Member.Name + "#" + orderpaid.MemberMobile + "#" + orderpaid.OrderNumber + "#######";
                    //rsp.trxreserve = "05##" + "AAA" + "#" + orderpaid.MemberMobile + "#" + orderpaid.OrderNumber + "#######";
                    rsp.bizseq = orderpaid.OrderNumber;//业务流水号
                }
            }
            else //验签失败
            {
                rsp.init("9999", "验签失败", preferences.APPID, preferences.POSBaoMerchant);
                rsp.amount = "";//由于nettonsoft.json会自动将空字段转化为null,因此手动赋值空字符串
                rsp.trxreserve = "";
                rsp.bizseq = "";
            }

            rsp = BuildSignRspObj(rsp, preferences.POSBaoKey);//签名 

            Response.Write(JsonHelper.Serialize(rsp));
        }

        public class RspObj
        {
            public String appid;
            public String cusid;
            public String trxcode;
            public String timestamp;
            public String randomstr;
            public String sign;
            public String bizseq;
            public String retcode;
            public String retmsg;
            public String amount;
            public String trxreserve;

            public void init(String retCode, String retMsg, String APPID, String CUSID)
            {
                retcode = retCode;
                retmsg = retMsg;
                appid = APPID;
                cusid = CUSID;
                trxcode = "T001";
                timestamp = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                randomstr = (new Random().Next(8999) + 1000).ToString();
            }

        }

        /// <summary>
        /// 将查询结果实体加签
        /// </summary>
        /// <param name="rsp"></param>
        public static RspObj BuildSignRspObj(RspObj rsp, string APPKEY)
        {
            Dictionary<String, String> param = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(rsp.appid))
            {
                param.Add("appid", rsp.appid);
            }
            if (!String.IsNullOrEmpty(rsp.cusid))
            {
                param.Add("cusid", rsp.cusid);
            }
            if (!String.IsNullOrEmpty(rsp.trxcode))
            {
                param.Add("trxcode", rsp.trxcode);
            }
            if (!String.IsNullOrEmpty(rsp.timestamp))
            {
                param.Add("timestamp", rsp.timestamp);
            }
            if (!String.IsNullOrEmpty(rsp.randomstr))
            {
                param.Add("randomstr", rsp.randomstr);
            }
            if (!String.IsNullOrEmpty(rsp.bizseq))
            {
                param.Add("bizseq", rsp.bizseq);
            }
            if (!String.IsNullOrEmpty(rsp.retcode))
            {
                param.Add("retcode", rsp.retcode);
            }
            if (!String.IsNullOrEmpty(rsp.retmsg))
            {
                param.Add("retmsg", rsp.retmsg);
            }
            if (!String.IsNullOrEmpty(rsp.amount))
            {
                param.Add("amount", rsp.amount);
            }
            if (!String.IsNullOrEmpty(rsp.trxreserve))
            {
                param.Add("trxreserve", rsp.trxreserve);
            }
            param.Add("key", APPKEY);
            string blankStr = BuildParamStr(param);
            string sign = Framework.Security.Crypt.MD5(blankStr);
            rsp.sign = sign;
            return rsp;
        }

        /// <summary>
        /// 将参数排序组装
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static String BuildParamStr(Dictionary<String, String> param)
        {
            if (param == null || param.Count == 0)
            {
                return "";
            }
            Dictionary<String, String> ascDic = param.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var item in ascDic)
            {
                sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
            }

            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}
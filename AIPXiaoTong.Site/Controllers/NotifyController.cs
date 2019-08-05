﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.API;
using Framework.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VSP.Pay;
using VSP.Pay.ResponseModel;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class NotifyController : Controller
    {
        public ILogger logger;
        private IOrderHousePaymentService iOrderHousePaymentService;
        private IPreferencesService iPreferencesService;
        private IOrderPaidService iOrderPaidService;

        VSPExec vspExec = null;
        private string content = "";

        public NotifyController(IOrderHousePaymentService iOrderHousePaymentService,
                                                 IPreferencesService iPreferencesService,
                                                 IOrderPaidService iOrderPaidService)
        {
            this.iOrderHousePaymentService = iOrderHousePaymentService;
            this.iPreferencesService = iPreferencesService;
            this.iOrderPaidService = iOrderPaidService;
            logger = LogManager.GetCurrentClassLogger();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            content = Request.Form.ToString();

            if (string.IsNullOrWhiteSpace(content))
                content = Request.QueryString.ToString();

            logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + content);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + (filterContext.Result as ContentResult)?.Content);

            base.OnActionExecuted(filterContext);
        }



        //public void POSOrderPaidNotify()
        //{
        //    Dictionary<string, string> param = HttpUtility.UrlDecode(content).ToDictionary(true);

        //    //for (int i = 0; i < Request.Form.Count; i++)
        //    //{
        //    //    if (Request.Form.Keys[i] == "bizseq")
        //    //    {
        //    //        bizseq = Request.Form[i].ToString();
        //    //        break;
        //    //    }
        //    //}

        //    if (!param.ContainsKey("bizseq"))
        //    {
        //        logger.Error("bizseq不能为空");
        //        Response.Write("error");
        //    }

        //    string bizseq = param["bizseq"];

        //    var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == bizseq);

        //    if (orderPaid == null)
        //    {
        //        logger.Error("订单支付回调没有找到订单:" + Request.Form.ToString());
        //        Response.Write("error");
        //        return;
        //    }
        //    //获取支付参数
        //    var preferences = iPreferencesService.Get(t => t.MerchantID == orderPaid.MerchantID);
        //    this.vspExec = new VSPExec(preferences.POSBaoMerchant, preferences.POSBaoKey, preferences.APPID);

        //    //string formString = HttpUtility.UrlDecode(Request.Form.ToString());
        //    //Dictionary<String, String> dicReqeust = formString.ToDictionary(true);
        //    if (vspExec.IsVerify(param))//验签成功
        //    {
        //        POSOrderQueryResponse posOrderQueryResponse = JsonHelper.Deserialize<POSOrderQueryResponse>(JsonHelper.Serialize(param));
        //        byte[] bytes = Encoding.GetEncoding("gbk").GetBytes(posOrderQueryResponse.trxreserve ?? "");//将字符串转成gbk编码的字节数组 
        //        posOrderQueryResponse.trxreserve = Encoding.GetEncoding("utf-8").GetString(bytes);//将字节数组转回为字符串

        //        //posOrderQueryResponse.trxcode = "";
        //        //VSP001 = 消费
        //        //VSP002 = 消费撤销
        //        //VSP003 = 退货
        //        //VSP004 = 预授权
        //        //VSP005 = 预授权撤销
        //        //VSP006 = 预授权完成
        //        //VSP007 = 预授权完成撤销
        //        //CMN001 = 消费冲正
        //        //CMN002 = 预授权冲正
        //        //CMN003 = 预授权完成冲正
        //        //VSP501 = 微信支付
        //        //VSP502 = 微信支付撤销
        //        //VSP503 = 微信支付退款
        //        //VSP511 = 支付宝支付
        //        //VSP512 = 支付宝支付撤销
        //        //VSP513 = 支付宝支付退货
        //        //VSP521 = 通联钱包消费
        //        //VSP522 = 通联钱包消费撤销
        //        //VSP523 = 通联钱包消费退货
        //        //VSP505 = 手机QQ 支付
        //        //VSP506 = 手机QQ支付撤销
        //        //VSP507 = 手机QQ支付退款
        //        //VSP551 = 银联扫码支付
        //        //VSP552 = 银联扫码撤销
        //        //VSP553 = 银联扫码退货
        //        if (posOrderQueryResponse.trxcode == "VSP002" || posOrderQueryResponse.trxcode == "VSP003" || posOrderQueryResponse.trxcode == "VSP003"
        //            || posOrderQueryResponse.trxcode == "VSP502" || posOrderQueryResponse.trxcode == "VSP503"
        //            || posOrderQueryResponse.trxcode == "VSP512" || posOrderQueryResponse.trxcode == "VSP513"
        //            || posOrderQueryResponse.trxcode == "VSP522" || posOrderQueryResponse.trxcode == "VSP523"
        //            || posOrderQueryResponse.trxcode == "VSP506" || posOrderQueryResponse.trxcode == "VSP507"
        //            || posOrderQueryResponse.trxcode == "VSP552" || posOrderQueryResponse.trxcode == "VSP553")
        //        {
        //            if (posOrderQueryResponse.trxstatus == "0000")
        //            {
        //                try
        //                {
        //                    orderPaid.PayAction = OrderPaidPayActionOption.Repeal.ToInt();

        //                    iOrderPaidService.Save(orderPaid);

        //                    iOrderPaidService.Commit();

        //                    iOrderPaidService.UnFreezeAndWithdraw(orderPaid);  //用户撤销或退款，成功则调用银行接口实现用户提现                            

        //                }
        //                catch (Exception ex)
        //                {
        //                    logger.Error("订单撤销失败:" + ex);
        //                    Response.Write("error");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (posOrderQueryResponse.trxstatus == "0000")
        //            {
        //                try
        //                {
        //                    orderPaid.Status = OrderPaidStatusOption.PaySuccess.ToInt();

        //                    iOrderPaidService.Save(orderPaid);

        //                    iOrderPaidService.Commit();

        //                    iOrderPaidService.RechargeAndFreeze(orderPaid);
        //                }
        //                catch (Exception ex)
        //                {
        //                    logger.Error("订单充值失败:" + ex);
        //                    Response.Write("error");
        //                }
        //            }
        //            else
        //            {
        //                logger.Error("订单支付失败:" + Request.Form.ToString());
        //                Response.Write("error");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        logger.Error("订单支付验签失败:" + Request.Form.ToString());
        //        Response.Write("error");
        //    }
        //}


        //public class RspObj
        //{
        //    public String appid;
        //    public String cusid;
        //    public String trxcode;
        //    public String timestamp;
        //    public String randomstr;
        //    public String sign;
        //    public String bizseq;
        //    public String retcode;
        //    public String retmsg;
        //    public String amount;
        //    public String trxreserve;

        //    public void init(String retCode, String retMsg, String APPID, String CUSID)
        //    {
        //        retcode = retCode;
        //        retmsg = retMsg;
        //        appid = APPID;
        //        cusid = CUSID;
        //        trxcode = "T001";
        //        timestamp = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
        //        randomstr = (new Random().Next(8999) + 1000).ToString();
        //    }

        //}

        /// <summary>
        /// 将参数排序组装
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        //public static String BuildParamStr(Dictionary<String, String> param)
        //{
        //    if (param == null || param.Count == 0)
        //    {
        //        return "";
        //    }
        //    Dictionary<String, String> ascDic = param.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in ascDic)
        //    {
        //        sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
        //    }

        //    return sb.ToString().Substring(0, sb.ToString().Length - 1);
        //}

        /// <summary>
        /// 将查询结果实体加签
        /// </summary>
        /// <param name="rsp"></param>
        //public static RspObj BuildSignRspObj(RspObj rsp, string APPKEY)
        //{
        //    Dictionary<String, String> param = new Dictionary<string, string>();
        //    if (!String.IsNullOrEmpty(rsp.appid))
        //    {
        //        param.Add("appid", rsp.appid);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.cusid))
        //    {
        //        param.Add("cusid", rsp.cusid);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.trxcode))
        //    {
        //        param.Add("trxcode", rsp.trxcode);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.timestamp))
        //    {
        //        param.Add("timestamp", rsp.timestamp);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.randomstr))
        //    {
        //        param.Add("randomstr", rsp.randomstr);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.bizseq))
        //    {
        //        param.Add("bizseq", rsp.bizseq);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.retcode))
        //    {
        //        param.Add("retcode", rsp.retcode);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.retmsg))
        //    {
        //        param.Add("retmsg", rsp.retmsg);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.amount))
        //    {
        //        param.Add("amount", rsp.amount);
        //    }
        //    if (!String.IsNullOrEmpty(rsp.trxreserve))
        //    {
        //        param.Add("trxreserve", rsp.trxreserve);
        //    }
        //    param.Add("key", APPKEY);
        //    String blankStr = BuildParamStr(param);
        //    String sign = Framework.Security.Crypt.MD5(blankStr);
        //    rsp.sign = sign;
        //    return rsp;
        //}

        //public void GetOrderMsg()
        //{
        //    string bizseq = "";
        //    string cusid = "";
        //    RspObj rsp = new RspObj();

        //    for (int i = 0; i < Request.Form.Count; i++)
        //    {
        //        if (Request.Form.Keys[i] == "bizseq")
        //        {
        //            bizseq = Request.Form[i].ToString();
        //        }
        //        if (Request.Form.Keys[i] == "cusid")
        //        {
        //            cusid = Request.Form[i].ToString();
        //        }
        //    }

        //    var orderpaid = iOrderPaidService.Get(t => t.OrderNumber == bizseq);

        //    Preferences preferences = iPreferencesService.Get(t => t.POSBaoMerchant == cusid);

        //    if (orderpaid == null)
        //    {
        //        rsp.init("9999", "订单不存在", preferences.APPID, preferences.POSBaoMerchant);
        //        rsp.amount = "";
        //        rsp.trxreserve = "";
        //        rsp.bizseq = "";
        //        rsp = BuildSignRspObj(rsp, preferences.POSBaoKey);//签名 
        //        Response.Write(JsonHelper.Serialize(rsp));
        //        return;
        //    }

        //    //Preferences preferences = iPreferencesService.Get(t => t.MerchantID == orderpaid.MerchantID);
        //    this.vspExec = new VSPExec(preferences.POSBaoMerchant, preferences.POSBaoKey, preferences.APPID);

        //    //获取支付参数
        //    string formString = HttpUtility.UrlDecode(Request.Form.ToString());
        //    Dictionary<String, String> dicReqeust = formString.ToDictionary(true);

        //    if (vspExec.IsVerify(dicReqeust))//验签成功
        //    {
        //        if (DateTime.Now > orderpaid.Project.Deadline)
        //        {
        //            rsp.init("9999", "订单已过期", preferences.APPID, preferences.POSBaoMerchant);
        //            rsp.amount = "";//由于nettonsoft.json会自动将空字段转化为null,因此手动赋值空字符串
        //            rsp.trxreserve = "";
        //            rsp.bizseq = "";
        //        }
        //        else
        //        {
        //            rsp.init("0000", "查询成功", preferences.APPID, preferences.POSBaoMerchant);
        //            rsp.amount = ((int)(orderpaid.TransactionAmount * 100)).ToString();
        //            // rsp.trxreserve = "05（业务类型）##订购人姓名#广州体育西（订购人地址）#15820335584（联系电话）#TN000001#01#440992198709257433（跟踪订单号）####";
        //            rsp.trxreserve = "05##" + orderpaid.Member.Name + "#" + orderpaid.Member.AccountGuangDa.Address + "#" + orderpaid.MemberMobile + "#" + orderpaid.OrderNumber + "#######";
        //            rsp.bizseq = orderpaid.OrderNumber;//业务流水号
        //        }
        //    }
        //    else //验签失败
        //    {
        //        rsp.init("9999", "验签失败", preferences.APPID, preferences.POSBaoMerchant);
        //        rsp.amount = "";//由于nettonsoft.json会自动将空字段转化为null,因此手动赋值空字符串
        //        rsp.trxreserve = "";
        //        rsp.bizseq = "";
        //    }

        //    rsp = BuildSignRspObj(rsp, preferences.POSBaoKey);//签名 

        //    Response.Write(JsonHelper.Serialize(rsp));

        //}
    }
}
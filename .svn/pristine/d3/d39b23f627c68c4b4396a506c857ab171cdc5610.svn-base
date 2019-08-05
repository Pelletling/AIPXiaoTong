using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSP.Pay.ResponseModel;

namespace VSP.Pay.RequestModel
{
    public class PayRequest : IBaseRequest<PayResponse>
    {
        public string GetUrl()
        {
            return "https://vsp.allinpay.com/apiweb/unitorder/pay";
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("version", version);
            dic.Add("trxamt", trxamt.ToString());
            dic.Add("reqsn", reqsn);
            dic.Add("paytype", paytype.ToString());
            dic.Add("randomstr", randomstr);
            dic.Add("body", body);
            dic.Add("remark", remark);
            dic.Add("validtime", validtime.ToString());
            dic.Add("authcode", authcode);
            dic.Add("acct", acct);
            dic.Add("notify_url", notify_url);
            dic.Add("limit_pay", limit_pay);
            dic.Add("sub_appid", sub_appid);
            dic.Add("idno", idno);
            dic.Add("truename", truename);
            dic.Add("asinfo", asinfo);

            return dic;
        }

        /// <summary>
        /// 接口版本号
        /// </summary>
        public string version { get { return "11"; } }

        /// <summary>
        /// 交易金额，单位为分
        /// </summary>
        public int trxamt { get; set; }

        /// <summary>
        /// 商户订单号(保证商户平台唯一)
        /// </summary>
        public string reqsn { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary>
        public PayTypeOption paytype { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string randomstr { get; set; }

        /// <summary>
        /// 订单标题(最大100个字节(50个中文字符))
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 备注(最大160个字节(80个中文字符))
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 订单有效时间，以分为单位，不填默认为5分钟
        /// </summary>
        public int? validtime { get; set; }

        /// <summary>
        /// 支付授权码,微信或者支付宝的被扫刷卡支付时,用户的付款二维码
        /// </summary>
        public string authcode { get; set; }

        /// <summary>
        /// 支付平台用户标识,JS支付时使用：微信支付-用户的微信openid；支付宝支付-用户user_id；微信小程序-用户小程序的openid
        /// </summary>
        public string acct { get; set; }

        /// <summary>
        /// 交易结果通知地址
        /// </summary>
        public string notify_url { get; set; }

        /// <summary>
        /// 支付限制,no_credit--指定不能使用信用卡支付,暂时只对微信支付和支付宝有效,仅支持no_credit
        /// </summary>
        public string limit_pay { get; set; }

        /// <summary>
        /// 微信子appid(只对微信支付有效)
        /// </summary>
        public string sub_appid { get; set; }

        /// <summary>
        /// 证件号,实名交易必填.填了此字段就会验证证件号和姓名
        /// </summary>
        public string idno { get; set; }

        /// <summary>
        /// 付款人真实姓名
        /// </summary>
        public string truename { get; set; }

        /// <summary>
        /// 分账信息.格式:cusid:type:amount;cusid:type:amount…其中cusid:接收分账的通联商户号type分账类型（01：按金额  02：按比率）如果分账类型为02，则分账比率为0.5表示50%。如果分账类型为01，则分账金额以元为单位表示
        /// </summary>
        public string asinfo { get; set; }
    }
}

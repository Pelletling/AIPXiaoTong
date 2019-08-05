using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay.ResponseModel
{
   public class NotifyResponse : BaseResponse
    {
        /// <summary>
        /// 第三方appid
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 第三方app交易号
        /// </summary>
        public string outtrxid { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string trxcode { get; set; }

        /// <summary>
        /// 收银宝平台流水号(通联系统内唯一)
        /// </summary>
        public string trxid { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public int trxamt { get; set; }

        /// <summary>
        /// 交易请求日期
        /// </summary>
        public string trxdate { get; set; }

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string paytime { get; set; }

        /// <summary>
        /// 渠道交易单号(如支付宝,微信平台订单号)
        /// </summary>
        public string chnltrxid { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string trxstatus { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string cusid { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string termno { get; set; }

        /// <summary>
        /// 终端批次号
        /// </summary>
        public string termbatchid { get; set; }

        /// <summary>
        /// 终端流水号
        /// </summary>
        public string termtraceno { get; set; }

        /// <summary>
        /// 终端授权码
        /// </summary>
        public string termauthno { get; set; }

        /// <summary>
        /// 终端参考号
        /// </summary>
        public string termrefnum { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        public string trxreserved { get; set; }

        /// <summary>
        /// 原交易ID(对于冲正、撤销、退货等交易时填写)
        /// </summary>
        public string srctrxid { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string cusorderid { get; set; }

        /// <summary>
        /// 支付人帐号(如:微信支付的openid,支付宝平台的user_id,如果信息为空, 则默认填写000000)
        /// </summary>
        public string acct { get; set; }

        /// <summary>
        /// 签名信息
        /// </summary>
        public string sign { get; set; }

    }
}

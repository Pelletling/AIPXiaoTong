using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay
{
    public enum PayTypeOption
    {
        /// <summary>
        /// 微信扫码支付
        /// </summary>
        W01,

        /// <summary>
        /// 微信JS支付
        /// </summary>
        W02,

        /// <summary>
        /// 微信APP支付
        /// </summary>
        W03,

        /// <summary>
        /// 微信刷卡支付
        /// </summary>
        W04,
        
        /// <summary>
        /// 微信小程序支付
        /// </summary>
        W06,

        /// <summary>
        /// 支付宝扫码支付
        /// </summary>
        A01,

        /// <summary>
        /// 支付宝JS支付
        /// </summary>
        A02,

        /// <summary>
        /// 支付宝刷卡支付
        /// </summary>
        A04,

        /// <summary>
        /// 手机QQ扫码支付
        /// </summary>
        Q01,

        /// <summary>
        /// 手机QQ JS支付
        /// </summary>
        Q02,

        /// <summary>
        /// 手机QQ刷卡支付
        /// </summary>
        Q04,

        /// <summary>
        /// 银联扫码支付(CSB)
        /// </summary>
        U01,

        /// <summary>
        /// 银联刷卡支付(BSC)
        /// </summary>
        U04
    }
}

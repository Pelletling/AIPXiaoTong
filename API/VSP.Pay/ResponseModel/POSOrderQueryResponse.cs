﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay.ResponseModel
{
    public class POSOrderQueryResponse : BaseResponse
    {
        /// <summary>
        /// 交易类型
        /// </summary>
        public string trxcode { get; set; }
        /// <summary>
        /// 第三方appid
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string cusid { get; set; }

        /// <summary>
        /// 调用时间戳
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string randomstr { get; set; }
        /// <summary>
        /// sign校验码
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string bizseq { get; set; }
        /// <summary>
        /// 交易结果状态码
        /// </summary>
        public string trxstatus { get; set; }
        /// <summary>
        /// 交易金额 单位分
        /// </summary>
        public long amount { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string trxid { get; set; }
        /// <summary>
        /// 原交易流水,冲正撤销交易本字段不为空
        /// </summary>
        public string srctrxid { get; set; }
        /// <summary>
        /// 交易请求日期
        /// </summary>
        public string trxday { get; set; }
        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string paytime { get; set; }
        /// <summary>
        /// 终端编码
        /// </summary>
        public string termid { get; set; }
        /// <summary>
        /// 终端批次号
        /// </summary>
        public string termbatchid { get; set; }
        /// <summary>
        /// 终端流水
        /// </summary>
        public string traceno { get; set; }
        /// <summary>
        /// 业务关联内容 订单查询时商户订单系统返回的自定义内容
        /// </summary>
        public string trxreserve { get; set; }
        /// <summary>
        /// 借贷标志
        /// </summary>
        public string accttype { get; set; }
        /// <summary>
        /// 交易帐号 如果是刷卡交易,则是隐藏的卡号  微信则是Openid，支付宝则是userid
        /// </summary>
        public string acct { get; set; }
        /// <summary>
        /// 终端授权码
        /// </summary>
        public string termauthno { get; set; }
        /// <summary>
        /// 终端参考号
        /// </summary>
        public string termrefnum { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public string fee { get; set; }
        /// <summary>
        /// 签名类型
        /// </summary>
        public string signtype { get; set; }
    }
}

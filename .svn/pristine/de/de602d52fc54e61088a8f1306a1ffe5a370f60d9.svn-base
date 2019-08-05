using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay.ResponseModel
{
    public class PayResponse : BaseResponse
    {
       

        //以下信息只有当retcode为SUCCESS时有返回

        /// <summary>
        /// 商户号
        /// </summary>
        public string cusid { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 收银宝平台的交易流水号
        /// </summary>
        public string trxid { get; set; }

        /// <summary>
        /// 渠道平台交易单号,例如微信,支付宝平台的交易单号
        /// </summary>
        public string chnltrxid { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string reqsn { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string randomstr { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string trxstatus { get; set; }

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string fintime { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        public string errmsg { get; set; }

        /// <summary>
        /// 支付串,扫码支付则返回二维码串，js支付则返回json字符串,App支付返回json串,手Q的JS支付返回支付的链接, 商户只需跳转到此链接即可完成支付
        /// </summary>
        public string payinfo { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }


        //-------------------
        /// <summary>
        /// 推荐使用
        /// </summary>
        public string CustomError {
            get {
                if (!string.IsNullOrWhiteSpace(retmsg))
                    return retmsg;
                else if (!string.IsNullOrWhiteSpace(errmsg))
                    return errmsg;
                else 
                    return "";
            }
        }
    }
}

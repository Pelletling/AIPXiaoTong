using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay.ResponseModel
{
    /// <summary>
    /// 退款
    /// </summary>
    public class RefundResponse : BaseResponse
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
        /// 商户订单号
        /// </summary>
        public string reqsn { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string trxstatus { get; set; }
        

        /// <summary>
        /// 交易完成时间
        /// </summary>
        public string fintime { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string randomstr { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        public string errmsg { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        //-------------------
        /// <summary>
        /// 推荐使用
        /// </summary>
        public string CustomError
        {
            get
            {
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

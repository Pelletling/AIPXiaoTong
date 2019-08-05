using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSP.Pay.ResponseModel;

namespace VSP.Pay.RequestModel
{
    public class RefundRequest : IBaseRequest<RefundResponse>
    {
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("version", version);
            dic.Add("trxamt", trxamt.ToString());
            dic.Add("reqsn", reqsn);
            dic.Add("oldreqsn", oldreqsn);
            dic.Add("oldtrxid", oldtrxid);
            dic.Add("remark", remark);
            dic.Add("randomstr", randomstr);

            return dic;
        }

        public string GetUrl()
        {
            return "https://vsp.allinpay.com/apiweb/unitorder/refund";                
        }

        /// <summary>
        /// 接口版本号,默认填11
        /// </summary>
        public string version { get { return "11"; } }

        /// <summary>
        /// 退款金额,单位为分,可部分退款
        /// </summary>
        public int trxamt { get; set; }

        /// <summary>
        /// 商户的交易订单号
        /// </summary>
        public string reqsn { get; set; }


        /// <summary>
        ///原交易订单号（oldreqsn和oldtrxid必填其一建议:商户如果同时拥有oldtrxid和oldreqsn,优先使用oldtrxid）
        /// </summary>
        public string oldreqsn { get; set; }

        /// <summary>
        /// 原交易流水（oldreqsn和oldtrxid必填其一建议:商户如果同时拥有oldtrxid和oldreqsn,优先使用oldtrxid）
        /// </summary>
        public string oldtrxid { get; set; }

        /// <summary>
        /// 备注(最大50个字节(25个中文字符))
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 随机生成的字符串
        /// </summary>
        public string randomstr { get; set; }
    }
}

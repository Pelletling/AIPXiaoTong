using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSP.Pay.ResponseModel;

namespace VSP.Pay.RequestModel
{
    public class QueryRequest : IBaseRequest<QueryResponse>
    {
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("version", version);
            dic.Add("reqsn", reqsn);
            dic.Add("trxid", trxid);
            dic.Add("randomstr", randomstr);

            return dic;
        }

        public string GetUrl()
        {
            return "https://vsp.allinpay.com/apiweb/unitorder/query";                
        }

        /// <summary>
        /// 接口版本号,默认填11
        /// </summary>
        public string version { get { return "11"; } }

        /// <summary>
        /// 商户的交易订单号，reqsn和trxid必填其一建议:商户如果同时拥有trxid和reqsn,优先使用trxid
        /// </summary>
        public string reqsn { get; set; }

        /// <summary>
        /// 支付的收银宝平台流水，reqsn和trxid必填其一建议:商户如果同时拥有trxid和reqsn,优先使用trxid
        /// </summary>
        public string trxid { get; set; }

        /// <summary>
        /// 随机生成的字符串
        /// </summary>
        public string randomstr { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class CancelPreFreezeRequest:IBaseRequest<CancelPreFreezeResponse>
    {
        public string GetApiName()
        {
            return "bron_bbc_margins.cancelPreFreeze";
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("channel", channel);
            dic.Add("bankOrderNo",bankOrderNo);
            dic.Add("transCode", transCode);

            return dic;
        }

        /// <summary>
        /// 合作方渠道ID
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// 银行订单号(若订单号为空，则身份证号和商户号为必输)
        /// </summary>
        public string bankOrderNo { get; set; }

        /// <summary>
        /// 接口码
        /// </summary>
        public string transCode { get; set; }
    }
}

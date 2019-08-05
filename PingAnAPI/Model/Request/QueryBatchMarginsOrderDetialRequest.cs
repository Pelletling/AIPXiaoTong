using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class QueryBatchMarginsOrderDetialRequest : IBaseRequest<QueryBatchMarginsOrderDetialResponse>
    {
        public string GetApiName()
        {
            return "bron_bbc_margins.qryBatchMarginsOrderDetial";
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("channel", channel);
            dic.Add("transCode", transCode);
            dic.Add("commercialNoII", commercialNoII);
            dic.Add("commercialOrderNo", commercialOrderNo);
            dic.Add("bankOrderNo", bankOrderNo);
            dic.Add("activityNo", activityNo);
            dic.Add("productCode", productCode);
            dic.Add("cardNumber", cardNumber);
            dic.Add("userName", userName);
            dic.Add("freezeStartTime", freezeStartTime);
            dic.Add("freezeEndTime", freezeEndTime);
            dic.Add("pageIndex", pageIndex.ToString());
            dic.Add("pageSize", pageSize.ToString());

            return dic;
        }

        /// <summary>
        /// 合作方渠道ID
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// 接口码
        /// </summary>
        public string transCode { get; set; }

        /// <summary>
        /// 二级商户号
        /// </summary>
        public string commercialNoII { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string commercialOrderNo { get; set; }

        /// <summary>
        /// 银行订单号
        /// </summary>
        public string bankOrderNo { get; set; }

        /// <summary>
        /// 活动号
        /// </summary>
        public string activityNo { get; set; }

        /// <summary>
        /// 产品号
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string cardNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 冻结时间起(格式：2018-06-06 )
        /// </summary>
        public string freezeStartTime { get; set; }

        /// <summary>
        /// 冻结时间止(格式：2018-06-06 )
        /// </summary>
        public string freezeEndTime { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int? pageIndex { get; set; }

        /// <summary>
        /// 页面含有多少条数据
        /// </summary>
        public int? pageSize { get; set; }
    }
}

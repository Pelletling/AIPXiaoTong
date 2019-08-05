using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class QueryBatchMarginsOrderDetialResponse : BaseResponse
    {
        public DataObject dataObject { get { return !string.IsNullOrWhiteSpace(data) ? JsonHelper.Deserialize<DataObject>(data) : new DataObject(); } }

        public class DataObject
        {
            /// <summary>
            /// 总记录数
            /// </summary>
            public int totalRows { get; set; }

            /// <summary>
            /// 当前页
            /// </summary>
            public int currentPage { get; set; }

            public List<marginsOrderInfo> marginsOrderInfoList { get; set; }

            public class marginsOrderInfo
            {
                /// <summary>
                /// 银行订单号
                /// </summary>
                public string bankOrderNo { get; set; }

                /// <summary>
                /// 商户订单号
                /// </summary>
                public string commercialOrderNo { get; set; }

                /// <summary>
                /// 二级商户号
                /// </summary>
                public string commercialNoII { get; set; }

                /// <summary>
                /// 二级商户简称
                /// </summary>
                public string commercialShortNameII { get; set; }

                /// <summary>
                /// 活动号
                /// </summary>
                public string activityNo { get; set; }

                /// <summary>
                /// 活动名称
                /// </summary>
                public string activityName { get; set; }

                /// <summary>
                /// 产品号
                /// </summary>
                public string productCode { get; set; }

                /// <summary>
                /// 产品名称
                /// </summary>
                public string productName { get; set; }

                /// <summary>
                /// 身份证号
                /// </summary>
                public string cardNumber { get; set; }

                /// <summary>
                /// 姓名
                /// </summary>
                public string userName { get; set; }

                /// <summary>
                /// 手机号
                /// </summary>
                public string mobilePhone { get; set; }

                /// <summary>
                /// 订单金额
                /// </summary>
                public double orderAmt { get; set; }

                /// <summary>
                /// 止付金额(实际冻结的金额)
                /// </summary>
                public double freezeAmt { get; set; }

                /// <summary>
                /// 划拨金额(只有商户划拨了之后才有划拨金额--有可能为空)
                /// </summary>
                public double finishTransferAmt { get; set; }

                /// <summary>
                /// 冻结时间(String(20)	格式：2018-06-06)
                /// </summary>
                public string freezeTime { get; set; }

                /// <summary>
                /// 订单状态(1-预止付 2-已撤销 3-已止付 4-已解止付 5-已过期)
                /// </summary>
                public string transStatus { get; set; }
            }
        }
    }
}

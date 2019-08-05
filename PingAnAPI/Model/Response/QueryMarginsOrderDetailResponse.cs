﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class QueryMarginsOrderDetailResponse : BaseResponse
    {
        public DataObject dataObject { get { return !string.IsNullOrWhiteSpace(data) ? JsonHelper.Deserialize<DataObject>(data) : new DataObject(); } }

        public class DataObject
        {
            /// <summary>
            /// 活动ID
            /// </summary>
            public string activityNo { get; set; }

            /// <summary>
            /// 止付金额(20，2),实际冻结的金额
            /// </summary>
            public double freezeAmt { get; set; }

            /// <summary>
            /// 划拨金额,只有商户划拨了之后才有划拨金额,有可能为空
            /// </summary>
            public double finishTransferAmt { get; set; }

            /// <summary>
            /// 客户姓名
            /// </summary>
            public string userName { get; set; }

            /// <summary>
            /// 客户身份证
            /// </summary>
            public string cardNumber { get; set; }

            /// <summary>
            /// 订单状态(1-预止付 2-已撤销 3-已止付 4-已解止付  5-已过期)
            /// </summary>
            public string transStatus { get; set; }
        }
    }
}
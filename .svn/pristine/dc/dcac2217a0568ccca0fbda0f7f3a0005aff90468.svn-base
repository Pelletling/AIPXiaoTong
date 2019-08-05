using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class PreparedFreezeOrderResponse : BaseResponse
    {
        public DataObject dataObject { get { return !string.IsNullOrWhiteSpace(data) ? JsonHelper.Deserialize<DataObject>(data) : new DataObject(); } }
        public class DataObject
        {
            /// <summary>
            /// 银行订单号
            /// </summary>
            public string bankOrderNo { get; set; }
        }
    }
}

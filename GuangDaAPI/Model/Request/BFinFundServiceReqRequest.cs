using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuangDaAPI.Model
{
    public class BFinFundServiceReqRequest : IBaseRequest<BFinFundServiceReqResponse>
    {
        /// <summary>
        /// 对账
        /// </summary>
        public BFinFundServiceReqRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }
        
        public string Method { get { return "BFinFundServiceReq"; } }
        public string Action { get { return ""; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("QryDate", Body.QryDate);
            dic.Add("ServiceId", Body.ServiceId);

            return dic;
        }

        public string Sort(string signContent)
        {
            return signContent;
        }
        
        public HEAD Head { get; set; }
        
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 交易所属日期（该日期表示请求的是哪天的文件，如不送，默认前一天）
            /// </summary>
            public string QryDate { get; set; }

            /// <summary>
            /// 请求服务ID
            /// BMerCheckFileReq--根据光大系统时间生成对账文件
            /// BMerCheckJnlFileReq--根据商户时间生成对账文件
            /// BMerCheck4ForeignCashFileReq-结汇业务对账文件请求服务
            /// </summary>
            public string ServiceId { get; set; }
        }
    }
}

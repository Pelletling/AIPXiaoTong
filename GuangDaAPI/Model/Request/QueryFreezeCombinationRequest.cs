using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    public class QueryFreezeCombinationRequest : IBaseRequest<QueryFreezeCombinationResponse>
    {

        /// <summary>
        /// 2.49.	冻结状态查询接口
        /// </summary>
        public QueryFreezeCombinationRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        public string Method { get { return "QueryFreezeCombination"; } }
        public string Action { get { return ""; } }

        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("QryCount", Body.QryCount.ToString());
            dic.Add("StartCount", Body.StartCount.ToString());
            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("FreezeType", Body.FreezeType);
            dic.Add("State", Body.State);
            dic.Add("FreezeDate", Body.FreezeDate);
            dic.Add("UnfreezeDate", Body.UnfreezeDate);
            dic.Add("Reserve1", Body.Reserve1);
            dic.Add("Reserve2", Body.Reserve2);
            dic.Add("Reserve3", Body.Reserve3);
            dic.Add("Reserve4", Body.Reserve4);
            dic.Add("Reserve5", Body.Reserve5);

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
            /// 查询笔数（不超过99笔）
            /// </summary>
            public int QryCount { get; set; }

            /// <summary>
            /// 起始笔数
            /// </summary>
            public int StartCount { get; set; }

            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            public string CifClientId { get; set; }

            /// <summary>
            /// 冻结类型（0-金额冻结 1-冻结(只进不出) 2-封闭冻结(不进不出)）
            /// </summary>
            public string FreezeType { get; set; }

            /// <summary>
            /// 记录状态（0-冻结 4-解冻 A-全部）
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// 冻结起始日期
            /// </summary>
            public string FreezeDate { get; set; }

            /// <summary>
            /// 冻结到期日期
            /// </summary>
            public string UnfreezeDate { get; set; }

            /// <summary>
            ///备用字段
            /// </summary>
            public string Reserve1 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve2 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve3 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve4 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            public string Reserve5 { get; set; }

        }
    }
}
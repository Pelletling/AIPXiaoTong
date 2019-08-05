using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    public class AuthenticationToOpenAccountCheckRequest : IBaseRequest<AuthenticationToOpenAccountCheckResponse>
    {

        /// <summary>
        /// 2.60.	鉴权开户结果查询
        /// </summary>
        public AuthenticationToOpenAccountCheckRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        public string Method { get { return "AuthenticationToOpenAccountCheck"; } }
        public string Action { get { return ""; } }

        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            
            dic.Add("CoPatrnerJnlNo", Body.CoPatrnerJnlNo);
            dic.Add("CifClientId", Body.CifClientId);           
            dic.Add("BookDate", Body.BookDate);
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
            /// 合作伙伴交易请求流水号（唯一标识）
            /// </summary>
            public string CoPatrnerJnlNo { get; set; }
            
            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            public string CifClientId { get; set; }
            
            /// <summary>
            /// 交易所属日期
            /// </summary>
            public string BookDate { get; set; }

            /// <summary>
            /// II、III类户标志，（0-II类账户，1-III类账户）
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
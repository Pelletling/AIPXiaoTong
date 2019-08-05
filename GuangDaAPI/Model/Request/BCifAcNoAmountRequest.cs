using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace GuangDaAPI.Model
{
    public class BCifAcNoAmountRequest : IBaseRequest<BCifAcNoAmountResponse>
    {

        /// <summary>
        /// 电子账户余额查询
        /// </summary>
        public BCifAcNoAmountRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }
        
        public string Method { get { return "BCifAcNoAmount"; } }
        public string Action { get { return ""; } }

        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("CifClientId", Body.CifClientId);
            dic.Add("IdNo", Body.IdNo);
            dic.Add("IdType", Body.IdType);

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
            /// 接入方客户标识号
            /// </summary>
            public string CifClientId { get; set; }

            /// <summary>
            /// 证件号码
            /// </summary>
            public string IdNo { get; set; }

            /// <summary>
            /// 证件类型
            /// </summary>
            public string IdType { get; set; }

        }

    }


}

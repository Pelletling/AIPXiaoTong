using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuangDaAPI.Model
{
   
    public class BaseResponse
    {
        private List<string> WaitCodeList = new List<string> { "000002", "000260", "000288" };
        public BaseResponse()
        {
            Head = new HEAD();
        }        

        public HEAD Head { get; set; }

        public bool IsOK { get { return Head.ResCode == "000000" ? true : false; } }

        public bool IsWait { get { return WaitCodeList.Contains(Head.ResCode) ? true : false; } }

        public bool IsFail { get { return !WaitCodeList.Contains(Head.ResCode) && Head.ResCode != "000000" ? true : false; } }

        public bool IsNotExists { get { return Head.ResCode == "000212" ? true : false; } }
        public class HEAD
        {

            /// <summary>
            /// 原请求发起流水号
            /// </summary>
            public string ReqJnlNo { get; set; }

            /// <summary>
            /// 交易响应流水号(平台对交易的唯一标识(发起查询，产品文件同步和理财预约对账文件交易时，该值为空)
            /// </summary>
            public string ResJnlNo { get; set; }

            /// <summary>
            /// 交易响应时间
            /// </summary>
            public string ResTime { get; set; }

            /// <summary>
            /// 交易响应码
            /// </summary>
            public string ResCode { get; set; }

            /// <summary>
            /// 交易响应信息
            /// </summary>
            public string ResMsg { get; set; }
        }

        
    }
}

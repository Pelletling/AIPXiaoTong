using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSP.Pay.ResponseModel
{
    public class BaseResponse
    {
        /// <summary>
        /// 返回码(此字段是通信标识，非交易结果，交易是否成功需要查看trxstatus来判断)
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回码说明
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// 返回码(此字段是通信标识)
        /// </summary>
        public bool isRet {
            get {
                if (retcode == "SUCCESS")
                    return true;
                else
                    return false;                
            }
        }

    }
}

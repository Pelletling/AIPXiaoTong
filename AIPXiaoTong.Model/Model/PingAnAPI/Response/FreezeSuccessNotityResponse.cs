using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class FreezeSuccessNotityResponse
    {
        /// <summary>
        /// 返回状态码(000000表示商户接收成功并且校验成功其他失败)
        /// </summary>
        public string returnCode { get; set; }

        /// <summary>
        /// 响应信息(错误原因)
        /// </summary>
        public string returnMsg { get; set; }

    }
}

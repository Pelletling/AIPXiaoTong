using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class AccountPingAnDM
    {

        /// <summary>
        /// 保证金订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// Pos机转账数据
        /// </summary>
        public string transData { get; set; }

    }
}

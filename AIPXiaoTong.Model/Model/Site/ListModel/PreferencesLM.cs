using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class PreferencesLM : BaseListModel
    {
        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// APPID
        /// </summary>
        public string APPID { get; set; }

        /// <summary>
        /// 收银宝商户号
        /// </summary>
        public string POSBaoMerchant { get; set; }

        /// <summary>
        /// 收银宝Key
        /// </summary>
        public string POSBaoKey { get; set; }
    }
}

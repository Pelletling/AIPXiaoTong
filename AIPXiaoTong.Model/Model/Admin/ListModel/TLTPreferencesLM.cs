using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class TLTPreferencesLM : BaseListModel
    {
        /// <summary>
        /// 商户信息
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// 通联通商户ID
        /// </summary>
        public string TltMerchantId { get; set; }

        /// <summary>
        /// 通联通用户名
        /// </summary>
        public string TltUserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string TltUserPassword { get; set; }

        /// <summary>
        /// 私钥密码
        /// </summary>
        public string TltPrivateKeyPassword { get; set; }
    }
}

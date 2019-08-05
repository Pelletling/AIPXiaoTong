using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class DistrictManagementLM : BaseListModel
    {
        public long MerchantID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}

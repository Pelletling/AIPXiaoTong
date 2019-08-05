using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class HouseTypeShowLM : BaseListModel
    {
        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }
        public long MerchantID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        public long ProjectID { get; set; }
        /// <summary>
        /// 户型名称
        /// </summary>
        public string HouseTypeName { get; set; }

        /// <summary>
        /// 户型面积
        /// </summary>
        public decimal? HouseTypeArea { get; set; }

        /// <summary>
        /// 户型展示图
        /// </summary>
        public string HouseShowImage { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StatusDesc { get; set; }

        /// <summary>
        /// 未通过原因
        /// </summary>
        public string Reason { get; set; }

        public List<string> HouseShowImageList { get; set; }


    }
}

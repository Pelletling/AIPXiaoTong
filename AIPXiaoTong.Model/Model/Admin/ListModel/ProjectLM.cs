using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class ProjectLM : BaseListModel
    {
        public string MerchantName { get; set; }
        public long MerchantID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目图片
        /// </summary>
       // public string ProjectImage { get; set; }

        /// <summary>
        /// 广告图片
        /// </summary>
        public string AdvertisingImge { get; set; }

        /// <summary>
        /// 项目金额
        /// </summary>
        public decimal ProjectAmount { get; set; }

        /// <summary>
        /// 认筹额度
        /// </summary>
        public decimal ReceiveAmount { get; set; }

        /// <summary>
        /// 剩余认筹额度
        /// </summary>
        public decimal ResidueAmount { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// 简短描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 未通过原因
        /// </summary>
        public string Reason { get; set; }


        public string StatusDesc { get; set; }

        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public decimal GuaranteeAmount { get; set; }

        public int GuaranteeMonth { get; set; }
        public List<string> AdvertisingImgList { get; set; }
    }
}

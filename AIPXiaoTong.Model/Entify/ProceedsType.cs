using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class ProceedsType : BaseEntity
    {
        [Display(Name = "商户ID")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 收款类型
        /// </summary>
        [Display(Name = "收款类型")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Type { get; set; }

        //-------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }

        public string MerchantName { get { return Merchant?.Name; } }
    }
}

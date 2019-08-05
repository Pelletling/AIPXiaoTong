using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class MerchantMember : BaseEntity
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [Display(Name = "会员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MemberID { get; set; }

        //-----------------------------------------------------
        public virtual Member Member { get; set; }
    }
}

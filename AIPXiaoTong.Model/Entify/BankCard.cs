using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class BankCard : BaseEntity
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "会员ID")]
        public long MemberID { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Display(Name = "银行卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Index(IsUnique = true)]
        public string BankCardNumber { get; set; }
        
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        public string Mobile { get; set; }

        /// <summary>
        /// 银行ID
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "银行ID")]
        public long BankID { get; set; }

        /// <summary>
        /// 银行网点名称
        /// </summary>
        [Display(Name = "银行网点名称")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string SubBranchName { get; set; }
        

        //--------------------------------------------------------
        public virtual Member Member { get; set; }
        public string MemberName { get { return Member?.Name; } }

        public virtual Bank Bank { get; set; }

        public string BankName { get { return Bank?.Name; } }

        public string StatusDesc { get { return ((BankCardStatus)Status).ToDescription(); } }

    }
}

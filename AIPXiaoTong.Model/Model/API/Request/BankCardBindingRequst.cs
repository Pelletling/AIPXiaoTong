using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class BankCardBindingRequst : BaseRequest
    {
        [Display(Name = "会员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long memberid { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string name { get; set; }

        /// <summary>
        /// 预留手机号
        /// </summary>
        [Display(Name = "预留手机号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        public string mobile { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Display(Name = "银行卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string bankcardnumber { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        public string idnumber { get; set; }

        /// <summary>
        /// 所属银行
        /// </summary>
        [Display(Name = "所属银行")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string bankcode { get; set; }

        /// <summary>
        /// 银行网点名称
        /// </summary>
        [Display(Name = "银行网点名称")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string subbranchname { get; set; }
    }
}

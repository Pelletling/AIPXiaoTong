using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class CreateOrderBookingRequst : BaseRequest
    {

        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目名称ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long projectid { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        /// <summary>
        [Display(Name = "操作员")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long employeeid { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        [Display(Name = "预约时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ordertime { get; set; }

        /// <summary>
        /// 预约姓名
        /// </summary>
        [Display(Name = "预约人姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string name { get; set; }

        /// <summary>
        /// 预约手机号
        /// </summary>
        [Display(Name = "预约手机号")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string mobile { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string remark { get; set; }

    }
}

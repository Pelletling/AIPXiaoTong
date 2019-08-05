﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class CreateOrderPaidRequst : BaseRequest
    {

        /// <summary>
        /// 户型名称(对应外键)
        /// </summary>
        //[Display(Name = "户型ID")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public long housetypeshowid { get; set; }

        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long projectid { get; set; }

        /// <summary>
        /// 操作人员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "员工ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long employeeid { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        [Display(Name = "交易金额")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal transactionamount { get; set; }

        /// <summary>
        /// 注册会员（外键ID）
        /// </summary>
        /// <summary>
        //[Display(Name = "注册会员ID")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public long memberid { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idnumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(50, ErrorMessage = "{0}不能多于50位")]
        public string remark { get; set; }
    }
}

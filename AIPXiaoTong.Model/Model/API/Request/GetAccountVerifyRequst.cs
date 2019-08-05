﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class GetAccountVerifyRequst : BaseRequest
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
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string mobile { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idnumber { get; set; }

        /// <summary>
        /// 银行卡账号
        /// </summary>
        [Display(Name = "银行卡账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string barknumber { get; set; }
    }
}
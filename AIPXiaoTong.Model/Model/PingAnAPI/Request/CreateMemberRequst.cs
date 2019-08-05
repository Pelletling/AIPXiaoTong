﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class CreateMemberRequst : BaseRequest
    {
        /// <summary>
        /// 会员姓名
        /// </summary>
        [Display(Name = "会员姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idnumber { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        [Display(Name = "客户手机号")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string mobile { get; set; }

        /// <summary>
        /// 身份证照片(正面)
        /// </summary>
        [Display(Name = "身份证照片（正面）")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idimagefront { get; set; }

        /// <summary>
        /// 身份证照片(反面)
        /// </summary>
        [Display(Name = "身份证照片(反面)")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idimageopposite { get; set; }

        /// <summary>
        /// 证件有效期(格式:yyyyMMdd)
        /// </summary>
        [Display(Name = "证件有效期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idexpireddate { get; set; }

        /// <summary>
        /// 设备SN号
        /// </summary>
        //[Display(Name = "设备SN号")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string equipmentsnno { get; set; }
    }
}

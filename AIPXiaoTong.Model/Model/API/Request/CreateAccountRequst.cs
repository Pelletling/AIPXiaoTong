﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class CreateAccountRequst : BaseRequest
    {
        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idnumber { get; set; }
        
        /// <summary>
        /// 联系地址(8-30个汉字)
        /// </summary>
        [Display(Name = "联系地址")]
        [MaxLength(30, ErrorMessage = "{0}不能多于30位")]
        [MinLength(8,ErrorMessage = "{0}不能少于8位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string address { get; set; }     

        /// <summary>
        /// 邮编
        /// </summary>
        [Display(Name = "邮编")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string postcode { get; set; }

        /// <summary>
        /// 客户所在省份代号（机构号由光大线下提供）
        /// </summary>
        [Display(Name = "客户所在省份")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string provincecode { get; set; }

        /// <summary>
        /// 客户所在城市代号（机构号由光大线下提供）
        /// </summary>
        [Display(Name = "客户所在城市")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string citycode { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Display(Name = "银行卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string bankcardnumber { get; set; }

        /// <summary>
        /// 预留手机号
        /// </summary>
        [Display(Name = "预留手机号")]
        [StringLength(11,MinimumLength =11, ErrorMessage = "{0}必须是11位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string mobile { get; set; }

        /// <summary>
        /// 所属银行
        /// </summary>
        [Display(Name = "所属银行")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string bankcode { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [Display(Name = "职业")]
        //[Required(ErrorMessage = "{0}不能为空")]
        public string occupation { get; set; }

    }
}

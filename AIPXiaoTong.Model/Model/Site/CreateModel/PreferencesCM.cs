﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Site
{
    public class PreferencesCM:BaseCreateModel
    {
        /// <summary>
        /// 商户信息
        /// </summary>
        //[Display(Name = "商户信息")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //[MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        ////[Remote("CodeIsExists", "Preferences", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        ////[Index(IsUnique = true)]
        //public string MerchantInfo { get; set; }

        /// <summary>
        /// APPID
        /// </summary>
        [Display(Name = "APPID")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string APPID { get; set; }

        /// <summary>
        /// 收银宝商户号
        /// </summary>
        [Display(Name = "收银宝商户号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string POSBaoMerchant { get; set; }

        /// <summary>
        /// 收银宝Key
        /// </summary>
        [Display(Name = "收银宝Key")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string POSBaoKey { get; set; }
    }
}

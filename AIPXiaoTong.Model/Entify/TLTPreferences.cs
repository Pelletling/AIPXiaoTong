﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class TLTPreferences : BaseEntity
    {
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }


        /// <summary>
        /// 通联通商户ID
        /// </summary>
        [Display(Name = "通联通商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string TltMerchantId { get; set; }

        /// <summary>
        /// 通联通用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string TltUserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TltUserPassword { get; set; }

        /// <summary>
        /// 私钥密码
        /// </summary>
        [Display(Name = "私钥密码")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TltPrivateKeyPassword { get; set; }

        /// <summary>
        /// 通联通安全证书
        /// </summary>
        [Display(Name = "通联通安全证书")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TLTSecurityCer { get; set; }

        /// <summary>
        /// 通联通私钥证书
        /// </summary>
        [Display(Name = "通联通私钥证书")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TLTPrivateKeyCer { get; set; }

        //--------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }
        public string MerchantName { get { return Merchant?.Name; } }
    }
}

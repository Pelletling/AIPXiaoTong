﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Preferences : BaseEntity
    {
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 商户信息
        /// </summary>
        //[Display(Name = "商户信息")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //[MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        //[Index(IsUnique = true)]
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

        //--------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }
        public string MerchantName { get { return Merchant?.Name; } }

    }
}
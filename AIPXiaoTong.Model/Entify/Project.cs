﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Project : BaseEntity
    {
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 广告图片
        /// </summary>
        [Display(Name = "广告图片")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AdvertisingImge { get; set; }

        /// <summary>
        /// 项目金额
        /// </summary>
        [Display(Name = "项目金额")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal ProjectAmount { get; set; }

        /// <summary>
        /// 已认筹额度
        /// </summary>
        [Display(Name = "认筹额度")]
        public decimal ReceiveAmount { get; set; }

        /// <summary>
        /// 活动开始日期
        /// </summary>
        [Display(Name = "开始日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        [Display(Name = "截止日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// 简短描述
        /// </summary>
        [Display(Name = "简短描述")]
        [MaxLength(1024, ErrorMessage = "{0}不能多于1024字")]
        public string Description { get; set; }

        /// <summary>
        /// 未通过原因
        /// </summary>
        [Display(Name = "未通过原因")]
        [MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        public string Reason { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Display(Name = "省")]
        [MaxLength(8, ErrorMessage = "{0}不能多于8位")]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Display(Name = "市")]
        [MaxLength(8, ErrorMessage = "{0}不能多于8位")]
        public string CityCode { get; set; }

        /// <summary>
        /// 认筹金额
        /// </summary>
        [Display(Name = "认筹金额")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal GuaranteeAmount { get; set; }

        /// <summary>
        /// 冻结月数
        /// </summary>
        [Display(Name = "冻结月数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GuaranteeMonth { get; set; }


        //--------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }

        public virtual Area Province { get; set; }
        public virtual Area City { get; set; }

        public string MerchantName { get { return Merchant?.Name; } }

        public string StatusDesc { get { return ((ProjectStatus)Status).ToDescription(); } }

        public string ProvinceName { get { return Province?.Name; } }

        public string CityName { get { return City?.Name; } }

        public List<string> AdvertisingImgList { get { return JsonHelper.Deserialize<List<string>>(AdvertisingImge == null ? "" : AdvertisingImge); } }

        /// <summary>
        /// 剩余认筹额度
        /// </summary>
        [Display(Name = "剩余认筹额度")]
        public decimal ResidueAmount { get { return this.ProjectAmount - this.ReceiveAmount; } }
    }
}
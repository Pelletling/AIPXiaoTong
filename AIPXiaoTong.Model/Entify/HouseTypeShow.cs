﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class HouseTypeShow : BaseEntity
    {
        [Display(Name = "商户ID")]
        public long? MerchantID { get; set; }
        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ProjectID { get; set; }

        /// <summary>
        /// 户型名称(对应外键)
        /// </summary>
        [Display(Name = "户型名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32字")]
        public string HouseTypeName { get; set; }

        /// <summary>
        /// 户型面积
        /// </summary>
        [Display(Name = "户型面积")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal? HouseTypeArea { get; set; }

        /// <summary>
        /// 户型图片
        /// </summary>
        [Display(Name = "户型图片")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string HouseShowImage { get; set; }

        /// <summary>
        /// 描述内容
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(1024, ErrorMessage = "{0}不能多于1024字")]
        public string Content { get; set; }

        /// <summary>
        /// 未通过原因
        /// </summary>
        [Display(Name = "未通过原因")]
        [MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        public string Reason { get; set; }


        //--------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }

        public virtual Project Project { get; set; }

        public string MerchantName { get { return Merchant?.Name; } }

        public string ProjectName { get { return Project?.ProjectName; } }
        public string StatusDesc { get { return ((HouseTypeShowStatus)Status).ToDescription(); } }

        public List<string> HouseShowImageList { get { return JsonHelper.Deserialize<List<string>>(HouseShowImage == null ? "" : HouseShowImage); } }
    }
}

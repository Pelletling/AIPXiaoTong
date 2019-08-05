﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Admin
{
    public class HouseTypeShowCM : BaseCreateModel
    {
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ProjectID { get; set; }
        /// <summary>
        /// 户型名称
        /// </summary>
        [Display(Name = "户型名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32字")]
        [Remote("CodeIsExists", "HouseTypeShow", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string HouseTypeName { get; set; }

        /// <summary>
        /// 户型面积
        /// </summary>
        [Display(Name = "户型面积")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal? HouseTypeArea { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        //[Display(Name = "描述")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //[MaxLength(100, ErrorMessage = "{0}不能多于100字")]
        //public string Description { get; set; }

        /// <summary>
        /// 户型缩略图
        /// </summary>
        //[Display(Name = "户型缩略图")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //[MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        //public string HouseThumbnailImage { get; set; }

        /// <summary>
        /// 户型展示图
        /// </summary>
        [Display(Name = "户型展示图")]
        public List<string> HouseShowImageList { get; set; }

        /// <summary>
        /// 描述内容
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(300, ErrorMessage = "{0}不能多于300字")]
        public string Content { get; set; }

        /// <summary>
        /// 户型展示图
        /// </summary>
        [Display(Name = "户型展示图")]
        public string HouseShowImage { get; set; }
    }
}
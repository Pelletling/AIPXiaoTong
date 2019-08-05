using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AIPXiaoTong.Model.Attribute;

namespace AIPXiaoTong.Model.Site
{

    public class HouseTypeShowCM : BaseCreateModel
    {
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
        public List<string> HouseShowImageList { get; set; }

        /// <summary>
        /// 描述内容
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(1024, ErrorMessage = "{0}不能多于1024字")]
        public string Content { get; set; }

        /// <summary>
        /// 户型图片
        /// </summary>
        [Display(Name = "户型图片")]
        public string HouseShowImage { get; set; }

    }
}

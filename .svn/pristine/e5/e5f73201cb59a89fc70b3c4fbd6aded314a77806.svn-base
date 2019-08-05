using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class UploadIDCardImgRequst:BaseRequest
    {
        [Display(Name = "会员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long memberid { get; set; }

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
    }
}

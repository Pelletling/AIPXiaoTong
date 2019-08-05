using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{

    public class ModifyPasswordCM : BaseCreateModel
    {
        public ModifyPasswordCM()
        {

        }


        /// <summary>
        /// 原密码
        /// </summary>
        [Display(Name = "原密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0}必须在6-16位之间")]
        public string OriginalPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Display(Name = "新密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0}必须在6-16位之间")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0}必须在6-16位之间")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "两次密码不一致")]
        public string ConfirmPassword { get; set; }

    }
}

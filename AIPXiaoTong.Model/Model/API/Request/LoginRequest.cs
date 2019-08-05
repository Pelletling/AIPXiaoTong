using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class LoginRequest : BaseRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string employeecode { get; set; }

        /// <summary>
        /// 密码(MD5值)
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string password { get; set; }

    }
}

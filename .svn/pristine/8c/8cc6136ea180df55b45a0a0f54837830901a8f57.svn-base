using AIPXiaoTong.Model.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Admin
{

    public class UserCM : BaseCreateModel
    {
        public UserCM()
        {
            AuthDepartmentIDList = new List<long?>();
        }
        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Remote("CodeIsExists", "User", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Remote("NameIsExists", "User", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(64)]
        [EmailAddress]
        [Remote("EmailIsExists", "User", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Email { get; set; }
                
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long? RoleID { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DepartmentID { get; set; }

        /// <summary>
        /// 权限的部门ID集合
        /// </summary>
        [Display(Name = "权限的部门ID集合")]
        public List<long?> AuthDepartmentIDList { get; set; }

        public string[] AuthDepartmentIDArray { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [UserPasswordAttribute]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0}必须在6-16位之间")]
        public string Password { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public int? Job { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}不能多于11位")]
        public string Mobile { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string RealName { get; set; }

        /// <summary>
        /// 查看更多
        /// </summary>
        [Display(Name = "查看更多")]
        public int IsMore { get; set; }
    }

}

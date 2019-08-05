using AIPXiaoTong.Model.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Site
{
    public class EmployeeCM : BaseCreateModel
    {
        public EmployeeCM()
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
        [Remote("CodeIsExists", "Employee", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Remote("NameIsExists", "Employee", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(64)]
        [EmailAddress]
        [Remote("EmailIsExists", "Employee", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Email { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long? EmployeeRoleID { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? EmployeeDepartmentID { get; set; }

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
        [Password]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "{0}必须在6-16位之间")]
        public string Password { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [MinLength(11, ErrorMessage = "{0}必须是11位数字")]
        [MaxLength(11, ErrorMessage = "{0}必须是11位数字")]
        public string Mobile { get; set; }

        /// <summary>
        /// 查看更多
        /// </summary>
        [Display(Name = "查看更多")]
        public int IsMore { get; set; }

    }
}

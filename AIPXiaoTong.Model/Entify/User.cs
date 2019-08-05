using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    [Table("Users")]
    public class User : BaseEntity
    {

        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(64)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        [MaxLength(11, ErrorMessage = "{0}不能多于11位")]
        public string Mobile { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Password { get; set; }

        /// <summary>
        /// 查看更多
        /// </summary>
        [Display(Name = "查看更多")]
        public int IsMore { get; set; }

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
        public string AuthDepartmentIDs { get; set; }

        //----------------------------   virtual  ----------------------------------------



        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        public string RoleName { get { return Role?.Name; } }

        public string DepartmentName { get { return Department?.Name; } }

        public string StatusDesc { get { return ((UserStatus)this.Status).ToDescription(); } }

        public bool IsAdmin { get { return GlobalConfig.WebConfig.Administrators.Contains(Code); } }

        public List<long?> AuthDepartmentIDList
        {
            get
            {
                return AuthDepartmentIDs.ToLongList();
            }
        }

        [NotMapped]
        public IList<long> MenuActionList { get { return Role?.MenuActionList ?? new List<long>(); } }

    }
}

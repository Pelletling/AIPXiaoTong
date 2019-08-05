using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Site
{
    public class EmployeeDepartmentCM : BaseCreateModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Remote("NameIsExists", "EmployeeDepartment", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string Name { get; set; }

        public long? ParentID { get; set; }

    }
}

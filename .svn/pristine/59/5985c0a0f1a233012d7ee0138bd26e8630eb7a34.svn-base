using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AIPXiaoTong.Model.Admin
{

    public class RoleCM : BaseCreateModel
    {
        public RoleCM()
        {
            MenuIDList = new List<long?>();
            ActionIDList = new List<long?>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Remote("NameIsExists", "Role", ErrorMessage = "{0}已存在", AdditionalFields = "ID")]
        public string Name { get; set; }


        /// <summary>
        /// 授权的菜单
        /// </summary>
        [Display(Name = "授权的菜单")]
        public string Menus { get; set; }

        /// <summary>
        /// 授权的操作
        /// </summary>
        [Display(Name = "授权的操作")]
        [MaxLength(1024, ErrorMessage = "{0}不能多于1024位")]
        public string MenuActions { get; set; }



        //--------------------------------------------------------------
        /// <summary>
        /// 菜单ID集合
        /// </summary>
        public List<long?> MenuIDList { get; set; }

        public List<long?> ActionIDList { get; set; }
    }
}

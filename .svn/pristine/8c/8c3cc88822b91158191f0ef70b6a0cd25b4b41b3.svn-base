using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Menu : BaseEntity
    {

        public Menu()
        {
            MenuActionList = new List<MenuAction>();
        }

        /// <summary>
        /// 编码
        /// </summary>
        [Key]
        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        [MaxLength(64, ErrorMessage = "{0}不能多于64位")]
        public string Url { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        [Display(Name = "上级菜单")]

        public string ParentCode { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        [Display(Name = "控制器")]
        [MaxLength(64, ErrorMessage = "{0}不能多于64位")]
        public string Controller { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        [Display(Name = "操作")]
        [MaxLength(64, ErrorMessage = "{0}不能多于64位")]
        public string Action { get; set; }

        //----------------------------   virtual  ----------------------------------------
        /// <summary>
        /// 上级菜单
        /// </summary>
        [ForeignKey("ParentCode")]
        public virtual Menu ParentMenu { get; set; }


        /// <summary>
        /// 菜单的操作
        /// </summary>
        public virtual IList<MenuAction> MenuActionList { get; set; }


        //---------------------------   NotMapped   ------------------------------------
        [NotMapped]
        public int Level { get { return Code.Length / 3; } }

        public string ParentName
        {
            get { return ParentMenu?.Name; }
        }

    }
}

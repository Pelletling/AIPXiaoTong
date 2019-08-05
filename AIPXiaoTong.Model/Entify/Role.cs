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
   public class Role: BaseEntity
    {

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Index(IsUnique = true)]
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
        public string MenuActions { get; set; }

        //----------------------------   virtual  ----------------------------------------

        [NotMapped]
        public virtual IList<User> UserList { get; set; }

        public IList<long> MenuActionList { get { return MenuActions.SplitToLong(); } }
        
    }
}

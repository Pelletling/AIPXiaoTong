using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class MenuAction : BaseEntity
    {

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(3, ErrorMessage = "{0}不能少于3位")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Index("MenuAction_IX", IsUnique = true, Order = 1)]
        public string MenuCode { get; set; }


        /// <summary>
        /// 操作编码
        /// </summary>
        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Index("MenuAction_IX", IsUnique = true, Order = 2)]
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
        /// 排序
        /// </summary>
        public int Sort { get; set; }


        //----------------------------   virtual  ----------------------------------------

        /// <summary>
        /// 菜单
        /// </summary>
        [ForeignKey("MenuCode")]
        public virtual Menu Menu { get; set; }


    }
}

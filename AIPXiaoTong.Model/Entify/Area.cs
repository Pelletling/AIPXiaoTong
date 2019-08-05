using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Area:BaseEntity
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Key]
        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MinLength(2, ErrorMessage = "{0}不能少于2位")]
        [MaxLength(8, ErrorMessage = "{0}不能多于8位")]
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
        /// 上级编码
        /// </summary>
        [Display(Name = "上级编码")]
        public string ParentCode { get; set; }

        /// <summary>
        /// 上级区域
        /// </summary> 
        [ForeignKey("ParentCode")]
        [Display(Name = "上级区域")]
        public virtual Area Parent { get; set; }

        public virtual IList<Area> ChildList { get; set; }

        /// <summary>
        /// 等级  
        /// </summary> 
        public int Level { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Bank : BaseEntity
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string Name { get; set; }

        /// <summary>
        /// 光大银行代码
        /// </summary>
        [Display(Name = "光大银行代码")]
        public string CodeGuangDa { get; set; }
        
    }
}

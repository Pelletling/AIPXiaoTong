using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
   public class BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public long ID { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [Display(Name = "状态")]
        public int Status { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "创建时间")]
        public DateTime CreateDatetime { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime? ModifyDatetime { get; set; }


        /// <summary>
        /// 行版本
        /// </summary>
        [Display(Name = "行版本")]
        [Timestamp]
        //[ConcurrencyCheck]//对某个字段作并发控制
        public byte[] RowVersion { get; set; }
    }
}

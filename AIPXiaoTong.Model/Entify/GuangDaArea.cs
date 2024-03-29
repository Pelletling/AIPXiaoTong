﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class GuangDaArea : BaseEntity
    {
        /// <summary>
        /// 编码(地区代码--人行下发)
        /// </summary>
        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string Name { get; set; }
    }
}

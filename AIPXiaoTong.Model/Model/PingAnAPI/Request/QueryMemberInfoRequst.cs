﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryMemberInfoRequst:BaseRequest
    {
        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string idnumber { get; set; }
    }
}
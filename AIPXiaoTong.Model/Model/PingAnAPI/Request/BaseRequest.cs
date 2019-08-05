﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class BaseRequest
    {      
        /// <summary>
        /// 请求流水号
        /// </summary>
        [Display(Name = "请求流水号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string requestno { get; set; }

        /// <summary>
        /// 设备SN号
        /// </summary>
        [Display(Name = "设备SN号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string equipmentsnno { get; set; }

        /// <summary>
        /// 合作方渠道ID
        /// </summary>
        //[Display(Name = "合作方渠道ID")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string channel { get; set; }

        /// <summary>
        /// 接口码(001)
        /// </summary>
        //[Display(Name = "接口码")]
        //[MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string transcode { get; set; }

    }
}
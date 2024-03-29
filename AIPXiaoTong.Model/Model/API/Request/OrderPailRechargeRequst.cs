﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class OrderPailRechargeRequst : BaseRequest
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Display(Name = "订单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ordernumber { get; set; }
    }
}

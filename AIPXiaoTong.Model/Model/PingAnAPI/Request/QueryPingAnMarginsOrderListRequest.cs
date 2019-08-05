﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryPingAnMarginsOrderListRequest
    {
        private int? _pageindex { get; set; }
        public int? pageindex
        {
            get { return _pageindex > 0 ? _pageindex : 1; }
            set { _pageindex = value; }
        }


        private int? _pagesize { get; set; }
        public int? pagesize
        {
            get { return _pagesize > 0 ? _pagesize : GlobalConfig.PageSize; }
            set { _pagesize = value; }
        }

        ///// <summary>
        ///// 页码
        ///// </summary>
        //[Display(Name = "页码")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int pageindex { get; set; }

        ///// <summary>
        ///// 页面含有多少条数据
        ///// </summary>
        //[Display(Name = "页面含有多少条数据")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int pagesize { get; set; }

        /// <summary>
        /// 二级商户号
        /// </summary>
        //[Display(Name = "二级商户号")]
        //[MaxLength(20, ErrorMessage = "{0}不能多于20位")]
        //public string commercialnoII { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        //[Display(Name = "商户订单号")]
        //public string commercialorderno { get; set; }

        /// <summary>
        /// 银行订单号
        /// </summary>
        [Display(Name = "银行订单号")]
        public string bankorderno { get; set; }

        /// <summary>
        /// 活动号
        /// </summary>
        //[Display(Name = "活动号")]
        //[MaxLength(20, ErrorMessage = "{0}不能多于20位")]
        //public string activityno { get; set; }

        /// <summary>
        /// 产品号
        /// </summary>
        //[Display(Name = "产品号")]
        //[MaxLength(12, ErrorMessage = "{0}不能多于12位")]
        //public string productcode { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        public string cardnumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [MaxLength(50, ErrorMessage = "{0}不能多于50位")]
        public string username { get; set; }

        /// <summary>
        /// 冻结时间起(格式：2018-06-06 )
        /// </summary>
        [Display(Name = "冻结时间起")]
        public string freezestarttime { get; set; }

        /// <summary>
        /// 冻结时间止(格式：2018-06-06 )
        /// </summary>
        [Display(Name = "冻结时间止")]
        public string freezetendtime { get; set; }
    }
}

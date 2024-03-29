﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryOrderPaidListRequst:BaseRequest
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Display(Name = "员工ID")]
        public long? employeeid { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        public string projectname { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Display(Name = "订单编号")]
        public string ordernumber { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Display(Name = "用户姓名")]
        public string username { get; set; }


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
    }
}

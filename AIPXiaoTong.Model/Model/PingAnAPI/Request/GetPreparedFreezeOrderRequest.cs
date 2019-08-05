﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class GetPreparedFreezeOrderRequest :BaseRequest
    {
        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long projectid { get; set; }

        /// <summary>
        /// 操作人员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "员工ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long employeeid { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        //[Display(Name = "交易金额")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal transactionamount { get; set; }

        /// <summary>
        /// 客户身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string cardnumber { get; set; }

        /// <summary>
        ///  业务描述
        /// </summary>
        [Display(Name = "业务描述")]
        [MaxLength(200, ErrorMessage = "{0}字数不能多于200位")]
        public string remark { get; set; }

        /// <summary>
        /// 直通卡号(16位直通卡号)
        /// </summary>
        //[Display(Name = "直通卡号")]
        //[MaxLength(19, ErrorMessage = "{0}不能多于19位")]
        //public string clientno { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        //[Display(Name = "业务名称")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //[MaxLength(60, ErrorMessage = "{0}不能多于60位")]
        //public string businessname { get; set; }

        /// <summary>
        /// 确认有效天数
        /// </summary>
        //[Display(Name = "确认有效天数")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int ordervalidday { get; set; }

        /// <summary>
        /// 止付天数
        /// </summary>
        //[Display(Name = "止付天数")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int freezetimelimit { get; set; }

        /// <summary>
        /// 止付产品(付产品 1-活期止付2-定期止付)
        /// </summary>
        //[Display(Name = "止付产品")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int freezeproduct { get; set; }

        /// <summary>
        /// 解止付方式(到期是否自动解止付  00-是 01-否)
        /// </summary>
        //[Display(Name = "解止付方式")]
        //[MaxLength(2, ErrorMessage = "{0}不能多于2位")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string autofreeze { get; set; }
    }
}
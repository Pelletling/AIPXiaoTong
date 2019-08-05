﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class PingAnOrderPaid : BaseEntity
    {
        /// <summary>
        /// 认缴订单ID（主订单）
        /// </summary>
        [Display(Name = "认缴订单ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long OrderPaidID { get; set; }

        /// <summary>
        /// 合作方渠道ID
        /// </summary>
        [Display(Name = "合作方渠道ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Channel { get; set; }

        /// <summary>
        /// 银行订单号
        /// </summary>
        [Display(Name = "银行订单号")]
        //[MaxLength(20, ErrorMessage = "{0}不能多于20位")]
        public string BankOrderNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        //[Display(Name = "商户订单号")]
        //[MaxLength(20, ErrorMessage = "{0}不能多于20位")]
        //public string CommercialOrderNo { get; set; }

        /// <summary>
        /// 直通卡号(16位直通卡号)
        /// </summary>
        [Display(Name = "直通卡号")]
        [MaxLength(19, ErrorMessage = "{0}不能多于19位")]
        public string ClientNo { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        [Display(Name = "业务名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(60, ErrorMessage = "{0}不能多于60位")]
        public string BusinessName { get; set; }

        /// <summary>
        /// 确认有效天数
        /// </summary>
        [Display(Name = "确认有效天数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OrderValidDay { get; set; }

        /// <summary>
        /// 止付金额
        /// </summary>
        //[Display(Name = "止付金额")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal FreezeAmt { get; set; }

        /// <summary>
        /// 止付天数
        /// </summary>
        [Display(Name = "止付天数")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int FreezeTimeLimit { get; set; }

        /// <summary>
        /// 止付产品(止付产品 1-活期止付2-定期止付)
        /// </summary>
        [Display(Name = "止付产品")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int FreezeProduct { get; set; }

        /// <summary>
        /// 业务描述
        /// </summary>
        //[Display(Name = "业务描述")]
        //[MaxLength(200, ErrorMessage = "{0}字数不能多于200位")]
        //public string Remark { get; set; }

        /// <summary>
        /// 解止付方式(到期是否自动解止付  00-是 01-否)
        /// </summary>
        [Display(Name = "解止付方式")]
        [MaxLength(2, ErrorMessage = "{0}不能多于2位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string AutoFreeze { get; set; }

        /// <summary>
        /// 接口码(001)
        /// </summary>
        [Display(Name = "接口码")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TransCode { get; set; }

        /// <summary>
        /// 免登地址
        /// </summary>
        //[Display(Name = "免登地址")]
        //public string AutoLoginUrl { get; set; }

        /// <summary>
        /// 冻结时间
        /// </summary>
        [Display(Name = "冻结时间")]
        public DateTime? FreezeSuccessTime { get; set; }

        /// <summary>
        /// 收银宝订单支付平台流水号
        /// </summary>
        [Display(Name = "收银宝流水号")]
        [MaxLength(50, ErrorMessage = "{0}不能多于50位")]
        public string POSBaoSerialNumber { get; set; }

        //-------------------------------------------------------------------
        public virtual OrderPaid OrderPaid { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusDesc { get { return ((PingAnOrderPaidStatusOption)Status).ToDescription(); } }

    }
}
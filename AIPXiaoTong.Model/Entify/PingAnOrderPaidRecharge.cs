﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class PingAnOrderPaidRecharge : BaseEntity
    {
        /// <summary>
        /// 平台流水号
        /// </summary>
        [Display(Name = "流水号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string SerialNumber { get; set; }

        [Display(Name = "订单ID")]
        public long? OrderPaidID { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        /// <summary>
        [Display(Name = "金额")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        [Display(Name = "流水号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于64位")]
        public string TransNumber { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        [Display(Name = "交易时间")]
        public DateTime? TransTime { get; set; }

        /// <summary>
        /// 交易卡号(账号)
        /// </summary>
        [Display(Name = "交易卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string BankCardNumber { get; set; }

        /// <summary>
        /// 账号名
        /// </summary>
        [Display(Name = "账号名")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string AccountName { get; set; }
        /// <summary>
        /// 响应码
        /// </summary>
        [Display(Name = "响应码")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// 响应说明
        /// </summary>
        [Display(Name = "响应说明")]
        public string ResponseMessage { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        public string IDNumber { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [Display(Name = "银行代码")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string BankCode { get; set; }

        /// <summary>
        /// 开户行名称
        /// </summary>
        [Display(Name = "开户行名称")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string BankName { get; set; }

        /// <summary>
        /// 账号类型(00银行卡，01存折，02信用卡。不填默认为银行卡00。存折不填写将失败)
        /// </summary>
        [Display(Name = "账号类型")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string AccountType { get; set; }

        /// <summary>
        /// 开户行所在省
        /// </summary>
        [Display(Name = "开户行所在省")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string Province { get; set; }

        /// <summary>
        /// 开户行所在市
        /// </summary>
        [Display(Name = "开户行所在市")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string City { get; set; }

        /// <summary>
        /// 账号属性(	0私人，1公司。不填时，默认为私人0。)
        /// </summary>
        [Display(Name = "账号属性")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string AccountProp { get; set; }

        /// <summary>
        /// 支付行号
        /// </summary>
        [Display(Name = "支付行号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string UnionBank { get; set; }


        //-------------------------------------------------------

        public virtual OrderPaid OrderPaid { get; set; }

        public string OutCardNo { get { return OrderPaid.Member?.AccountPingAn.OutCardNo; } }
        /// <summary>
        /// 支付状态
        /// </summary>
        public string StatusDesc { get { return ((PingAnOrderPaidRechargeStatusOption)Status).ToDescription(); } }
        /// <summary>
        /// 代付人姓名
        /// </summary>
        public string Name { get { return OrderPaid.Member?.Name; } }
        /// <summary>
        /// 代付人卡号
        /// </summary>
        public string Mobile { get { return OrderPaid.Member?.Mobile; } }
        /// <summary>
        /// 代付人身份证号
        /// </summary>
        public string RechargeIDNumber { get { return OrderPaid.Member?.IDNumber; } }
        /// <summary>
        /// 认缴订单号
        /// </summary>
        public string OrderNumber { get { return OrderPaid?.OrderNumber; } }

    }
}

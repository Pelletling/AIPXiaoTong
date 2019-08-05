﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OrderPaid : BaseEntity
    {
        [Display(Name = "商户ID")]
        public long? MerchantID { get; set; }

        /// <summary>
        /// 订单编号（也是平安预下单接口的“商户订单号”）
        /// </summary>
        /// <summary>
        [Display(Name = "订单编号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        /// <summary>
        [Display(Name = "设备编号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EquipmentSNNo { get; set; }

        /// <summary>
        /// 交易金额（也是平安预下单接口的“止付金额”）
        /// </summary>
        [Display(Name = "交易金额")]
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// 备注（也是平安预下单接口的“业务描述”）
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(50, ErrorMessage = "{0}不能多于50位")]
        public string Remark { get; set; }

        /// <summary>
        /// 注册会员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "注册会员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MemberID { get; set; }

        /// <summary>
        /// 操作人员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "员工ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long EmployeeID { get; set; }

        /// <summary>
        /// 项目ID（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "项目ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ProjectID { get; set; }

        /// <summary>
        /// 支付动作
        /// </summary>
        public int PayAction { get; set; }

        //-------------------------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public string ProjectName { get { return Project?.ProjectName; } }
        public string MerchantName { get { return Merchant?.Name; } }
        public int? MerchantAccountBank { get { return Merchant?.AccountBank; } }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusDesc { get { return ((OrderPaidStatusOption)Status).ToDescription(); } }


        /// <summary>
        /// 操作人员名字
        /// </summary>
        public string EmployeeName { get { return Employee?.Name; } }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get { return Member?.Name; } }

        /// <summary>
        /// 会员手机号码
        /// </summary>
        public string MemberMobile { get { return Member?.Mobile; } }

        /// <summary>
        /// 会员身份证号码
        /// </summary>
        public string MemberIDNumber { get { return Member?.IDNumber; } }

        //--------------------------------------------
        public virtual List<OrderPaidRecharge> OrderPaidRechargeList { get; set; }

        public OrderPaidRecharge OrderPaidRecharge { get { return OrderPaidRechargeList.FirstOrDefault(t => t.Status == OrderPaidRechargeStatusOption.Success.ToInt()); } }

        public string TransNumber { get { return OrderPaidRecharge?.TransNumber; } }

        public string BankCardNumber { get { return OrderPaidRecharge?.BankCardNumber; } }

        //--------------------------------------------
        public virtual List<OrderPaidFreeze> OrderPaidFreezeList { get; set; }

        public OrderPaidFreeze OrderPaidFreeze { get { return OrderPaidFreezeList.FirstOrDefault(t => t.Status == OrderPaidFreezeStatusOption.Success.ToInt()); } }

        public DateTime? FreezeDate { get { return OrderPaidFreeze?.TransTime; } }
        public string FreezeSerialNumber { get { return OrderPaidFreeze?.SerialNumber; } }

        //-------------------------------------------
        public virtual List<OrderPaidWithdraw> OrderPaidWithdrawList { get; set; }
        public OrderPaidWithdraw OrderPaidWithdraw { get { return OrderPaidWithdrawList.FirstOrDefault(t => t.Status == OrderPaidWithdrawStatusOption.Success.ToInt()); } }

        //--------------------------------------------
        public virtual List<OrderPaidUnFreeze> OrderPaidUnFreezeList { get; set; }
        public OrderPaidUnFreeze OrderPaidUnFreeze { get { return OrderPaidUnFreezeList.FirstOrDefault(t => t.Status == OrderPaidUnFreezeStatusOption.Success.ToInt()); } }

        //-------------------------------------------------------
        public virtual List<PingAnOrderPaid> PingAnOrderPaidList { get; set; }
        public PingAnOrderPaid PingAnOrderPaid { get { return PingAnOrderPaidList.FirstOrDefault(t => t.OrderPaidID == ID); } }

        //-----------------------------------------------
        public virtual List<PingAnOrderPaidRecharge> PingAnOrderPaidRechargeList { get; set; }

        public PingAnOrderPaidRecharge PingAnOrderPaidRecharge { get { return PingAnOrderPaidRechargeList.FirstOrDefault(t => t.Status == PingAnOrderPaidRechargeStatusOption.SingleOntimePaySuccess.ToInt()); } }

        //------------------------------------------------
        public virtual List<PingAnOrderPaidUnFreeze> PingAnOrderPaidUnFreezeList { get; set; }
        public PingAnOrderPaidUnFreeze PingAnOrderPaidUnFreeze { get { return PingAnOrderPaidUnFreezeList.FirstOrDefault(t => t.Status == PingAnOrderPaidUnFreezeStatusOption.Success.ToInt()); } }
    }
}

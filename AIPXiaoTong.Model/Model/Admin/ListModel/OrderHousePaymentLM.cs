﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class OrderHousePaymentLM:BaseListModel
    {
        public string MerchantName { get; set; }
        public long MerchantID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        /// <summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        public long ProjectID { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        /// <summary>
        public string EquipmentSNNo { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        /// <summary>
        public string EmployeeName { get; set; }
        public long EmployeeID { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string MemberName { get; set; }
        public long MemberID { get; set; }

        public string BankCardNumber { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string MemberMobile { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string MemberIDNumber { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public string PaymentStatusDesc { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public string PaymentTypeDesc { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusDesc { get; set; }

        public int PaymentStatus { get; set; }
        public int PaymentType { get; set; }

        public string Remark { get; set; }
    }
}
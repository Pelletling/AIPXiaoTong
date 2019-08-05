﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OrderBooking : BaseEntity
    {
        [Display(Name = "商户ID")]
        public long? MerchantID { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Display(Name = "订单编号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 项目名称(对应外键)
        /// </summary>
        [Display(Name = "项目ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long ProjectID { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        /// <summary>
        [Display(Name = "设备编号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EquipmentSNNo { get; set; }

        /// <summary>
        /// 操作人员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "员工ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long EmployeeID { get; set; }

        /// <summary>
        /// 注册会员（外键ID）
        /// </summary>
        /// <summary>
        [Display(Name = "注册会员ID")]
        public long? MemberID { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        [Display(Name = "预约时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(50, ErrorMessage = "{0}不能多于50位")]
        public string Remark { get; set; }

        /// <summary>
        /// 预约人名字
        /// </summary>
        [Display(Name = "预约人名字")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string OrderName { get; set; }

        /// <summary>
        /// 预约人手机号
        /// </summary>
        [Display(Name = "预约人名字")]
        [MaxLength(11, ErrorMessage = "{0}不能多于11位")]
        [MinLength(11, ErrorMessage = "{0}不能少于11位")]
        public string OrderMobile { get; set; }



        //-------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }

        public string MerchantName { get { return Merchant?.Name; } }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get { return Project?.ProjectName; } }

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
    }
}

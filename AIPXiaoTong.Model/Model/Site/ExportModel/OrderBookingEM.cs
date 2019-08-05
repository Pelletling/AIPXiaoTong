using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class OrderBookingEM : BaseExportModel
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        /// <summary>
        [Display(Name = "订单编号")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 商户信息
        /// </summary>
        [Display(Name = "商户信息")]
        public string MerchantName { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Display(Name = "客户姓名")]
        public string MemberName { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        public string MemberIDNumber { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        public string MemberMobile { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        /// <summary>
        [Display(Name = "设备编号")]
        public string EquipmentSNNo { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        /// <summary>
        [Display(Name = "操作员")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        [Display(Name = "预约时间")]
        public DateTime? OrderTime { get; set; }

        //-------------------------------------------------------------------------------
        public virtual Project Project { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}

using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OrderPaidUnFreeze : BaseEntity
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
        /// 解冻金额
        /// </summary>
        [Display(Name = "解冻金额")]
        public decimal Amount { get; set; }
                

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
        /// 交易时间
        /// </summary>
        [Display(Name = "交易时间")]
        public DateTime? TransTime { get; set; }
        //-------------------------------------------------------

        public virtual OrderPaid OrderPaid { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public string StatusDesc { get { return ((OrderPaidUnFreezeStatusOption)Status).ToDescription(); } }
    }
}

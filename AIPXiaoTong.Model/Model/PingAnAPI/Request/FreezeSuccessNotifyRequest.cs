using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class FreezeSuccessNotifyRequest
    {
        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name = "签名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string signature { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Display(Name = "订单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string orderNo { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        [Display(Name = "冻结金额")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double amount { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Display(Name = "商户号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string commercialNo { get; set; }

        /// <summary>
        /// 冻结结果
        /// </summary>
        [Display(Name = "冻结结果")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string result { get; set; }

        /// <summary>
        /// 交易时间(平安银行交易时间：’2018-01-02 23:59:59’)
        /// </summary>
        [Display(Name = "交易时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string tradeTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string remark { get; set; }
    }
}

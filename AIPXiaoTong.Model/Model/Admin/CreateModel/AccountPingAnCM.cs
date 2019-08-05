using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class AccountPingAnCM : BaseCreateModel
    {
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
        /// 账号属性
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class AccountPingAn : BaseEntity
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        [Display(Name = "会员ID")]
        [Index(IsUnique = true)]
        public long MemberID { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        public string Mobile { get; set; }


        /// <summary>
        /// 身份证-过期日期
        /// </summary>
        [Display(Name = "身份证-过期日期")]
        public DateTime? IdExpiredDate { get; set; }

        /// <summary>
        /// 身份证照片(正面)
        /// </summary>
        [Display(Name = "身份证照片（正面）")]
        [MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        public string IDImageFront { get; set; }

        /// <summary>
        /// 身份证照片(反面)
        /// </summary>
        [Display(Name = "身份证照片(反面)")]
        [MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        public string IDImageOpposite { get; set; }

        /// <summary>
        /// 银行卡号（平安二类户卡号）
        /// </summary>
        [Display(Name = "银行卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string BankCardNumber { get; set; }

        /// <summary>
        /// 转入银行卡号(代付出金卡)
        /// </summary>
        [Display(Name = "转出银行卡号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string OutCardNo { get; set; }

        /// <summary>
        /// 转账人姓名
        /// </summary>
        [Display(Name = "转账人姓名")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string CnName { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 冻结余额
        /// </summary>
        public decimal FreezeBalance { get; set; }

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

        //------------------------------------------------------------
        public virtual Member Member { get; set; }
    }
}

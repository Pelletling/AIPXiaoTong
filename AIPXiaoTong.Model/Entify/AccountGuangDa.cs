using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AIPXiaoTong.Model
{
    public class AccountGuangDa : BaseEntity
    {
        public AccountGuangDa()
        {

        }

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
        /// 联系地址(8-30个汉字)
        /// </summary>
        [Display(Name = "联系地址")]
        [MaxLength(128, ErrorMessage = "{0}不能多于128位")]
        public string Address { get; set; }

        /// <summary>
        /// 客户英文名称
        /// </summary>
        [Display(Name = "客户英文名")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string EnName { get; set; }

        /// <summary>
        /// 身份证-过期日期
        /// </summary>
        [Display(Name = "身份证-过期日期")]
        public DateTime? IdExpiredDate { get; set; }


        /// <summary>
        /// 邮编
        /// </summary>
        [Display(Name = "邮编")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "{0}必须是6位")]
        public string PostCode { get; set; }

        /// <summary>
        /// 客户所在省份代号（机构号由光大线下提供）
        /// </summary>
        [Display(Name = "客户所在省份")]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 客户所在城市代号（机构号由光大线下提供）
        /// </summary>
        [Display(Name = "客户所在城市")]
        public string CityCode { get; set; }


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
        /// 开户步骤
        /// </summary>
        public int IsCreateAccount { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 冻结余额
        /// </summary>
        public decimal FreezeBalance { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { get; set; }

        /// <summary>
        /// 发证机关地区代码
        /// </summary>
        public long? GuangDaAreaID { get; set; }

        /// <summary>
        /// 合作伙伴交易请求流水号（唯一标识）
        /// </summary>
        [Display(Name = "合作伙伴交易请求流水号（唯一标识）")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string CoPatrnerJnlNo { get; set; }

        /// <summary>
        /// 交易所属日期
        /// </summary>
        public DateTime? BookDate { get; set; }


        /// <summary>
        /// 电子帐户
        /// </summary>
        [Display(Name = "电子帐户")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string EAcNo { get; set; }


        //---------------------------------------------------------------------------

        public virtual Member Member { get; set; }
        
        public virtual AreaGuangDa Province { get; set; }
        public virtual AreaGuangDa City { get; set; }

        public virtual GuangDaArea GuangDaArea { get; set; }

        //---------------------------------------------------------------------------

        public string IsCreateAccountDesc { get { return ((AccountStatus)IsCreateAccount).ToDescription(); } }

        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceName { get { return Province?.Name; } }

        /// <summary>
        /// 市
        /// </summary>
        public string CityName { get { return City?.Name; } }


    }
}

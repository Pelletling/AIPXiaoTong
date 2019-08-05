using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class GetAutoLoginPathRequst
    {
        /// <summary>
        /// 设备SN号
        /// </summary>
        [Display(Name = "设备SN号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string equipmentsnno { get; set; }

        /// <summary>
        /// 证件类型(1身份证 0其它 2护照 3军官证或士兵证 4 少儿证 L 户口本)
        /// </summary>
        //[Display(Name = "证件类型")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string clientidtype { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string clientidno { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Display(Name = "银行卡号")]
        [MaxLength(19, ErrorMessage = "{0}不能多于19位")]
        public string accno { get; set; }

        /// <summary>
        /// 银行订单号
        /// </summary>
        [Display(Name = "银行订单号")]
        //[MaxLength(19, ErrorMessage = "{0}不能多于19位")]
        public string bankorderno { get; set; }

        /// <summary>
        /// 商户Id(平安提供）
        /// </summary>
        //[Display(Name = "商户Id")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string mchId { get; set; }

        /// <summary>
        /// 推荐人代码
        /// </summary>
        //[Display(Name = "推荐人代码")]
        //public string umCode { get; set; }

        /// <summary>
        /// 重定向地址--验证通过后跳转银行页面链接地址（进入默认银行插件页面时可为空）
        /// </summary>
        //[Display(Name = "重定向地址")]
        //public string redirectUrl { get; set; }

        /// <summary>
        /// 商户自定义参数
        /// </summary>
        //[Display(Name = "商户自定义参数")]
        //public string state { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        //[Display(Name = "姓名")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string clientName { get; set; }

        /// <summary>
        /// 会员手机号
        /// </summary>
        //[Display(Name = "会员手机号")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string telNo { get; set; }



        /// <summary>
        /// 合作方会员ID(合作方APP会员登录唯一ID)
        /// </summary>
        //[Display(Name = "合作方会员ID")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string thirdMid { get; set; }

        /// <summary>
        /// 时间戳（正负5分钟内有效）
        /// </summary>
        //[Display(Name = "时间戳")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string timestamp { get; set; }
    }
}

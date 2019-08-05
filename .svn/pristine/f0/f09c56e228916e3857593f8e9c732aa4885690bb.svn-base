using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class MemberCM : BaseCreateModel
    {
        /// <summary>
        /// 会员姓名
        /// </summary>
        [Display(Name = "会员姓名")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        public string IDNumber { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}必须是11位")]
        public string Mobile { get; set; }

        /// <summary>
        /// 接入方客户标识号（在同UserId下，同一套客户信息只有一个标识号）
        /// </summary>
        [Display(Name = "客户唯一标识")]
        [MaxLength(36, ErrorMessage = "{0}不能多于30位")]
        public string ClientId { get; set; }


        //---------------------------------------------------------------------------
        public virtual AccountPingAn AccountPingAn { get; set; }


    }
}

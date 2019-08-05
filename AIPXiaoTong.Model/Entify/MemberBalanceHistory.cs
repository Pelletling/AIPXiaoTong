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
    public class MemberBalanceHistory : BaseEntity
    {
        public MemberBalanceHistory()
        {

            
        }
        
        /// <summary>
        /// 会员ID
        /// </summary>
        [Display(Name = "会员ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MemberID { get; set; }

        /// <summary>
        /// 变动金额
        /// </summary>
        public decimal ChangeAmount { get; set; }

        /// <summary>
        /// 当前余额
        /// </summary>
        public decimal Balance { get; set; }
                
        /// <summary>
        /// 交易类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        public string Remark { get; set; }

        public int AccountBank{ get; set; }

        //---------------------------------------------------------------------------

        public virtual Member Member { get; set; }
    }
}

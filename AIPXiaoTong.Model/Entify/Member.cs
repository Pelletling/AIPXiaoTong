﻿using Framework.Common;
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
    public class Member : BaseEntity
    {
        public Member()
        {
            OrderPaidList = new List<OrderPaid>();
        }


        /// <summary>
        /// 会员姓名
        /// </summary>
        [Display(Name = "会员姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(16, ErrorMessage = "{0}不能多于16位")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0}必须是18位")]
        [Index(IsUnique = true)]
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
        [Required(ErrorMessage = "{0}不能为空")]
        public string ClientId { get; set; }


        //---------------------------------------------------------------------------
        public virtual IList<MerchantMember> MerchantMemberList { get; set; }

        public virtual List<AccountGuangDa> AccountGuangDaList { get; set; }

        public AccountGuangDa AccountGuangDa { get { return AccountGuangDaList.FirstOrDefault(); } }

        public virtual List<AccountPingAn> AccountPingAnList { get; set; }

        public AccountPingAn AccountPingAn { get { return AccountPingAnList.FirstOrDefault(); } }
        //-----------------------------------------------------------------------------
        public string GuangDaCreateAccountDesc { get { return ((AccountStatus)AccountGuangDa.Status).ToDescription(); } }
        public decimal? GuangDaBalance { get { return AccountGuangDa?.Balance; } }
        public decimal? PingAnBalance { get { return AccountPingAn?.Balance; } }
        public decimal? GuangDaFreezeBalance { get { return AccountGuangDa?.FreezeBalance; } }
        public decimal? PingAnFreezeBalance { get { return AccountPingAn?.FreezeBalance; } }

        public virtual IList<OrderPaid> OrderPaidList { get; set; }

        public virtual List<BankCard> BankCardList { get; set; }
        public BankCard BankCard
        {
            get
            {
                var status = BankCardStatus.IsVerified.ToInt();

                return BankCardList.FirstOrDefault(t => t.Status == status);
            }
        }
        public string BankCardNumber { get { return BankCard?.BankCardNumber; } }

        //---------------------------------光大 详情-----------------------------------------------
        public string Address { get { return AccountGuangDa?.Address; } }
        public string EnName { get { return AccountGuangDa?.EnName; } }
        public DateTime? IdExpiredDate { get { return AccountGuangDa?.IdExpiredDate; } }
        public string PostCode { get { return AccountGuangDa?.PostCode; } }
        public string ProvinceCode { get { return AccountGuangDa?.ProvinceCode; } }
        public string CityCode { get { return AccountGuangDa?.CityCode; } }
        public string IDImageFront { get { return AccountGuangDa?.IDImageFront; } }
        public string IDImageOpposite { get { return AccountGuangDa?.IDImageOpposite; } }
        public string ProvinceName { get { return AccountGuangDa?.ProvinceName; } }
        public string CityName { get { return AccountGuangDa?.CityName; } }
        public decimal? Balance { get { return AccountGuangDa?.Balance; } }
        public decimal? FreezeBalance { get { return AccountGuangDa?.FreezeBalance; } }

        //---------------------------------平安 详情-----------------------------------------
        public DateTime? PingAnIdExpiredDate { get { return AccountPingAn?.IdExpiredDate; } }
        public string PingAnIDImageFront { get { return AccountPingAn?.IDImageFront; } }
        public string PingAnIDImageOpposite { get { return AccountPingAn?.IDImageOpposite; } }
        public string PingAnBankCardNumber { get { return AccountPingAn?.BankCardNumber; } }
        public string PingAnOutCardNo { get { return AccountPingAn?.OutCardNo; } }
    }
}
﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class Equipment:BaseEntity
    {
        [Display(Name = "商户ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long MerchantID { get; set; }

        /// <summary>
        /// 设备SN编号
        /// </summary>
        [Display(Name = "设备SN编号")]
        [MaxLength(32, ErrorMessage = "{0}不能多于32位")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Index(IsUnique = true)]
        public string EquipmentSNNo { get; set; }

        //-------------------------------------------------------------
        public virtual Merchant Merchant { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get { return Merchant?.Name; } }

        public string StatusDesc { get { return ((EquipmentStatus)this.Status).ToDescription(); } }

    }
}

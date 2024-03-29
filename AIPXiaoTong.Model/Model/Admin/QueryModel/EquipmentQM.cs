﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class EquipmentQM : BaseQueryModel
    {
        public long? MerchantID { get; set; }

        /// <summary>
        /// 设备SN编号
        /// </summary>
        public string EquipmentSNNo { get; set; }
        public string MerchantName { get; set; }
    }
}

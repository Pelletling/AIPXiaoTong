﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class HouseTypeShowQM : BaseQueryModel
    {
        public long? ProjectID { get; set; }

        public string HouseTypeName { get; set; }
        public string ProjetName { get; set; }
        public long? MerchantID { get; set; }
    }
}
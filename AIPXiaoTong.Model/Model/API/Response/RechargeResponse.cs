﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class RechargeResponse : BaseResponse
    {
        private string _ordernumber { get; set; }

        //---------------------------------------------------
        public string ordernumber { get { return !string.IsNullOrWhiteSpace(_ordernumber) ? _ordernumber : ""; } set { _ordernumber = value; } }
    }
}

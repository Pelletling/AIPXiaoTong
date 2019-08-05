﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
   public class EntityModel
    {
        public long ID { get; set; }

        public int Status { get; set; }
       
        public string CurrentStatus { get; set; }

        /// <summary>
        /// 自定义状态
        /// </summary>
        public string CustomStatus { get; set; }

        /// <summary>
        /// 商户合作银行
        /// </summary>
        public int MerchantAccountBank { get; set; }
        /// <summary>
        /// 账户所处银行
        /// </summary>
        public int AccountBank { get; set; }
    }
}
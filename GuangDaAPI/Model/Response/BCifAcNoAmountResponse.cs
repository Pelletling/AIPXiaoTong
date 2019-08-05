﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BCifAcNoAmountResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 账户余额（除去冻结的余额）
            /// </summary>
            [XmlElement("AcNoBlance")]
            public decimal AcNoBlance { get; set; }

            /// <summary>
            /// 可用余额(总余额)
            /// </summary>
            [XmlElement("AvailBlance")]
            public decimal AvailBlance { get; set; }

            /// <summary>
            /// 币种
            /// </summary>
            [XmlElement("Currency")]
            public string Currency { get; set; }
            
        }
    }
}
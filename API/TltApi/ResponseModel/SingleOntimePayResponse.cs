﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TltApi.Model
{
    [XmlRoot(ElementName = "AIPG")]
    public class SingleOntimePayResponse : BaseResponse
    {
        private List<string> WaitCodeList = new List<string> { "2000", "2001", "2003", "2005", "2007", "2008","1108","1000" }; 
        public SingleOntimePayResponse()
        {
            INFO = new Info();
            TRANSRET = new Transret();
        }


        [XmlElement(ElementName = "INFO")]
        public Info INFO { get; set; }

        [XmlElement(ElementName = "TRANSRET")]
        public Transret TRANSRET { get; set; }
        public bool IsSuccess
        {
            get
            {
                if ((INFO?.RET_CODE == "0000"|| INFO?.RET_CODE=="4000") && (TRANSRET?.RET_CODE == "0000" || TRANSRET?.RET_CODE=="4000"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsWait
        {
            get
            {
                if (WaitCodeList.Contains(INFO?.RET_CODE))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ResultMessage
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(TRANSRET.ERR_MSG))
                    return TRANSRET.ERR_MSG;
                else
                    return INFO.ERR_MSG;
            }
        }
        public string ResultCode
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(TRANSRET?.RET_CODE))
                    return TRANSRET.RET_CODE;
                else
                    return INFO.RET_CODE;
            }
        }

        public StatusOption Status { get { return this.GetStatus(); } }

        public class Info
        {
            public string TRX_CODE { get; set; }
            public string VERSION { get; set; }
            public string DATA_TYPE { get; set; }
            public string REQ_SN { get; set; }
            public string RET_CODE { get; set; }
            public string ERR_MSG { get; set; }
            public string SIGNED_MSG { get; set; }
        }

        public class Transret
        {
            public string RET_CODE { get; set; }
            public string ERR_MSG { get; set; }
            public string SETTLE_DAY { get; set; }
            public string MERCHANT_ID { get; set; }
        }
    }
}
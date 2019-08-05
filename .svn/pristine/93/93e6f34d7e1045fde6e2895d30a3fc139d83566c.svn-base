using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TltApi.Model
{
    [XmlRoot(ElementName = "AIPG")]
    public class QueryTltTradingResultResponse : BaseResponse
    {
        public QueryTltTradingResultResponse()
        {
            INFO = new Info();
            QTRANSRSP = new Qtransrsp();
        }

        [XmlElement(ElementName = "INFO")]
        public Info INFO { get; set; }

        [XmlElement(ElementName = "QTRANSRSP")]
        public Qtransrsp QTRANSRSP { get; set; }


        

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

        public class Qtransrsp
        {
            [XmlElement(ElementName = "QTDETAIL")]
            public List<Qtdetail> QTDETAIL { get; set; }

            public Qtdetail FirstQtdetail { get { return QTDETAIL.FirstOrDefault(); } }
            public class Qtdetail
            {
                public string BATCHID { get; set; }
                public string SN { get; set; }
                public string TRXDIR { get; set; }
                public string SETTDAY { get; set; }
                public string FINTIME { get; set; }
                public string SUBMITTIME { get; set; }
                public string ACCOUNT_NO { get; set; }
                public string ACCOUNT_NAME { get; set; }
                public string AMOUNT { get; set; }
                public string CUST_USERID { get; set; }
                public string REMARK { get; set; }
                public string SUMMARY { get; set; }
                public string RET_CODE { get; set; }
                public string ERR_MSG { get; set; }

            }
        }

    }
}

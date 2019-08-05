using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TltApi.Model
{
    [XmlRoot(ElementName = "AIPG")]
    public class AccountVerifyResponse : BaseResponse
    {
        public AccountVerifyResponse()
        {
            INFO = new Info();
            VALIDRET = new Validret();
        }


        [XmlElement(ElementName = "INFO")]
        public Info INFO { get; set; }

        [XmlElement(ElementName = "VALIDRET")]
        public Validret VALIDRET { get; set; }

        public bool IsSuccess
        {
            get
            {
                if (INFO?.RET_CODE == "0000" && VALIDRET?.RET_CODE == "0000")
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
                if (!string.IsNullOrWhiteSpace(VALIDRET.ERR_MSG))
                    return VALIDRET.ERR_MSG;
                else
                    return INFO.ERR_MSG;
            }
        }
        public string ResultCode
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(VALIDRET?.RET_CODE))
                    return VALIDRET.RET_CODE;
                else
                    return INFO.RET_CODE;
            }
        }

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

        public class Validret
        {
            public string RET_CODE { get; set; }
            public string ERR_MSG { get; set; }
        }
    }


}

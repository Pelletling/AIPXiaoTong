using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BFinFundServiceReqResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 文件名
            /// </summary>
            [XmlElement("FileName")]
            public string FileName { get; set; }

            /// <summary>
            /// 对账文件日期（平台不会去商户服务器上建立日期路径）
            /// </summary>
            [XmlElement("FilePath")]
            public string FilePath { get; set; }

            /// <summary>
            /// 总记录数
            /// </summary>
            [XmlElement("TotNum")]
            public string TotNum { get; set; }

            /// <summary>
            /// 文件内容签名信息
            /// </summary>
            [XmlElement("Sign")]
            public string Sign { get; set; }
        }
    }
}

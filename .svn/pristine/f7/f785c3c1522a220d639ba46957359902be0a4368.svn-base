using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class UploadIdCardImageResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 身份证上传结果 S-成功 F-失败
            /// </summary>
            [XmlElement("UploadResult")]
            public string UploadResult { get; set; }
        }
    }
}

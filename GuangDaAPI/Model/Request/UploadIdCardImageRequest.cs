using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class UploadIdCardImageRequest : IBaseRequest<UploadIdCardImageResponse>
    {
        /// <summary>
        /// 身份证上传
        /// </summary>
        public UploadIdCardImageRequest()
        {
            Head = new HEAD();
            Body = new BODY();
        }

        [XmlIgnore]
        public string Method { get { return "UploadIdCardImage"; } }
        public string Action { get { return "images.do"; } }
        public Dictionary<string, string> GetBody()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("IdCardFront", Body.IdCardFront);
            dic.Add("IdCardBehind", Body.IdCardBehind);
            //dic.Add("IdCardFront", System.Web.HttpUtility.UrlEncode(Body.IdCardFront));
            //dic.Add("IdCardBehind", System.Web.HttpUtility.UrlEncode(Body.IdCardBehind));
            dic.Add("CifClientId", Body.CifClientId);

            return dic;
        }

        public string Sort(string signContent)
        {
            return signContent;
        }


        [XmlElement("Head")]
        public HEAD Head { get; set; }

        [XmlElement("Body")]
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 身份证正面照片信息
            /// </summary>
            [XmlElement("IdCardFront")]
            public string IdCardFront { get; set; }

            /// <summary>
            /// 身份证背面照片信息
            /// </summary>
            [XmlElement("IdCardBehind")]
            public string IdCardBehind { get; set; }

            /// <summary>
            /// 接入方客户标志号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }
        }
    }
}

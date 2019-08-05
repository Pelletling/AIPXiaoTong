using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    public class HEAD
    {
        /// <summary>
        /// 交易请求流水号
        /// </summary>
        [XmlElement("ReqJnlNo")]
        public string ReqJnlNo { get; set; }

        /// <summary>
        /// 交易请求时间
        /// </summary>
        [XmlElement("ReqTime")]
        public string ReqTime { get; set; }

        /// <summary>
        /// 认证识别号
        /// </summary>
        [XmlElement("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// 请求服务
        /// </summary>
        [XmlElement("ReqId")]
        public string ReqId { get; set; }

        /// <summary>
        /// 签名数据
        /// </summary>
        [XmlElement("Sign")]
        public string Sign { get; set; }
    }
}

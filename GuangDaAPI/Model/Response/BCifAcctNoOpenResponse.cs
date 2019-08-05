using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuangDaAPI.Model
{
    [XmlRoot("Message")]
    public class BCifAcctNoOpenResponse : BaseResponse
    {
        public BODY Body { get; set; }

        public class BODY
        {
            /// <summary>
            /// 接入方客户标识号
            /// </summary>
            [XmlElement("CifClientId")]
            public string CifClientId { get; set; }

            /// <summary>
            /// 客户电子账号
            /// </summary>
            [XmlElement("EAcNo")]
            public string EAcNo { get; set; }

            /// <summary>
            /// 手机号
            /// </summary>
            [XmlElement("CifPhoneCode")]
            public string CifPhoneCode { get; set; }

            /// <summary>
            /// 客户所在省份代号
            /// </summary>
            [XmlElement("ProvinceCode")]
            public string ProvinceCode { get; set; }

            /// <summary>
            /// 客户所在城市代号
            /// </summary>
            [XmlElement("CityCode")]
            public string CityCode { get; set; }

            /// <summary>
            /// II、III类户标志，（0-II类账户，1-III类账户）
            /// </summary>
            [XmlElement("Reserve1")]
            public string Reserve1 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve2")]
            public string Reserve2 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve3")]
            public string Reserve3 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve4")]
            public string Reserve4 { get; set; }

            /// <summary>
            /// 备用字段
            /// </summary>
            [XmlElement("Reserve5")]
            public string Reserve5 { get; set; }
        }
    }
}
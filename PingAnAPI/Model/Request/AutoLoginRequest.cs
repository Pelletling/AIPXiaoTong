﻿using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class AutoLoginRequest
    {
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("mchId", mchId ?? "");
            dic.Add("umCode", umCode ?? "");
            dic.Add("redirectUrl", redirectUrl ?? "");
            dic.Add("state", state ?? "");
            dic.Add("clientIdType", clientIdType);
            dic.Add("clientIdNo", clientIdNo);
            dic.Add("clientName", clientName);
            dic.Add("telNo", telNo);
            dic.Add("accNo", accNo);
            dic.Add("thirdMid", thirdMid);
            dic.Add("timestamp", timestamp);

            return dic;
        }

        /// <summary>
        /// 商户Id
        /// </summary>
        public string mchId { get; set; }

        /// <summary>
        /// 推荐人代码
        /// </summary>
        public string umCode { get; set; }

        /// <summary>
        /// 重定向地址
        /// </summary>
        public string redirectUrl { get; set; }

        /// <summary>
        /// 商户自定义参数
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 证件类型(1身份证 0其它 2护照 3军官证或士兵证 4 少儿证 L 户口本)
        /// </summary>
        public string clientIdType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string clientIdNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string clientName { get; set; }

        /// <summary>
        /// 会员手机号
        /// </summary>
        public string telNo { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string accNo { get; set; }

        /// <summary>
        /// 合作方会员ID(合作方APP会员登录唯一ID)
        /// </summary>
        public string thirdMid { get; set; }

        /// <summary>
        /// 时间戳（正负5分钟内有效）
        /// </summary>
        public string timestamp { get; set; }

    }
}

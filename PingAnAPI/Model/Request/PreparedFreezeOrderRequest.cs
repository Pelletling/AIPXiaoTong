using PingAnAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingAnAPI.Model
{
    public class PreparedFreezeOrderRequest : IBaseRequest<PreparedFreezeOrderResponse>
    {
        public string GetApiName()
        {
            return "bron_bbc_margins.preparedFreezeOrderInfo";
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("channel", channel);
            dic.Add("commercialOrderNo", commercialOrderNo);
            dic.Add("userName", userName);
            dic.Add("cardNumber", cardNumber);
            dic.Add("mobile", mobile);
            dic.Add("clientNo", clientNo);
            dic.Add("businessName", businessName);
            dic.Add("orderValidDay", orderValidDay.ToString());
            dic.Add("freezeAmt", freezeAmt.ToString());
            dic.Add("freezeTimeLimit", freezeTimeLimit.ToString());
            dic.Add("freezeProduct", freezeProduct.ToString());
            dic.Add("remark", remark);
            dic.Add("autoFreeze", autoFreeze);
            dic.Add("transCode", transCode);

            return dic;
        }

        /// <summary>
        /// 合作方渠道ID
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string commercialOrderNo { get; set; }

        /// <summary>
        ///客户姓名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 客户身份证
        /// </summary>
        public string cardNumber { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 直通卡号
        /// </summary>
        public string clientNo { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        public string businessName { get; set; }

        /// <summary>
        /// 确认有效天数
        /// </summary>
        public int orderValidDay { get; set; }

        /// <summary>
        /// 止付金额
        /// </summary>
        public double freezeAmt { get; set; }

        /// <summary>
        /// 止付天数
        /// </summary>
        public int freezeTimeLimit { get; set; }

        /// <summary>
        /// 止付产品
        /// </summary>
        public int freezeProduct { get; set; }

        /// <summary>
        /// 业务描述
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 解止付方式
        /// </summary>
        public string autoFreeze { get; set; }

        /// <summary>
        /// 接口码
        /// </summary>
        public string transCode { get; set; }
    }
}

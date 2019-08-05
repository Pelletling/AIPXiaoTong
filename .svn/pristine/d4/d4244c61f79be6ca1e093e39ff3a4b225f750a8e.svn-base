using AIPXiaoTong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TltApi;
using TltApi.Model;

namespace AIPXiaoTong.IService
{
    public interface ITltService
    {
        bool isReady();
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="url"></param>
        /// <param name="merchantId"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="privateKeyPassword"></param>
        void Init(string url, string merchantId, string userName, string userPassword, string privateKeyPassword);
        AccountVerifyResponse AccountVerify4(string Name, string IDNumber, string BarkNumber, string Mobile);
        SingleOntimePayResponse SingleOntimePay(OrderPaid orderPaid, PingAnOrderPaidRecharge pingAnOrderPaidRecharge);
        QueryTltTradingResultResponse QueryTltTradingResult(string REQ_SN, string QUERY_SN, string TRX_CODE);
    }
}

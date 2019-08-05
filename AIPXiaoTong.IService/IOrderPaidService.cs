﻿using AIPXiaoTong.Model;
using AIPXiaoTong.Model.API;
using AIPXiaoTong.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TltApi.Model;
using VSP.Pay.ResponseModel;

namespace AIPXiaoTong.IService
{
    public interface IOrderPaidService : IBusinessService<OrderPaid>
    {
        List<OrderPaidEM> Export(OrderPaidQM model = null);

        //void RechargeSuccess(OrderPaidRecharge orderPaidRecharge, string TransNumber, DateTime TransTime);
        //void RechargeFail(OrderPaidRecharge orderPaidRecharge);

        //void FreezeSuccess(OrderPaidFreeze orderPaidFreeze, decimal balance);

        //void UnFreezeSuccess(OrderPaidUnFreeze orderPaidUnFreeze);

        //void WithdrawSuccess(OrderPaidWithdraw orderPaidWithdraw);
        //void WithdrawFail(OrderPaidWithdraw orderPaidWithdraw);

        void SyncStatus(OrderPaid orderPaid);
        void PingAnSyncStatus(OrderPaid orderPaid);
        void RechargeAndFreeze(OrderPaid orderPaid);
        void Freeze(OrderPaid orderPaid);
        void Recharge(OrderPaid orderPaid);
        QueryTltTradingResultResponse QuerySingleOntimePayDetail(PingAnOrderPaidRecharge pingAnOrderPaidRecharge);
        void PingAnTltSingleOntimePay(OrderPaid orderPaid);
        void UnFreezeAndWithdraw(OrderPaid orderPaid);
        void UnFreezePingAnMargins(OrderPaid orderPaid);
        void PingAnFreeze(PingAnOrderPaid pingAnOrderPaid, string tradeTime);
        string UpdateAutoLoginUrl(OrderPaid orderPaid);
        void VspOrderHandle(POSOrderQueryResponse posOrderQueryResponse, OrderPaid orderPaid);
    }
}

using AIPXiaoTong.Model;
using GuangDaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IGuangDaAPIService
    {
        AuthenticationToOpenAccountResponse CreateAccount(Member member, BankCard bankCard);

        UploadIdCardImageResponse UploadIdCardImage(Member member);

        BTrsInResponse Recharge(OrderPaidRecharge orderPaidRecharge);

        CurrentFundFreezeResponse Freeze(OrderPaidFreeze orderPaidRecharge);

        UnfrozenFixedDepositResponse Unfreeze(OrderPaidUnFreeze orderPaidUnFreeze);

        BaseResponse Withdraw(OrderPaidWithdraw orderPaidWithdraw);

        BTrsVeriAmountResponse BTrsVeriAmount(string number, DateTime date);

        AuthenticationToOpenAccountCheckResponse CreateAccountCheck(Member member);

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        BCifAcNoAmountResponse BCifAcNoAmount(string clientId);

        /// <summary>
        /// 对账
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        BFinFundServiceReqResponse BFinFundServiceReq(DateTime? date);
            
    }
}

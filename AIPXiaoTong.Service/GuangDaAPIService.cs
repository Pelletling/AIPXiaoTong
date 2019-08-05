using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Common;
using GuangDaAPI;
using GuangDaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class GuangDaAPIService : IGuangDaAPIService
    {

        private GuangDaExec guangDaExec;

        string userid = GlobalConfig.WebConfig.GuangDa_UserID;
        string pwd = GlobalConfig.WebConfig.GuangDa_PWD;

        public GuangDaAPIService()
        {
            guangDaExec = new GuangDaExec(userid, AppDomain.CurrentDomain.BaseDirectory + userid + ".pfx", pwd, GlobalConfig.WebConfig.IsDebug);
        }

        ///// <summary>
        ///// 2.36.	电子账户开户及支付签约（监管）
        ///// </summary>
        ///// <param name="member"></param>
        ///// <param name="bankCard"></param>
        ///// <returns></returns>
        //public BCifAcctNoOpenResponse CreateAccount(Member member, BankCard bankCard)
        //{
        //    BCifAcctNoOpenRequest request = new BCifAcctNoOpenRequest();

        //    request.Head.ReqJnlNo = GuidHelper.GenUniqueId();
        //    request.Body.CifAddr = member.Address;
        //    request.Body.CifClientId = member.ClientId;
        //    request.Body.CifEnName = member.EnName;
        //    request.Body.CifIdExpiredDate = member.IdExpiredDate.ToDateTime().ToString("yyyyMMdd");
        //    request.Body.CifName = member.Name;
        //    request.Body.CifPhoneCode = member.Mobile;
        //    request.Body.CifPostCode = member.PostCode;
        //    request.Body.IdNo = member.IDNumber;
        //    request.Body.IdType = "P00";
        //    request.Body.OperateType = "0";
        //    request.Body.ProvinceCode = member.ProvinceCode;
        //    request.Body.CityCode = member.CityCode;
        //    request.Body.NetCheckFlag = "1";
        //    request.Body.BankCardPhoneCode = member.Mobile;
        //    request.Body.BankCardType = "1";
        //    request.Body.BankAcNo = bankCard.BankCardNumber;
        //    request.Body.BankName = bankCard.BankName;
        //    request.Body.SubBranchName = bankCard.BankName;
        //    request.Body.OpenChannel = "1";

        //    var result = guangDaExec.Exec(request) as BCifAcctNoOpenResponse;

        //    return result;
        //}

        /// <summary>
        /// 2.59.	鉴权开户接口
        /// </summary>
        /// <param name="member"></param>
        /// <param name="bankCard"></param>
        /// <returns></returns>
        public AuthenticationToOpenAccountResponse CreateAccount(Member member, BankCard bankCard)
        {
            AuthenticationToOpenAccountRequest request = new AuthenticationToOpenAccountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = member.AccountGuangDa.CoPatrnerJnlNo;
            request.Body.CifName = member.Name;
            request.Body.CifClientId = member.ClientId;
            request.Body.IdType = "P00";
            request.Body.IdNo = member.IDNumber;
            request.Body.BankCardPhoneCode = member.AccountGuangDa.Mobile;
            request.Body.CifPhoneCode = member.AccountGuangDa.Mobile;
            request.Body.CifIdExpiredDate = member.AccountGuangDa.IdExpiredDate.ToDateTime().ToString("yyyyMMdd");
            request.Body.CifAddr = member.AccountGuangDa.Address;
            request.Body.CifPostCode = member.AccountGuangDa.PostCode;
            request.Body.CifEnName = member.AccountGuangDa.EnName;
            request.Body.CifENFName = member.AccountGuangDa.EnName;
            request.Body.OperateType = "0";
            request.Body.NetCheckFlag = "1";
            request.Body.BankCardType = "1";
            request.Body.BankAcNo = bankCard.BankCardNumber;
            request.Body.BankName = bankCard.BankName;
            request.Body.SubBranchName = bankCard.BankName;
            request.Body.OpenChannel = "1";
            request.Body.BookDate = member.AccountGuangDa.BookDate.ToDateTime().ToString("yyyyMMdd");
            request.Body.Reserve1 = member.AccountGuangDa.Occupation;
            request.Body.Reserve2 = member.AccountGuangDa.GuangDaArea.Code;

            var result = guangDaExec.Exec(request) as AuthenticationToOpenAccountResponse;

            return result;
        }

        /// <summary>
        /// 开户查询
        /// </summary>
        /// <returns></returns>
        public AuthenticationToOpenAccountCheckResponse CreateAccountCheck(Member member)
        {
            AuthenticationToOpenAccountCheckRequest request = new AuthenticationToOpenAccountCheckRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = member.AccountGuangDa.CoPatrnerJnlNo;
            request.Body.CifClientId = member.ClientId;
            request.Body.BookDate = member.AccountGuangDa.BookDate.ToDateTime().ToString("yyyyMMdd");

            var result = guangDaExec.Exec(request) as AuthenticationToOpenAccountCheckResponse;

            return result;
        }

        /// <summary>
        /// 身份证上传
        /// </summary>
        /// <returns></returns>
        public UploadIdCardImageResponse UploadIdCardImage(Member member)
        {
            UploadIdCardImageRequest request = new UploadIdCardImageRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            var path = AppDomain.CurrentDomain.BaseDirectory;

            request.Body.IdCardFront = ImageHelper.ToBase64(path + member.AccountGuangDa.IDImageFront);
            request.Body.IdCardBehind = ImageHelper.ToBase64(path + member.AccountGuangDa.IDImageOpposite);
            request.Body.CifClientId = member.ClientId;

            var result = guangDaExec.Exec(request) as UploadIdCardImageResponse;

            return result;
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public BTrsInResponse Recharge(OrderPaidRecharge orderPaidRecharge)
        {
            BTrsInRequest request = new BTrsInRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = orderPaidRecharge.SerialNumber;
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.CifClientId = orderPaidRecharge.OrderPaid.Member.ClientId;
            request.Body.Amount = orderPaidRecharge.Amount.ToString();
            request.Body.TrsType = "0";
            request.Body.Currency = "CNY";
            request.Body.Remark = "资金转入";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";

            var result = guangDaExec.Exec(request) as BTrsInResponse;

            return result;
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <returns></returns>
        public CurrentFundFreezeResponse Freeze(OrderPaidFreeze orderPaidRecharge)
        {
            CurrentFundFreezeRequest request = new CurrentFundFreezeRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = orderPaidRecharge.SerialNumber;
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.CifClientId = orderPaidRecharge.OrderPaid.Member.ClientId;
            request.Body.FreezeType = "0";
            request.Body.Currency = "CNY";
            request.Body.CEFlag = "0";
            request.Body.ThawDate = orderPaidRecharge.UnFreezeDate.ToString("yyyyMMdd");
            request.Body.Amount = orderPaidRecharge.Amount.ToString();
            request.Body.ProtocolNo = "";
            request.Body.GroupNo = "";
            request.Body.TravelStartDay = "";
            request.Body.TravelEndDay = "";
            request.Body.ProtocolDate = "";
            request.Body.Remark = "";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";
            request.Body.Reserve4 = "";
            request.Body.Reserve5 = "";

            var result = guangDaExec.Exec(request) as CurrentFundFreezeResponse;

            return result;
        }

        /// <summary>
        /// 解冻
        /// </summary>
        /// <returns></returns>
        public UnfrozenFixedDepositResponse Unfreeze(OrderPaidUnFreeze orderPaidUnFreeze)
        {
            UnfrozenFixedDepositRequest request = new UnfrozenFixedDepositRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.TrsDate = orderPaidUnFreeze.OrderPaid.FreezeDate.ToDateTime().ToString("yyyyMMdd");
            request.Body.CoPatrnerJnlNo = orderPaidUnFreeze.OrderPaid.FreezeSerialNumber;
            request.Body.ManageFlag = "5";
            request.Body.Currency = "CNY";

            var result = guangDaExec.Exec(request) as UnfrozenFixedDepositResponse;

            return result;
        }

        public BaseResponse Withdraw(OrderPaidWithdraw orderPaidWithdraw)
        {
            if (orderPaidWithdraw.Amount < 50000)
            {
                return SmallWithdraw(orderPaidWithdraw);
            }
            else
            {
                return LargeWithdraw(orderPaidWithdraw);
            }
        }

        /// <summary>
        /// 提现，五万以下
        /// </summary>
        /// <returns></returns>
        private EComGAmountResponse SmallWithdraw(OrderPaidWithdraw orderPaidWithdraw)
        {
            EComGAmountRequest request = new EComGAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.Amount = orderPaidWithdraw.Amount.ToString();
            request.Body.CifClientId = orderPaidWithdraw.OrderPaid.Member.ClientId;
            request.Body.Currency = "CNY";
            request.Body.ChannelSeq = orderPaidWithdraw.SerialNumber;
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.WDType = "1";
            request.Body.Remark = "提现";
            request.Body.WDName = orderPaidWithdraw.OrderPaid.Member.Name;
            request.Body.IdType = "P00";
            request.Body.IdNo = orderPaidWithdraw.OrderPaid.Member.IDNumber;
            request.Body.WDAcNo = orderPaidWithdraw.OrderPaid.Member.BankCardNumber;
            request.Body.WDBankNo = orderPaidWithdraw.OrderPaid.Member.BankCard.Bank.CodeGuangDa;
            request.Body.WDInnerBankFlag = orderPaidWithdraw.OrderPaid.Member.BankCard.Bank.CodeGuangDa != "303100000006" ? "1" : "0";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";

            //request.Body.CifClientId = "6d57392972f663e6";
            //request.Body.Currency = "CNY";
            //request.Body.ChannelSeq = GuidHelper.GenUniqueId();
            //request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            //request.Body.WDType = "1";
            //request.Body.Remark = "提现";
            //request.Body.WDName = "廖一";
            //request.Body.IdType = "P00";
            //request.Body.IdNo = "460031198806150013";
            //request.Body.WDAcNo = "6212260200000110001";
            //request.Body.WDBankNo = "102100099996";
            //request.Body.WDInnerBankFlag = "1";
            //request.Body.Reserve1 = "";
            //request.Body.Reserve2 = "";
            //request.Body.Reserve3 = "";

            var result = guangDaExec.Exec(request) as EComGAmountResponse;

            return result;
        }

        /// <summary>
        /// 提现，五万以上
        /// </summary>
        /// <returns></returns>
        private BJUnionPayPaymentResponse LargeWithdraw(OrderPaidWithdraw orderPaidWithdraw)
        {
            BJUnionPayPaymentRequest request = new BJUnionPayPaymentRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CifClientId = orderPaidWithdraw.OrderPaid.Member.ClientId;
            request.Body.CoPatrnerJnlNo = orderPaidWithdraw.SerialNumber;
            request.Body.TrsDate = DateTime.Now.ToString("yyyyMMdd");
            request.Body.Currency = "CNY";
            request.Body.AcNo = orderPaidWithdraw.OrderPaid.Member.BankCardNumber;
            request.Body.PayeeName = orderPaidWithdraw.OrderPaid.Member.Name;
            request.Body.PayeeBankName = orderPaidWithdraw.OrderPaid.Member.BankCard.Bank.Name;
            request.Body.PayeeBankNo = orderPaidWithdraw.OrderPaid.Member.BankCard.Bank.CodeGuangDa;
            request.Body.AcType = "2";
            request.Body.Amount = orderPaidWithdraw.Amount.ToString();
            request.Body.TransferFee = "0";
            request.Body.Remark = "提现";
            request.Body.Reserve1 = "";
            request.Body.Reserve2 = "";
            request.Body.Reserve3 = "";
            request.Body.Reserve4 = "";
            request.Body.Reserve5 = "";

            var result = guangDaExec.Exec(request) as BJUnionPayPaymentResponse;

            return result;
        }

        /// <summary>
        /// 资金变动查证接口
        /// </summary>
        /// <returns></returns>
        public BTrsVeriAmountResponse BTrsVeriAmount(string number, DateTime date)
        {
            BTrsVeriAmountRequest request = new BTrsVeriAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
            request.Body.TrsDate = date.ToString("yyyyMMdd");
            request.Body.Reserve2 = number;

            var result = guangDaExec.Exec(request) as BTrsVeriAmountResponse;

            return result;
        }

        public BCifAcNoAmountResponse BCifAcNoAmount(string clientId)
        {
            BCifAcNoAmountRequest request = new BCifAcNoAmountRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.CifClientId = clientId;

            var result = guangDaExec.Exec(request) as BCifAcNoAmountResponse;

            return result;
        }

        /// <summary>
        /// 对账
        /// </summary>
        /// <returns></returns>
        public BFinFundServiceReqResponse BFinFundServiceReq(DateTime? date)
        {
            BFinFundServiceReqRequest request = new BFinFundServiceReqRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();

            request.Body.QryDate = date == null ? "" : date.ToDateTime().ToString("yyyyMMdd");
            request.Body.ServiceId = "BMerCheckJnlFileReq";

            var result = guangDaExec.Exec(request) as BFinFundServiceReqResponse;

            return result;
        }

        /// <summary>
        /// 2.49.	冻结状态查询接口
        /// </summary>
        /// <returns></returns>
        public QueryFreezeCombinationResponse QueryFreezeCombination(string clientID, DateTime unfreezeDate)
        {
            QueryFreezeCombinationRequest request = new QueryFreezeCombinationRequest();

            request.Head.ReqJnlNo = GuidHelper.GenUniqueId();
            request.Body.StartCount = 0;
            request.Body.QryCount = 99;
            request.Body.UnfreezeDate = unfreezeDate.ToString("yyyyMMdd");

            request.Body.CifClientId = clientID;

            var result = guangDaExec.Exec(request) as QueryFreezeCombinationResponse;

            return result;
        }
    }
}

﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Common;
using Framework.LambdaExpression;
using Framework.Web.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using AIPXiaoTong.Model.API;
using TltApi.Model;
using TltApi;
using AIPXiaoTong.Model.PingAnAPI;
using PingAnAPI.Model;
using VSP.Pay.ResponseModel;
using iTextSharp.text.log;

namespace AIPXiaoTong.Service
{
    public class OrderPaidService : BusinessService<OrderPaid>, IOrderPaidService
    {
        public ILogger logger;
        // TltExec tltExec = null;
        public string url = System.Configuration.ConfigurationManager.AppSettings["TltUrl"].ToString();
        public override Expression<Func<OrderPaid, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<OrderPaid, bool>> express = DynamicExpressions.True<OrderPaid>();

            var m = model as OrderPaidQM;

            if (!string.IsNullOrWhiteSpace(m.OrderNumber))
            {
                express = express.AndAlso(t => t.OrderNumber == m.OrderNumber.Trim());
            }
            if (!string.IsNullOrWhiteSpace(m.MemberMobile))
            {
                express = express.AndAlso(t => t.Member.Mobile == m.MemberMobile.Trim());
            }
            if (!string.IsNullOrWhiteSpace(m.MemberName))
            {
                express = express.AndAlso(t => t.Member.Name.Contains(m.MemberName.Trim()));
            }
            if (m.ProjectID != null)
            {
                express = express.AndAlso(t => t.ProjectID == m.ProjectID);
            }
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }
            if (currentUser.MerchantID != 0)
            {
                express = express.AndAlso(t => t.Merchant.ID == currentUser.MerchantID);
            }

            if (m.QueryDate != null)
            {
                express = express.AndAlso(t => t.CreateDatetime >= m.QueryDate);
            }

            return express;
        }

        public override void Save(OrderPaid e)
        {
            if (e.ID == 0)
            {
                e.OrderNumber = GuidHelper.GenUniqueId();

                if (DateTime.Now > e.Project.Deadline && DateTime.Now < e.Project.StartTime)
                    throw new Exception("不在活动日期范围内");

            }

            base.Save(e);
        }

        public override IOrderByExpression<OrderPaid> GetOrderBy()
        {
            return new OrderByExpression<OrderPaid, long>(t => t.ID, true);
        }

        public List<OrderPaidEM> Export(OrderPaidQM model)
        {
            if (model == null) model = new OrderPaidQM();

            var express = GetExpress(model);

            var status = OrderPaidRechargeStatusOption.Success.ToInt();

            var list = Gets(express).Select(t => new OrderPaidEM()
            {
                OrderNumber = t.OrderNumber,
                ProjectName = t.Project.ProjectName,
                // HouseTypeName = t.HouseTypeShow.HouseTypeName,
                EquipmentSNNo = t.EquipmentSNNo,
                EmployeeName = t.Employee.Name,
                TransactionAmount = t.TransactionAmount,
                MemberName = t.Member.Name,
                MemberIDNumber = t.Member.IDNumber,
                MemberMobile = t.Member.Mobile,
                Status = t.Status,
                MerchantName = t.Merchant.Name,

            }).ToList();

            return list;
        }



        private void RechargeSuccess(OrderPaidRecharge orderPaidRecharge, string TransNumber, DateTime TransTime)
        {
            var iOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IOrderPaidRechargeService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            orderPaidRecharge.OrderPaid.Status = OrderPaidStatusOption.RechargeSuccess.ToInt();
            orderPaidRecharge.OrderPaid.Project.ReceiveAmount += orderPaidRecharge.Amount;
            Save(orderPaidRecharge.OrderPaid);

            orderPaidRecharge.Status = OrderPaidRechargeStatusOption.Success.ToInt();
            orderPaidRecharge.BankCardNumber = orderPaidRecharge.OrderPaid.Member.BankCardNumber;
            orderPaidRecharge.TransNumber = TransNumber;
            orderPaidRecharge.TransTime = TransTime;
            iOrderPaidRechargeService.Save(orderPaidRecharge);

            iMemberService.BalanceChange(orderPaidRecharge.OrderPaid.Member, orderPaidRecharge.Amount, MemberBalanceHistoryTypeOption.Recharge, (AccountBankOption)orderPaidRecharge.OrderPaid.Merchant.AccountBank, remark: orderPaidRecharge.SerialNumber);
        }

        public void TltSingleOntimePaySuccess(PingAnOrderPaidRecharge pingAnOrderPaidRecharge, string TransNumber, string SettleDay)
        {
            var iPingAnOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidRechargeService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            pingAnOrderPaidRecharge.OrderPaid.Status = OrderPaidStatusOption.SingleOntimePaySuccess.ToInt();
            // pingAnOrderPaidRecharge.OrderPaid.Project.ReceiveAmount += pingAnOrderPaidRecharge.Amount;
            Save(pingAnOrderPaidRecharge.OrderPaid);

            pingAnOrderPaidRecharge.Status = PingAnOrderPaidRechargeStatusOption.SingleOntimePaySuccess.ToInt();
            pingAnOrderPaidRecharge.BankCardNumber = pingAnOrderPaidRecharge.OrderPaid.Member.AccountPingAn.BankCardNumber;
            pingAnOrderPaidRecharge.TransNumber = TransNumber;
            pingAnOrderPaidRecharge.TransTime = DateTime.ParseExact(SettleDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);   // 清算日期--转为时间格式
            iPingAnOrderPaidRechargeService.Save(pingAnOrderPaidRecharge);

            iMemberService.BalanceChange(pingAnOrderPaidRecharge.OrderPaid.Member, pingAnOrderPaidRecharge.Amount, MemberBalanceHistoryTypeOption.Recharge, (AccountBankOption)pingAnOrderPaidRecharge.OrderPaid.Merchant.AccountBank, remark: pingAnOrderPaidRecharge.SerialNumber);    //修改金额
        }

        private void RechargeFail(OrderPaidRecharge orderPaidRecharge)
        {
            var iOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IOrderPaidRechargeService>();

            orderPaidRecharge.Status = OrderPaidRechargeStatusOption.Fail.ToInt();
            iOrderPaidRechargeService.Save(orderPaidRecharge);

            //orderPaidRecharge.OrderPaid.Status = OrderPaidStatusOption.Cancel.ToInt();
            //Save(orderPaidRecharge.OrderPaid);

        }

        private void FreezeSuccess(OrderPaidFreeze orderPaidFreeze, decimal balance)
        {
            var iOrderPaidFreezeService = DIFactory.GetContainer().Resolve<IOrderPaidFreezeService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            orderPaidFreeze.OrderPaid.Status = OrderPaidStatusOption.FrozenSuccess.ToInt();
            Save(orderPaidFreeze.OrderPaid);

            orderPaidFreeze.Balance = balance;
            orderPaidFreeze.Status = OrderPaidFreezeStatusOption.Success.ToInt();
            orderPaidFreeze.TransTime = DateTime.Now;
            iOrderPaidFreezeService.Save(orderPaidFreeze);

            iMemberService.BalanceChange(orderPaidFreeze.OrderPaid.Member, orderPaidFreeze.Amount * -1, MemberBalanceHistoryTypeOption.Freeze, (AccountBankOption)orderPaidFreeze.OrderPaid.Merchant.AccountBank, orderPaidFreeze.Amount, remark: orderPaidFreeze.SerialNumber);

        }

        private void UnFreezeSuccess(OrderPaidUnFreeze orderPaidUnFreeze)
        {
            var iOrderPaidUnFreezeService = DIFactory.GetContainer().Resolve<IOrderPaidUnFreezeService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            orderPaidUnFreeze.OrderPaid.Status = OrderPaidStatusOption.UnFrozenSuccess.ToInt();
            Save(orderPaidUnFreeze.OrderPaid);

            orderPaidUnFreeze.Status = OrderPaidUnFreezeStatusOption.Success.ToInt();
            orderPaidUnFreeze.TransTime = DateTime.Now;
            iOrderPaidUnFreezeService.Save(orderPaidUnFreeze);

            iMemberService.BalanceChange(orderPaidUnFreeze.OrderPaid.Member, orderPaidUnFreeze.Amount, MemberBalanceHistoryTypeOption.UnFreeze, (AccountBankOption)orderPaidUnFreeze.OrderPaid.Merchant.AccountBank, orderPaidUnFreeze.Amount * -1, remark: orderPaidUnFreeze.SerialNumber);
        }

        private void PingAnUnFreezeSuccess(PingAnOrderPaidUnFreeze pingAnOrderPaidUnFreeze)
        {
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();
            var iPingAnOrderPaidUnFreezeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidUnFreezeService>();
            var iPingAnOrderPaidService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidService>();

            pingAnOrderPaidUnFreeze.OrderPaid.Status = OrderPaidStatusOption.UnFrozenSuccess.ToInt();  //更新订单主表状态
            Save(pingAnOrderPaidUnFreeze.OrderPaid);

            pingAnOrderPaidUnFreeze.OrderPaid.PingAnOrderPaid.Status = PingAnOrderPaidStatusOption.UnFrozenSuccess.ToInt();  //更新平安订单子表状态
            iPingAnOrderPaidService.Save(pingAnOrderPaidUnFreeze.OrderPaid.PingAnOrderPaid);

            pingAnOrderPaidUnFreeze.Status = PingAnOrderPaidUnFreezeStatusOption.Success.ToInt(); //更新解止付订单状态
            pingAnOrderPaidUnFreeze.TransTime = DateTime.Now;
            iPingAnOrderPaidUnFreezeService.Save(pingAnOrderPaidUnFreeze);

            iMemberService.BalanceChange(pingAnOrderPaidUnFreeze.OrderPaid.Member, pingAnOrderPaidUnFreeze.Amount, MemberBalanceHistoryTypeOption.UnFreeze, (AccountBankOption)pingAnOrderPaidUnFreeze.OrderPaid.Merchant.AccountBank, pingAnOrderPaidUnFreeze.Amount * -1, remark: pingAnOrderPaidUnFreeze.SerialNumber);
        }

        private void WithdrawSuccess(OrderPaidWithdraw orderPaidWithdraw)
        {
            var iOrderPaidWithdrawService = DIFactory.GetContainer().Resolve<IOrderPaidWithdrawService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            if (orderPaidWithdraw.OrderPaid.PayAction == OrderPaidPayActionOption.Repeal.ToInt())
            {
                orderPaidWithdraw.OrderPaid.Status = OrderPaidStatusOption.Repeal.ToInt();
            }
            else
            {
                orderPaidWithdraw.OrderPaid.Status = OrderPaidStatusOption.WithdrawSuccess.ToInt();
            }
            Save(orderPaidWithdraw.OrderPaid);

            orderPaidWithdraw.Status = OrderPaidWithdrawStatusOption.Success.ToInt();
            orderPaidWithdraw.TransTime = DateTime.Now;
            iOrderPaidWithdrawService.Save(orderPaidWithdraw);

            iMemberService.BalanceChange(orderPaidWithdraw.OrderPaid.Member, orderPaidWithdraw.Amount * -1, MemberBalanceHistoryTypeOption.Withdraw, (AccountBankOption)orderPaidWithdraw.OrderPaid.Merchant.AccountBank, remark: orderPaidWithdraw.SerialNumber);
        }

        private void WithdrawFail(OrderPaidWithdraw orderPaidWithdraw)
        {
            var iOrderPaidWithdrawService = DIFactory.GetContainer().Resolve<IOrderPaidWithdrawService>();

            orderPaidWithdraw.Status = OrderPaidWithdrawStatusOption.Fail.ToInt();
            iOrderPaidWithdrawService.Save(orderPaidWithdraw);


            orderPaidWithdraw.OrderPaid.Status = OrderPaidStatusOption.UnFrozenSuccess.ToInt();
            Save(orderPaidWithdraw.OrderPaid);
        }

        /// <summary>
        /// 同步状态--光大
        /// </summary>
        /// <param name="orderPaid"></param>
        public void SyncStatus(OrderPaid orderPaid)
        {
            var iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();
            var iOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IOrderPaidRechargeService>();
            var iOrderPaidWithdrawService = DIFactory.GetContainer().Resolve<IOrderPaidWithdrawService>();

            //if (orderPaid.Status == OrderPaidStatusOption.PaySuccess.ToInt())
            //{
            //    RechargeAndFreeze(orderPaid);
            //}
            if (orderPaid.Status == OrderPaidStatusOption.RechargeWait.ToInt())
            {
                var orderPaidRecharge = iOrderPaidRechargeService.GetLast(t => t.OrderPaidID == orderPaid.ID);

                //查询充值或提现状态
                var response = iGuangDaAPIService.BTrsVeriAmount(orderPaidRecharge.SerialNumber, orderPaidRecharge.CreateDatetime);

                if (response?.Body?.TrsState == "0")
                {
                    RechargeSuccess(orderPaidRecharge, "", DateTime.Now);
                }
                else if (response?.Body?.TrsState == "1")
                {
                    RechargeFail(orderPaidRecharge);
                }
                else if (response.IsNotExists && DateTime.Now > orderPaidRecharge.CreateDatetime.AddMinutes(5))
                {
                    RechargeFail(orderPaidRecharge);
                }
            }
            //else if (orderPaid.Status == OrderPaidStatusOption.RechargeSuccess.ToInt())
            //{
            //    Freeze(orderPaid);
            //}
            //else if (orderPaid.Status == OrderPaidStatusOption.UnFrozenSuccess.ToInt())
            //{
            //    Withdraw(orderPaid);
            //}
            else if (orderPaid.Status == OrderPaidStatusOption.WithdrawWait.ToInt())
            {
                var orderPaidWithdraw = iOrderPaidWithdrawService.GetLast(t => t.OrderPaidID == orderPaid.ID);

                //查询充值或提现状态
                var response = iGuangDaAPIService.BTrsVeriAmount(orderPaidWithdraw.SerialNumber, orderPaidWithdraw.CreateDatetime);

                if (response?.Body?.TrsState == "0")
                {
                    WithdrawSuccess(orderPaidWithdraw);
                }
                else if (response?.Head?.ResCode == "000357" || response?.Body?.TrsState == "1")
                {
                    WithdrawFail(orderPaidWithdraw);
                }
                else if (response.IsNotExists && DateTime.Now > orderPaidWithdraw.CreateDatetime.AddMonths(5))
                {
                    WithdrawFail(orderPaidWithdraw);
                }
            }
        }

        public string UpdateAutoLoginUrl(OrderPaid orderPaid)
        {
            var iPingAnAPIService = DIFactory.GetContainer().Resolve<IPingAnAPIService>();
            var iPingAnOrderPaidService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidService>();
            var result = "";

            var autoLoginUrl = iPingAnAPIService.AutoLogin(orderPaid.PingAnOrderPaid, orderPaid.Member);

            if (!string.IsNullOrWhiteSpace(autoLoginUrl.autoLoginPath))
            {
                //orderPaid.PingAnOrderPaid.AutoLoginUrl = autoLoginUrl.autoLoginPath;

                //iPingAnOrderPaidService.Save(orderPaid.PingAnOrderPaid);
                //iPingAnOrderPaidService.Commit();

                result = autoLoginUrl.autoLoginPath;
            }
            else
            {
                throw new APIException("获取免登地址失败");
            }

            return result;
        }

        /// <summary>
        /// 同步状态--平安
        /// </summary>
        /// <param name="orderPaid"></param>
        public void PingAnSyncStatus(OrderPaid orderPaid)
        {
            var iPingAnAPIService = DIFactory.GetContainer().Resolve<IPingAnAPIService>();
            var iPingAnOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidRechargeService>();
            var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();


            if (orderPaid.Status == OrderPaidStatusOption.SingleOntimePayWait.ToInt())
            {
                var pingAnOrderPaidRecharge = iPingAnOrderPaidRechargeService.GetLast(t => t.OrderPaidID == orderPaid.ID);

                //查询订单代付状态               
                var response = QuerySingleOntimePayDetail(pingAnOrderPaidRecharge);

                if ((response.INFO?.RET_CODE == "0000" || response.INFO?.RET_CODE == "4000"))
                {
                    if ((response.QTRANSRSP?.FirstQtdetail.RET_CODE == "0000" || response.QTRANSRSP?.FirstQtdetail.RET_CODE == "4000"))
                    {
                        //成功
                        TltSingleOntimePaySuccess(pingAnOrderPaidRecharge, response.INFO.REQ_SN, response.QTRANSRSP.FirstQtdetail.SETTDAY);
                    }
                    else if (!string.IsNullOrWhiteSpace(response.QTRANSRSP?.FirstQtdetail?.RET_CODE))
                    {
                        //失败
                        TltSingleOntimePayFail(pingAnOrderPaidRecharge);
                    }
                }
                else if (response.INFO?.RET_CODE == "1000")
                {
                    //不处理，继续查询
                }
                else if (response.INFO?.RET_CODE == "1002")
                {
                    //  需判断下单时间是否大于50分钟，是：失败  否：继续查询
                    if (((DateTime.Now.Subtract(pingAnOrderPaidRecharge.CreateDatetime).Duration().TotalMinutes) > 50))
                    {
                        TltSingleOntimePayFail(pingAnOrderPaidRecharge);
                    }
                }
                else if (response.INFO?.RET_CODE == "2002" || response.INFO?.RET_CODE == "2004" || response.INFO?.RET_CODE == "2006")
                {
                    //直接失败
                    TltSingleOntimePayFail(pingAnOrderPaidRecharge);
                }
                else if (response.INFO?.RET_CODE == "2000" || response.INFO?.RET_CODE == "2001" || response.INFO?.RET_CODE == "2003"
                        || response.INFO?.RET_CODE == "2005" || response.INFO?.RET_CODE == "2007" || response.INFO?.RET_CODE == "2008")
                {
                    if (response.QTRANSRSP?.FirstQtdetail.RET_CODE == "0000" || response.QTRANSRSP?.FirstQtdetail.RET_CODE == "4000")
                    {
                        //成功
                        TltSingleOntimePaySuccess(pingAnOrderPaidRecharge, response.INFO.REQ_SN, response.QTRANSRSP.FirstQtdetail.SETTDAY);
                    }
                    else if (!string.IsNullOrWhiteSpace(response.QTRANSRSP?.FirstQtdetail?.RET_CODE))
                    {
                        //失败
                        TltSingleOntimePayFail(pingAnOrderPaidRecharge);
                    }
                }
            }
            else if (orderPaid.Status == OrderPaidStatusOption.SingleOntimePaySuccess.ToInt() || orderPaid.Status == OrderPaidStatusOption.Default.ToInt())
            {
                //防止订单转账后（代付成功）并且在平安冻结成功但是未通知成功或者平安二类卡金额够，直接冻结但是通知失败的情况下做订单状态更新
                var orderDetailResponse = QueryPingAnMarginsOrderDetail(orderPaid.PingAnOrderPaid.BankOrderNo);

                if (orderDetailResponse.IsOK)
                {
                    if (orderDetailResponse.dataObject.marginsOrderInfoList != null)
                    {
                        if (orderDetailResponse.dataObject.marginsOrderInfoList.FirstOrDefault().transStatus == PingAnOrderPaidStatusOption.FrozenSuccess.ToInt().ToString())
                        {
                            orderPaid.Status = OrderPaidStatusOption.FrozenSuccess.ToInt();

                            iOrderPaidService.Save(orderPaid);

                            iOrderPaidService.PingAnFreeze(orderPaid.PingAnOrderPaid, orderDetailResponse.dataObject.marginsOrderInfoList.FirstOrDefault().freezeTime);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 查询单笔代付订单详情
        /// </summary>
        /// <param name="pingAnOrderPaidRecharge"></param>
        /// <returns></returns>
        public QueryTltTradingResultResponse QuerySingleOntimePayDetail(PingAnOrderPaidRecharge pingAnOrderPaidRecharge)
        {
            var iTltService = DIFactory.GetContainer().Resolve<ITltService>();
            var iTLTPreferencesService = DIFactory.GetContainer().Resolve<ITLTPreferencesService>();

            var TLTPreferences = iTLTPreferencesService.Get(t => t.MerchantID == pingAnOrderPaidRecharge.OrderPaid.MerchantID);

            //初始化通联通参数
            if (!iTltService.isReady())
            {
                iTltService.Init(url, TLTPreferences.TltMerchantId, TLTPreferences.TltUserName, TLTPreferences.TltUserPassword, TLTPreferences.TltPrivateKeyPassword);
            }
            //查询订单代付状态
            var response = iTltService.QueryTltTradingResult(GuidHelper.GenUniqueId(), pingAnOrderPaidRecharge.SerialNumber, "200004");   //200004为通联通接口交易代码

            return response;
        }

        public void RechargeAndFreeze(OrderPaid orderPaid)
        {
            var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

            if (orderPaid.Status == OrderPaidStatusOption.PaySuccess.ToInt())
            {
                Recharge(orderPaid);

                Freeze(orderPaid);
            }
            else if (orderPaid.Status == OrderPaidStatusOption.RechargeSuccess.ToInt())
            {
                Freeze(orderPaid);
            }
            else
            {
                throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
            }
        }

        public void PingAnTltSingleOntimePay(OrderPaid orderPaid)
        {
            if (orderPaid.Status == OrderPaidStatusOption.PaySuccess.ToInt() || orderPaid.Status == OrderPaidStatusOption.SingleOntimePayFail.ToInt())
            {
                TltSingleOntimePay(orderPaid);
            }
            else
            {
                throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
            }
        }

        public void UnFreezeAndWithdraw(OrderPaid orderPaid)
        {
            var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

            if (orderPaid.Status == OrderPaidStatusOption.FrozenSuccess.ToInt())
            {
                UnFreeze(orderPaid);

                Withdraw(orderPaid);
            }
            else if (orderPaid.Status == OrderPaidStatusOption.UnFrozenSuccess.ToInt())
            {
                Withdraw(orderPaid);
            }
            else
            {
                throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
            }
        }

        /// <summary>
        /// 解止付平安保证金订单
        /// </summary>
        /// <param name="orderPaid"></param>
        public void UnFreezePingAnMargins(OrderPaid orderPaid)
        {
            var iPingAnAPIService = DIFactory.GetContainer().Resolve<IPingAnAPIService>();
            var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

            if (orderPaid.Status == OrderPaidStatusOption.FrozenSuccess.ToInt())
            {
                PingAnUnFreeze(orderPaid);
            }
            else
            {
                throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
            }
        }



        ///// <summary>
        ///// 充值
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public void Recharge(string orderNumber)
        //{
        //    var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

        //    var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == orderNumber.Trim());

        //    if (orderPaid == null)
        //        throw new APIException("订单号(" + orderNumber.Trim() + ")不存在");

        //    if (orderPaid.Status == OrderPaidStatusOption.Default.ToInt())
        //    {
        //        Recharge(orderPaid);
        //        Freeze(orderPaid);
        //    }
        //    else if (orderPaid.Status == OrderPaidStatusOption.PaySuccess.ToInt())
        //    {
        //        Freeze(orderPaid);
        //    }
        //    else
        //    {
        //        throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
        //    }

        //}

        ///// <summary>
        ///// 提现
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public void Withdraw(string orderNumber)
        //{
        //    var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

        //    var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == orderNumber.Trim());

        //    if (orderPaid == null)
        //        throw new APIException("订单号(" + orderNumber.Trim() + ")不存在");

        //    if (orderPaid.Status == OrderPaidStatusOption.FrozenSuccess.ToInt())
        //    {
        //        UnFreeze(orderPaid);
        //        Withdraw(orderPaid);
        //    }
        //    else if (orderPaid.Status == OrderPaidStatusOption.UnFrozenSuccess.ToInt())
        //    {
        //        Withdraw(orderPaid);
        //    }
        //    else
        //    {
        //        throw new APIException("当前状态(" + orderPaid.StatusDesc + ")无法操作");
        //    }
        //}


        public void Recharge(OrderPaid orderPaid)
        {
            if (orderPaid.Status != OrderPaidStatusOption.PaySuccess.ToInt())
            {
                throw new Exception("当前状态不可充值(" + orderPaid.StatusDesc + ")");
            }

            var iOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IOrderPaidRechargeService>();
            var iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();
            //var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

            if (orderPaid.TransactionAmount > orderPaid.Project.ResidueAmount)
                throw new Exception("剩余认筹额度不足");

            if (DateTime.Now > orderPaid.Project.Deadline)
                throw new Exception("已过截止日期");

            OrderPaidRecharge orderPaidRecharge = new OrderPaidRecharge();

            orderPaidRecharge.OrderPaidID = orderPaid.ID;
            orderPaidRecharge.Amount = orderPaid.TransactionAmount;
            orderPaidRecharge.Status = OrderPaidRechargeStatusOption.Wait.ToInt();

            iOrderPaidRechargeService.Save(orderPaidRecharge);

            orderPaid.Status = OrderPaidStatusOption.RechargeWait.ToInt();

            iOrderPaidRechargeService.Commit();

            var rechargeResponse = iGuangDaAPIService.Recharge(orderPaidRecharge);

            orderPaidRecharge.ResponseCode = rechargeResponse.Head.ResCode;
            orderPaidRecharge.ResponseMessage = rechargeResponse.Head.ResMsg;

            if (rechargeResponse.IsOK)
            {
                RechargeSuccess(orderPaidRecharge, rechargeResponse.Body.EbankJnlNo, rechargeResponse.Body.CebTrsTime.ToDateTime("yyyy-MM-dd HH:mm:ss"));

                Commit();
            }
            else if (rechargeResponse.IsWait)
            {
                //orderPaid.Status = OrderPaidStatusOption.RechargeWait.ToInt();
                //Save(orderPaid);

                //orderPaidRecharge.Status = OrderPaidRechargeStatusOption.Wait.ToInt();
                //iOrderPaidRechargeService.Save(orderPaidRecharge);

                //Commit();

                throw new APIException("充值中，请查询确认（" + rechargeResponse.Head.ResMsg + "）");
            }
            else
            {
                RechargeFail(orderPaidRecharge);

                Commit();

                throw new APIException("充值失败：" + rechargeResponse.Head.ResMsg);
            }

        }

        private void TltSingleOntimePay(OrderPaid orderPaid)
        {
            var iTltService = DIFactory.GetContainer().Resolve<ITltService>();
            var iAccountPingAnService = DIFactory.GetContainer().Resolve<IAccountPingAnService>();
            var iPingAnOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidRechargeService>();
            var iTLTPreferencesService = DIFactory.GetContainer().Resolve<ITLTPreferencesService>();

            var TLTPreferences = iTLTPreferencesService.Get(t => t.MerchantID == orderPaid.MerchantID);
            var accountPingAn = iAccountPingAnService.Get(t => t.MemberID == orderPaid.MemberID);

            PingAnOrderPaidRecharge pingAnOrderPaidRecharge = new PingAnOrderPaidRecharge();

            pingAnOrderPaidRecharge.OrderPaidID = orderPaid.ID;
            pingAnOrderPaidRecharge.Amount = orderPaid.TransactionAmount;

            pingAnOrderPaidRecharge.BankCode = accountPingAn.BankCode;
            pingAnOrderPaidRecharge.BankName = accountPingAn.BankName;
            pingAnOrderPaidRecharge.AccountType = accountPingAn.AccountType;
            pingAnOrderPaidRecharge.Province = accountPingAn.Province;
            pingAnOrderPaidRecharge.City = accountPingAn.City;
            pingAnOrderPaidRecharge.AccountProp = accountPingAn.AccountProp;
            pingAnOrderPaidRecharge.UnionBank = accountPingAn.UnionBank;

            iPingAnOrderPaidRechargeService.Save(pingAnOrderPaidRecharge);
            iPingAnOrderPaidRechargeService.Commit();

            //初始化TLT参数        
            if (!iTltService.isReady())
            {
                iTltService.Init(url, TLTPreferences.TltMerchantId, TLTPreferences.TltUserName, TLTPreferences.TltUserPassword, TLTPreferences.TltPrivateKeyPassword);
            }
            //调通联通代付接口
            var singleOntimePayResponse = iTltService.SingleOntimePay(orderPaid, pingAnOrderPaidRecharge);


            pingAnOrderPaidRecharge.ResponseCode = singleOntimePayResponse.INFO.RET_CODE;
            pingAnOrderPaidRecharge.ResponseMessage = singleOntimePayResponse.INFO.ERR_MSG;

            pingAnOrderPaidRecharge.BankCardNumber = pingAnOrderPaidRecharge.OrderPaid.Member.AccountPingAn.BankCardNumber;
            pingAnOrderPaidRecharge.TransNumber = singleOntimePayResponse.INFO.REQ_SN;

            if (singleOntimePayResponse.Status == StatusOption.Success)
            {
                TltSingleOntimePaySuccess(pingAnOrderPaidRecharge, singleOntimePayResponse.INFO.REQ_SN, singleOntimePayResponse.TRANSRET.SETTLE_DAY);

                Commit();
            }
            else if (singleOntimePayResponse.Status == StatusOption.Wait)
            {
                orderPaid.Status = OrderPaidStatusOption.SingleOntimePayWait.ToInt();
                Save(orderPaid);
                
                pingAnOrderPaidRecharge.Status = PingAnOrderPaidRechargeStatusOption.SingleOntimePayWait.ToInt();
                iPingAnOrderPaidRechargeService.Save(pingAnOrderPaidRecharge);

                Commit();
            }
            else
            {
                TltSingleOntimePayFail(pingAnOrderPaidRecharge);

                Commit();

                throw new APIException("充值失败：" + singleOntimePayResponse.INFO.ERR_MSG);
            }
        }

        private void TltSingleOntimePayFail(PingAnOrderPaidRecharge pingAnOrderPaidRecharge)
        {
            var iPingAnOrderPaidRechargeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidRechargeService>();

            pingAnOrderPaidRecharge.OrderPaid.Status = OrderPaidStatusOption.SingleOntimePayFail.ToInt();

            pingAnOrderPaidRecharge.Status = PingAnOrderPaidRechargeStatusOption.SingleOntimePayFailed.ToInt();
            iPingAnOrderPaidRechargeService.Save(pingAnOrderPaidRecharge);
        }

        public void PingAnFreeze(PingAnOrderPaid pingAnOrderPaid, string tradeTime)
        {
            var iPingAnOrderPaidService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidService>();
            var iMemberService = DIFactory.GetContainer().Resolve<IMemberService>();

            pingAnOrderPaid.Status = PingAnOrderPaidStatusOption.FrozenSuccess.ToInt();
            pingAnOrderPaid.FreezeSuccessTime = Convert.ToDateTime(tradeTime);

            iPingAnOrderPaidService.Save(pingAnOrderPaid);
            iPingAnOrderPaidService.Commit();

            pingAnOrderPaid.OrderPaid.Project.ReceiveAmount += pingAnOrderPaid.OrderPaid.TransactionAmount;
            Save(pingAnOrderPaid.OrderPaid);

            iMemberService.BalanceChange(pingAnOrderPaid.OrderPaid.Member, pingAnOrderPaid.OrderPaid.TransactionAmount * -1, MemberBalanceHistoryTypeOption.Freeze, (AccountBankOption)pingAnOrderPaid.OrderPaid.Merchant.AccountBank, pingAnOrderPaid.OrderPaid.TransactionAmount, remark: pingAnOrderPaid.OrderPaid.OrderNumber);    //修改金额

            Commit();
        }

        public void Freeze(OrderPaid orderPaid)
        {
            if (orderPaid.Status != OrderPaidStatusOption.RechargeSuccess.ToInt())
            {
                throw new Exception("当前状态不可冻结(" + orderPaid.StatusDesc + ")");
            }


            var iOrderPaidFreezeService = DIFactory.GetContainer().Resolve<IOrderPaidFreezeService>();
            var iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();
            //var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();

            OrderPaidFreeze orderPaidFreeze = new OrderPaidFreeze();

            orderPaidFreeze.OrderPaid = orderPaid;
            orderPaidFreeze.Amount = orderPaid.TransactionAmount;
            orderPaidFreeze.UnFreezeDate = DateTime.Now.AddMonths(orderPaid.Project.GuaranteeMonth);

            iOrderPaidFreezeService.Save(orderPaidFreeze);
            iOrderPaidFreezeService.Commit();

            var freezeResponse = iGuangDaAPIService.Freeze(orderPaidFreeze);

            orderPaidFreeze.ResponseCode = freezeResponse.Head.ResCode;
            orderPaidFreeze.ResponseMessage = freezeResponse.Head.ResMsg;

            if (freezeResponse.IsOK && freezeResponse.Body?.FreezeState == "S")
            {
                FreezeSuccess(orderPaidFreeze, freezeResponse.Body.Balance);

                Commit();
            }
            else if (freezeResponse.IsWait || freezeResponse.Body?.FreezeState == "U")
            {
                //orderPaid.Status = OrderPaidStatusOption.FrozenWait.ToInt();
                //Save(orderPaid);

                //orderPaidFreeze.Status = OrderPaidFreezeStatusOption.Wait.ToInt();
                //iOrderPaidFreezeService.Save(orderPaidFreeze);

                //当失败处理
                orderPaidFreeze.Status = OrderPaidFreezeStatusOption.Fail.ToInt();
                iOrderPaidFreezeService.Save(orderPaidFreeze);

                Commit();

                throw new APIException("冻结失败中:" + freezeResponse.Head.ResMsg);
            }
            else if (freezeResponse.IsFail || freezeResponse.Body?.FreezeState == "F")
            {
                orderPaidFreeze.Status = OrderPaidFreezeStatusOption.Fail.ToInt();
                iOrderPaidFreezeService.Save(orderPaidFreeze);

                Commit();

                throw new APIException("冻结失败：" + freezeResponse.Head.ResMsg);
            }
        }

        private void UnFreeze(OrderPaid orderPaid)
        {
            //var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();
            var iOrderPaidUnFreezeService = DIFactory.GetContainer().Resolve<IOrderPaidUnFreezeService>();
            var iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();

            OrderPaidUnFreeze orderPaidUnFreeze = new OrderPaidUnFreeze();

            orderPaidUnFreeze.OrderPaid = orderPaid;
            orderPaidUnFreeze.Amount = orderPaid.TransactionAmount;

            iOrderPaidUnFreezeService.Save(orderPaidUnFreeze);
            iOrderPaidUnFreezeService.Commit();

            var unFreezeResponse = iGuangDaAPIService.Unfreeze(orderPaidUnFreeze);

            orderPaidUnFreeze.ResponseCode = unFreezeResponse.Head.ResCode;
            orderPaidUnFreeze.ResponseMessage = unFreezeResponse.Head.ResMsg;

            if (unFreezeResponse.IsOK)
            {
                UnFreezeSuccess(orderPaidUnFreeze);

                Commit();
            }
            //else if (unFreezeResponse.IsWait)
            //{
            //    orderPaid.Status = OrderPaidStatusOption.UnFrozenWait.ToInt();
            //    Save(orderPaid);

            //    orderPaidUnFreeze.Status = OrderPaidUnFreezeStatusOption.Wait.ToInt();
            //    iOrderPaidUnFreezeService.Save(orderPaidUnFreeze);

            //    Commit();

            //    throw new APIException("解冻中，请查询确认（" + unFreezeResponse.Head.ResMsg + "）");
            //}
            else if (unFreezeResponse.IsFail)
            {
                orderPaidUnFreeze.Status = OrderPaidUnFreezeStatusOption.Fail.ToInt();
                iOrderPaidUnFreezeService.Save(orderPaidUnFreeze);

                Commit();

                throw new APIException("解冻失败：" + unFreezeResponse.Head.ResMsg);
            }
        }

        /// <summary>
        /// 平安端：单个订单信息查询
        /// </summary>
        /// <param name="BankOrderNo"></param>
        /// <returns></returns>
        private QueryBatchMarginsOrderDetialResponse QueryPingAnMarginsOrderDetail(string BankOrderNo)
        {
            var iPingAnAPIService = DIFactory.GetContainer().Resolve<IPingAnAPIService>();

            QueryPingAnMarginsOrderListRequest request = new QueryPingAnMarginsOrderListRequest();
            request.bankorderno = BankOrderNo;
            var orderDetailResponse = iPingAnAPIService.QueryBatchMarginsOrderDetial(request);

            return orderDetailResponse as QueryBatchMarginsOrderDetialResponse;
        }

        /// <summary>
        /// 平安订单解止付（查询平安订单状态并判断--解止付）
        /// </summary>
        /// <param name="orderPaid"></param>
        private void PingAnUnFreeze(OrderPaid orderPaid)
        {
            var iPingAnAPIService = DIFactory.GetContainer().Resolve<IPingAnAPIService>();
            var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();
            var iPingAnOrderPaidService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidService>();
            var iPingAnOrderPaidUnFreezeService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidUnFreezeService>();

            PingAnOrderPaidUnFreeze pingAnOrderPaidUnFreeze = new PingAnOrderPaidUnFreeze();

            pingAnOrderPaidUnFreeze.OrderPaid = orderPaid;
            pingAnOrderPaidUnFreeze.Amount = orderPaid.TransactionAmount;

            iPingAnOrderPaidUnFreezeService.Save(pingAnOrderPaidUnFreeze);
            iPingAnOrderPaidUnFreezeService.Commit();

            var orderDetailResponse = QueryPingAnMarginsOrderDetail(orderPaid.PingAnOrderPaid.BankOrderNo);

            if (orderDetailResponse.IsOK)
            {
                if (orderDetailResponse.dataObject.marginsOrderInfoList != null)
                {
                    if (orderDetailResponse.dataObject.marginsOrderInfoList.FirstOrDefault().transStatus == PingAnOrderPaidStatusOption.FrozenSuccess.ToInt().ToString())
                    {
                        var response = iPingAnAPIService.UnFreezeMarginsOrder(orderPaid);

                        pingAnOrderPaidUnFreeze.ResponseCode = response.responseCode;
                        pingAnOrderPaidUnFreeze.ResponseMessage = response.responseMsg;

                        if (response.IsOK)
                        {
                            PingAnUnFreezeSuccess(pingAnOrderPaidUnFreeze);

                            Commit();
                        }
                        else
                        {
                            pingAnOrderPaidUnFreeze.Status = PingAnOrderPaidUnFreezeStatusOption.Fail.ToInt();
                            iPingAnOrderPaidUnFreezeService.Save(pingAnOrderPaidUnFreeze);

                            Commit();

                            throw new APIException("解止付失败：" + response.responseMsg);
                        }
                    }
                    else
                    {
                        throw new APIException("订单状态" + ((PingAnOrderPaidStatusOption)Convert.ToInt32(orderDetailResponse.dataObject.marginsOrderInfoList.FirstOrDefault().transStatus)).ToDescription() + "不可操作");
                    }
                }
            }
            else
            {
                throw new APIException("查询失败：" + orderDetailResponse.responseMsg);
            }
        }

        private void Withdraw(OrderPaid orderPaid)
        {
            //var iOrderPaidService = DIFactory.GetContainer().Resolve<IOrderPaidService>();
            var iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();
            var iOrderPaidWithdrawService = DIFactory.GetContainer().Resolve<IOrderPaidWithdrawService>();

            OrderPaidWithdraw orderPaidWithdraw = new OrderPaidWithdraw();

            orderPaidWithdraw.OrderPaid = orderPaid;
            orderPaidWithdraw.Amount = orderPaid.TransactionAmount;

            iOrderPaidWithdrawService.Save(orderPaidWithdraw);
            iOrderPaidWithdrawService.Commit();

            var withdrawResponse = iGuangDaAPIService.Withdraw(orderPaidWithdraw);

            orderPaidWithdraw.ResponseCode = withdrawResponse.Head.ResCode;
            orderPaidWithdraw.ResponseMessage = withdrawResponse.Head.ResMsg;

            if (withdrawResponse.IsOK)
            {
                WithdrawSuccess(orderPaidWithdraw);

                Commit();
            }
            else if (withdrawResponse.IsWait)
            {
                orderPaid.Status = OrderPaidStatusOption.WithdrawWait.ToInt();
                Save(orderPaid);

                orderPaidWithdraw.Status = OrderPaidWithdrawStatusOption.Wait.ToInt();
                iOrderPaidWithdrawService.Save(orderPaidWithdraw);

                Commit();

                throw new APIException("提现中，请查询确认（" + withdrawResponse.Head.ResMsg + "）");
            }
            else
            {
                WithdrawFail(orderPaidWithdraw);

                Commit();

                throw new APIException("提现失败：" + withdrawResponse.Head.ResMsg);
            }
        }

        /// <summary>
        /// 收银宝订单支付成功后续处理
        /// </summary>
        /// <param name="posOrderQueryResponse"></param>
        /// <param name="orderPaid"></param>
        public void VspOrderHandle(POSOrderQueryResponse posOrderQueryResponse, OrderPaid orderPaid)
        {
            var iPingAnOrderPaidService = DIFactory.GetContainer().Resolve<IPingAnOrderPaidService>();

            if (orderPaid.Merchant.AccountBank == AccountBankOption.PingAn.ToInt())
            {
                if (orderPaid.Status == OrderPaidStatusOption.Default.ToInt())
                {
                    orderPaid.Status = OrderPaidStatusOption.PaySuccess.ToInt();

                    orderPaid.PingAnOrderPaid.POSBaoSerialNumber = posOrderQueryResponse.trxid;

                    iPingAnOrderPaidService.Save(orderPaid.PingAnOrderPaid);
                    Save(orderPaid);

                    Commit();
                }

                //订单支付成功---调代付（代付成功，代付失败，代付中），当代付成功将信息记录到代付表，并更新主订单金额   
                PingAnTltSingleOntimePay(orderPaid);
            }
            else if (orderPaid.Merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
            {
                if (orderPaid.Status == OrderPaidStatusOption.Default.ToInt())
                {
                    orderPaid.Status = OrderPaidStatusOption.PaySuccess.ToInt();

                    Save(orderPaid);

                    Commit();
                }

                RechargeAndFreeze(orderPaid);
            }
        }

        //public void TltServiceInit(OrderPaid orderPaid)
        //{
        //    var iTLTPreferencesService = DIFactory.GetContainer().Resolve<ITLTPreferencesService>();
        //    var iTltService = DIFactory.GetContainer().Resolve<ITltService>();
        //    var TLTPreferences = iTLTPreferencesService.Get(t => t.MerchantID == orderPaid.MerchantID);

        //    iTltService.Init(url, TLTPreferences.TltMerchantId, TLTPreferences.TltUserName, TLTPreferences.TltUserPassword, TLTPreferences.TltPrivateKeyPassword);
        //}

    }
}

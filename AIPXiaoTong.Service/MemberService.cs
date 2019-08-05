﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
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

namespace AIPXiaoTong.Service
{
    public class MemberService : BusinessService<Member>, IMemberService
    {
        public override Expression<Func<Member, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Member, bool>> express = DynamicExpressions.True<Member>();

            var m = model as MemberQM;

            if (!string.IsNullOrWhiteSpace(m.Name))
            {
                express = express.AndAlso(t => t.Name.Contains(m.Name.Trim()));
            }

            if (!string.IsNullOrWhiteSpace(m.Mobile))
            {
                express = express.AndAlso(t => t.Mobile == m.Mobile.Trim());
            }

            if (!string.IsNullOrWhiteSpace(m.IDNumber))
            {
                express = express.AndAlso(t => t.IDNumber == m.IDNumber.Trim());
            }

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            if (currentUser.MerchantID != 0)
            {
                express = express.AndAlso(t => t.MerchantMemberList.Where(w => w.MerchantID == currentUser.MerchantID).Count() != 0);
                // express = express.AndAlso(t => t.OrderPaidList.Where(w => w.MerchantID == currentUser.MerchantID).Count() != 0);
            }

            return express;
        }

        public new void Save(Member e)
        {
            if (e.ID == 0)
            {
                e.ClientId = GuidHelper.To16String();
            }

            base.Save(e);
        }

        public void BalanceChange(Member member, decimal amount, MemberBalanceHistoryTypeOption memberBalanceHistoryTypeOption, AccountBankOption accountBankOption, decimal freezeAmount = 0, string remark = null)
        {
            var iMemberBalanceHistoryService = DIFactory.GetContainer().Resolve<IMemberBalanceHistoryService>();

            MemberBalanceHistory memberBalanceHistory = new MemberBalanceHistory();

            memberBalanceHistory.MemberID = member.ID;
            memberBalanceHistory.ChangeAmount = amount;
            memberBalanceHistory.Type = memberBalanceHistoryTypeOption.ToInt();
            memberBalanceHistory.Remark = remark;
            memberBalanceHistory.AccountBank = accountBankOption.ToInt();

            iMemberBalanceHistoryService.Save(memberBalanceHistory);

            if (accountBankOption == AccountBankOption.GuangDa)
            {
                memberBalanceHistory.Balance = member.AccountGuangDa.Balance + amount;

                member.AccountGuangDa.Balance += amount;

                if (freezeAmount != 0)
                {
                    member.AccountGuangDa.FreezeBalance += freezeAmount;
                }

                Save(member);

                if (member.AccountGuangDa.Balance < 0)
                    throw new Exception("可用余额不能小于0");

                if (member.AccountGuangDa.FreezeBalance < 0)
                    throw new Exception("冻结余额不能小于0");
            }
            if (accountBankOption == AccountBankOption.PingAn)
            {
               // memberBalanceHistory.Balance = member.AccountPingAn.Balance + amount;

               // member.AccountPingAn.Balance += amount;

                if (freezeAmount != 0)
                {
                    member.AccountPingAn.FreezeBalance += freezeAmount;
                }

                Save(member);

                if (member.AccountPingAn.Balance < 0)
                    throw new Exception("可用余额不能小于0");

                if (member.AccountPingAn.FreezeBalance < 0)
                    throw new Exception("冻结余额不能小于0");
            }

        }
    }
}
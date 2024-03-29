﻿using AIPXiaoTong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IMemberService : IBusinessService<Member>
    {
        void BalanceChange(Member member, decimal amount, MemberBalanceHistoryTypeOption memberBalanceHistoryTypeOption, AccountBankOption accountBankOption, decimal freezeAmount = 0, string remark = null);
        //void PingAnBalanceChange(Member member, decimal amount, MemberBalanceHistoryTypeOption memberBalanceHistoryTypeOption, AccountBankOption accountBankOption, decimal freezeAmount = 0, string remark = null);
    }
}

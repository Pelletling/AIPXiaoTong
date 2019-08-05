using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class PingAnOrderPaidUnFreezeService:BusinessService<PingAnOrderPaidUnFreeze>, IPingAnOrderPaidUnFreezeService
    {
        public override void Save(PingAnOrderPaidUnFreeze e)
        {
            if (e.ID == 0)
            {
                e.SerialNumber = GuidHelper.GenUniqueId();

                if (e.OrderPaid.Merchant.AccountBank == AccountBankOption.PingAn.ToInt())
                {
                    if (e.OrderPaid.Member.PingAnFreezeBalance <= 0)
                        throw new Exception("冻结余额（" + e.OrderPaid.Member.PingAnFreezeBalance + "）不足");
                }
            }



            base.Save(e);
        }
    }
}

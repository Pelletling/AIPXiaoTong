using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Common;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class OrderPaidUnFreezeService : BusinessService<OrderPaidUnFreeze>, IOrderPaidUnFreezeService
    {
        public override void Save(OrderPaidUnFreeze e)
        {
            if (e.ID == 0)
            {
                e.SerialNumber = GuidHelper.GenUniqueId();

                if (e.OrderPaid.Merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
                {
                    if (e.OrderPaid.Member.GuangDaFreezeBalance <= 0)
                        throw new Exception("冻结余额（" + e.OrderPaid.Member.GuangDaFreezeBalance + "）不足");
                }
            }



            base.Save(e);
        }

    }
}

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
    public class OrderPaidRechargeService : BusinessService<OrderPaidRecharge>, IOrderPaidRechargeService
    {
        public override void Save(OrderPaidRecharge e)
        {
            if (e.ID == 0)
            {
                e.SerialNumber = GuidHelper.GenUniqueId();
            }

            base.Save(e);
        }

    }
}

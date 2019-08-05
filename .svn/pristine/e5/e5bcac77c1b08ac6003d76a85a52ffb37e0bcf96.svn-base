using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
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
    public class PingAnOrderPaidRechargeService : BusinessService<PingAnOrderPaidRecharge>, IPingAnOrderPaidRechargeService
    {

        public override Expression<Func<PingAnOrderPaidRecharge, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<PingAnOrderPaidRecharge, bool>> express = DynamicExpressions.True<PingAnOrderPaidRecharge>();

            var m = model as OntimePayQM;

            if (!string.IsNullOrWhiteSpace(m.OrderNumber))
            {
                express = express.AndAlso(t => t.OrderPaid.OrderNumber == m.OrderNumber.Trim());
            }
            if (!string.IsNullOrWhiteSpace(m.RechargeName))
            {
                express = express.AndAlso(t => t.OrderPaid.Member.Name == m.RechargeName.Trim());
            }
            if (!string.IsNullOrWhiteSpace(m.RechargeIDNumber))
            {
                express = express.AndAlso(t => t.OrderPaid.Member.IDNumber == m.RechargeIDNumber.Trim());
            }
            if (!string.IsNullOrWhiteSpace(m.BankCardNumber))
            {
                express = express.AndAlso(t => t.BankCardNumber == m.BankCardNumber.Trim());
            }
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            if (m.TransTime != null)
            {
                express = express.AndAlso(t => t.TransTime >= m.TransTime);
            }

            return express;
        }

        public override void Save(PingAnOrderPaidRecharge e)
        {
            if (e.ID == 0)
            {
                e.SerialNumber = GuidHelper.GenUniqueId();
            }

            base.Save(e);
        }
    }
}

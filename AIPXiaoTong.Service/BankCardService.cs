using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class BankCardService : BusinessService<BankCard>, IBankCardService
    {
        public override Expression<Func<BankCard, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<BankCard, bool>> express = DynamicExpressions.True<BankCard>();

            var m = model as BankCardQM;

            if (m.MemberID != null)
            {
                express = express.AndAlso(t => t.MemberID == m.MemberID);
            }

            if (!string.IsNullOrWhiteSpace(m.BankCardNumber))
            {
                express = express.AndAlso(t => t.BankCardNumber == m.BankCardNumber.Trim());
            }

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            return express;
        }

    }
}

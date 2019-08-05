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
    public class MerchantMemberService : BusinessService<MerchantMember>, IMerchantMemberService
    {
        public override Expression<Func<MerchantMember, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<MerchantMember, bool>> express = DynamicExpressions.True<MerchantMember>();

            var m = model as MerchantMemberQM;

          

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

           

            return express;
        }
    }
}

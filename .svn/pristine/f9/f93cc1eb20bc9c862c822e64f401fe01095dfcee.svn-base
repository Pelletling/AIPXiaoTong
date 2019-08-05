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
    public class TLTPreferencesService : BusinessService<TLTPreferences>, ITLTPreferencesService
    {
        public override Expression<Func<TLTPreferences, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<TLTPreferences, bool>> express = DynamicExpressions.True<TLTPreferences>();

            var m = model as TLTPreferencesQM;

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }
            if (currentUser.MerchantID != 0)
            {
                express = express.AndAlso(t => t.Merchant.ID == currentUser.MerchantID);
            }
            if (!string.IsNullOrWhiteSpace(m.MerchantName))
            {
                express = express.AndAlso(t => t.Merchant.Name.Contains(m.MerchantName));
            }

            return express;
        }
    }
}

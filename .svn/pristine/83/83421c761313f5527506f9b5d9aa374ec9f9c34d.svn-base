using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
   public class EquipmentService : BusinessService<Equipment>, IEquipmentService
    {
        public override Expression<Func<Equipment, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Equipment, bool>> express = DynamicExpressions.True<Equipment>();

            var m = model as EquipmentQM;

            if (m.MerchantID != null)
            {
                express = express.AndAlso(t => t.MerchantID == m.MerchantID);
            }

            if (!string.IsNullOrWhiteSpace(m.EquipmentSNNo))
            {
                express = express.AndAlso(t => t.EquipmentSNNo == m.EquipmentSNNo.Trim());
            }

            if (!string.IsNullOrWhiteSpace(m.MerchantName))
            {
                express = express.AndAlso(t => t.Merchant.Name.Contains(m.MerchantName.Trim()));
            }
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            return express;
        }

    }
}

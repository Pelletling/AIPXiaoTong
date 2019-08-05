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
    public class HouseTypeShowService : BusinessService<HouseTypeShow>, IHouseTypeShowService
    {
        public override Expression<Func<HouseTypeShow, bool>> GetExpress<QM>(QM model)
        {

            Expression<Func<HouseTypeShow, bool>> express = DynamicExpressions.True<HouseTypeShow>();

            var m = model as HouseTypeShowQM;

            if (m.ProjectID != null)
            {
                express = express.AndAlso(t => t.ProjectID == m.ProjectID);
            }
            if (m.MerchantID != null)
            {
                express = express.AndAlso(t => t.MerchantID == m.MerchantID);
            }

            if (!string.IsNullOrWhiteSpace(m.HouseTypeName))
            {
                express = express.AndAlso(t => t.HouseTypeName == m.HouseTypeName.Trim());
            }
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }
            if (!string.IsNullOrWhiteSpace(m.ProjetName))
            {
                express = express.AndAlso(t => t.Project.ProjectName == m.ProjetName.Trim());
            }
            if (currentUser.MerchantID != 0)
            {
                express = express.AndAlso(t => t.Merchant.ID == currentUser.MerchantID);
            }

            return express;
        }

    }
}

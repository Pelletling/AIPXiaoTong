using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Common;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Framework.Web.IOC;
using System.Linq.Expressions;
using AIPXiaoTong.Model.Admin;
using Framework.Cache;

namespace AIPXiaoTong.Service
{
    public class RoleService : BusinessService<Role>, IRoleService
    {
        public override Expression<Func<Role, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Role, bool>> express = DynamicExpressions.True<Role>();

            var m = model as RoleQM;

            if (!string.IsNullOrWhiteSpace(m.Name))
            {
                express = express.AndAlso(t => t.Name.Contains(m.Name.Trim()));
            }

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            return express;
        }
    }
}

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
    public class EmployeeRoleService : BusinessService<EmployeeRole>, IEmployeeRoleService
    {
        public override Expression<Func<EmployeeRole, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<EmployeeRole, bool>> express = DynamicExpressions.True<EmployeeRole>();

            var m = model as EmployeeRoleQM;

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

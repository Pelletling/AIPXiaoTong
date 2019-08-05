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
    public class DepartmentService : BusinessService<Department>, IDepartmentService
    {
        public override Expression<Func<Department, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Department, bool>> express = DynamicExpressions.True<Department>();

            var m = model as DepartmentQM;

            if (!string.IsNullOrWhiteSpace(m.Name))
            {
                express = express.AndAlso(t => t.Name.Contains(m.Name.Trim()));
            }

            if (model.Status != null)
            {
                express = express.AndAlso(t => t.Status == model.Status);
            }

            return express;
        }

        public override IList<Department> GetList<QM>(QM model = null)
        {
            var list = base.GetList(model);

            DepartmentOrderBy(list);

            return list;
        }

        private void DepartmentOrderBy(IList<Department> list, long? parentID = null, int level = 1, string parentCode = "")
        {
            int number = 1;
            foreach (var m in list.Where(t => t.ParentID == parentID).OrderBy(t => t.Name))
            {
                m.LevelCode = parentCode + number.ToString().PadLeft(3, '0');
                m.OrderByName = "".PadLeft(m.LevelCode.Length - 3, '-') + m.Name;
                if (list.Any(t => t.ParentID == m.ID))
                {
                    DepartmentOrderBy(list, m.ID, level + 1, m.LevelCode);
                }
                number++;
            }
        }
    }
}

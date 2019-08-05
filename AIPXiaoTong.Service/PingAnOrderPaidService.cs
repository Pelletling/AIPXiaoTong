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
    public class PingAnOrderPaidService:BusinessService<PingAnOrderPaid>, IPingAnOrderPaidService
    {
        public override Expression<Func<PingAnOrderPaid, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<PingAnOrderPaid, bool>> express = DynamicExpressions.True<PingAnOrderPaid>();

            var m = model as PingAnOrderPaidQM;

            //if (!string.IsNullOrWhiteSpace(m.OrderNumber))
            //{
            //    express = express.AndAlso(t => t.OrderNumber == m.OrderNumber.Trim());
            //}
            //if (!string.IsNullOrWhiteSpace(m.MemberMobile))
            //{
            //    express = express.AndAlso(t => t.Member.Mobile == m.MemberMobile.Trim());
            //}
            //if (!string.IsNullOrWhiteSpace(m.MemberName))
            //{
            //    express = express.AndAlso(t => t.Member.Name.Contains(m.MemberName.Trim()));
            //}
            //if (m.ProjectID != null)
            //{
            //    express = express.AndAlso(t => t.ProjectID == m.ProjectID);
            //}
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }
         
          
            return express;
        }
    }
}

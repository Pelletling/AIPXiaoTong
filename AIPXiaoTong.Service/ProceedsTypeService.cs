using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class ProceedsTypeService : BusinessService<ProceedsType>, IProceedsTypeService
    {
        public override Expression<Func<ProceedsType, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<ProceedsType, bool>> express = DynamicExpressions.True<ProceedsType>();

            var m = model as ProceedsTypeQM;
          

            //if (!string.IsNullOrWhiteSpace(m.EquipmentNo))
            //{
            //    express = express.AndAlso(t => t.EquipmentNo == m.EquipmentNo.Trim());
            //}
            //if (!string.IsNullOrWhiteSpace(m.EquipmentSNNo))
            //{
            //    express = express.AndAlso(t => t.EquipmentSNNo == m.EquipmentSNNo.Trim());
            //}

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }

            return express;
        }
    }
}

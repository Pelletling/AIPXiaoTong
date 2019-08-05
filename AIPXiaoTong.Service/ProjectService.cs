﻿using AIPXiaoTong.IService;
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
    public class ProjectService : BusinessService<Project>, IProjectService
    {
        public override Expression<Func<Project, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Project, bool>> express = DynamicExpressions.True<Project>();

            var m = model as ProjectQM;

            if (!string.IsNullOrWhiteSpace(m.ProjectName))
            {
                express = express.AndAlso(t => t.ProjectName.Contains(m.ProjectName.Trim()));
            }
            if (m.MerchantID != null)
            {
                express = express.AndAlso(t => t.MerchantID == m.MerchantID);
            }
            if (m.Deadline != null)
            {
                express = express.AndAlso(t => t.Deadline >= m.Deadline);
            }
            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }
            if (currentUser.MerchantID != 0)    //商户客户端登录，会先获取到登录人员对应的商户ID，则此查询只查询该商户下项目（后台ADMIN则可查询所有）
            {
                express = express.AndAlso(t => t.Merchant.ID == currentUser.MerchantID);
            }

            return express;
        }
    }
}
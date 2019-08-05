﻿using AIPXiaoTong.IService;
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
    public class MerchantService : BusinessService<Merchant>, IMerchantService
    {
        public new void Save(Merchant e)
        {

            if (e.ID == 0)
            {
                var iEmployeeService = DIFactory.GetContainer().Resolve<IEmployeeService>();

                Employee merUser = new Employee()
                {
                    Code = "admin",
                    Name = e.Contact,
                    Password = Framework.Security.Crypt.MD5(e.Code) ,
                    IsAdmin = 1,
                    Status = EmployeeStatusOption.Enable.ToInt(),
                };
                iEmployeeService.Save(merUser);
            }


            base.Save(e);
        }
        public override Expression<Func<Merchant, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Merchant, bool>> express = DynamicExpressions.True<Merchant>();

            var m = model as MerchantQM;

            if (!string.IsNullOrWhiteSpace(m.Code))
            {
                express = express.AndAlso(t => t.Code.Contains(m.Code.Trim()));
            }

            if (!string.IsNullOrWhiteSpace(m.Name))
            {
                express = express.AndAlso(t => t.Name.Contains(m.Name.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(m.Mobile))
            {
                express = express.AndAlso(t => t.Mobile==m.Mobile.Trim());
            }

            if (m.Status != null)
            {
                express = express.AndAlso(t => t.Status == m.Status);
            }


            return express;
        }
    }
}
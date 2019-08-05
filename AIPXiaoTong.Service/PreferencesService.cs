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
    public class PreferencesService: BusinessService<Preferences>, IPreferencesService
    {
        public override Expression<Func<Preferences, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Preferences, bool>> express = DynamicExpressions.True<Preferences>();

            var m = model as PreferencesQM;
                  
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

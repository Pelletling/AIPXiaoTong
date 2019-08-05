using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Cache;
using Framework.Common;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class AccountGuangDaService : BusinessService<AccountGuangDa>, IAccountGuangDaService
    {
        public override void Save(AccountGuangDa e)
        {
            if (e.ID == 0)
            {
                e.CoPatrnerJnlNo = GuidHelper.GenUniqueId();
                e.BookDate = DateTime.Now;
            }

            base.Save(e);
        }
    }
}

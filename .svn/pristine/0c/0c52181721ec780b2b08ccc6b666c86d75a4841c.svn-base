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
using Framework.Models;

namespace AIPXiaoTong.Service
{
    public class EmployeeMenuActionService : BusinessService<EmployeeMenuAction>, IEmployeeMenuActionService
    {
        public void SetCache()
        {
            var list = Gets(t => t.Status > 0).Select(
                t => new ActionModel
                {
                    Controller = t.EmployeeMenu.Controller.ToLower(),
                    Action = t.Code.ToLower(),
                }).ToList<ActionModel>();

            CacheHelper.SetCache(CacheKey.MenuAction.ToString(), list, DateTime.Now.AddYears(100));
        }
    }
}

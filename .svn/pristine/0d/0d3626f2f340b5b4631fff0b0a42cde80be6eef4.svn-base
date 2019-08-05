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
    public class MenuService : BusinessService<Menu>, IMenuService
    {
        public override Expression<Func<Menu, bool>> GetExpress<QM>(QM model)
        {
            Expression<Func<Menu, bool>> express = DynamicExpressions.True<Menu>();

            if (model.Status == null)
            {
                express = express.AndAlso(t => t.Status == 1);
            }
            else
            {
                express = express.AndAlso(t => t.Status == model.Status);
            }

            return express;
        }

        public IList<Menu> GetUserMenuList()
        {
            var list = new List<Menu>();
            var iUserService = DIFactory.GetContainer().Resolve<IUserService>();
            var iMenuService = DIFactory.GetContainer().Resolve<IMenuService>();
            var iMenuActionService = DIFactory.GetContainer().Resolve<IMenuActionService>();

            var user = iUserService.Get(t => t.ID == currentUser.ID);
            if (user != null)
            {
                if (user.IsAdmin)
                {
                    return GetList(new MenuQM() { PageSize = Int32.MaxValue });
                }
                else if (user.Role != null && !string.IsNullOrWhiteSpace(user.Role.MenuActions))
                {
                    var actionArray = user.Role.MenuActions.ToLongList();
                    var actionList = iMenuActionService.Gets(t => actionArray.Contains(t.ID) && t.Code == "Index").ToList();
                    foreach (var m in actionList)
                    {
                        list.Add(m.Menu);
                        if (list.FirstOrDefault(t => t.Code == m.Menu.Code.Substring(0, 6)) == null)
                        {
                            list.Add(this.Get(t => t.Code == m.Menu.Code.Substring(0, 6)));
                        }
                        if (list.FirstOrDefault(t => t.Code == m.Menu.Code.Substring(0, 3)) == null)
                        {
                            list.Add(this.Get(t => t.Code == m.Menu.Code.Substring(0, 3)));
                        }
                    }
                }
            }
            return list;
        }



        public void SetCache()
        {
            var list = GetAllListModel<MenuLM, MenuQM>();

            CacheHelper.SetCache(CacheKey.Menu.ToString(), list, DateTime.Now.AddYears(100));
        }
    }
}

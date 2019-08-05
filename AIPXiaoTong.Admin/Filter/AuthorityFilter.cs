using AIPXiaoTong.Model;
using Framework.Cache;
using Framework.Common;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AIPXiaoTong.Admin
{
    /// <summary>
    /// ajax跟exception一致
    /// 检验登陆和权限的filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class AuthorityFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 未登录时返还的地址
        /// </summary>
        private string _LoginPath = "";
        public AuthorityFilter()
        {
            this._LoginPath = "/Login/Index";
        }

        public AuthorityFilter(string loginPath)
        {
            this._LoginPath = loginPath;
        }

        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;//表示支持控制器、action的AllowAnonymousAttribute
            }

            //var currentUser = HttpContext.Current.Session["CurrentUser"] as CurrentUser;//使用session

            var currentUser = UserHelper.GetCurrentUser();

            //检查权限
            var RouteData = RouteTable.Routes.GetRouteData(filterContext.HttpContext);
            string controller = RouteData.Values["controller"].ToString().ToLower();
            string action = RouteData.Values["action"].ToString().ToLower();


            //也可以使用数据库、nosql等介质
            if (currentUser == null)
            {
                HttpContext.Current.Session["CurrentUrl"] = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(this._LoginPath);
                return;
            }

            //获取全部需要控制权限的操作
            List<ActionModel> allAction = CacheHelper.GetCache(CacheKey.MenuAction.ToString()) as List<ActionModel>;

            if (allAction == null)
            {
                throw new Exception("权限获取失败,请联系管理员");
            }
            
            currentUser.CurrnetAction.Clear();
            currentUser.CurrnetAction.AddRange(currentUser.AllAction.Where(t => t.Controller == controller).Select(t => t.Action));

            //判断当前的操作在不在控制的范围内，需要控制才判断是否具有操作的权限
            if (allAction.Any(t => t.Controller == controller && t.Action == action) && !currentUser.CurrnetAction.Contains(action))
            {
                throw new Exception("没有可操作的权限");
            }

            UserHelper.SetCurrentUser(currentUser);
        }

    }
}
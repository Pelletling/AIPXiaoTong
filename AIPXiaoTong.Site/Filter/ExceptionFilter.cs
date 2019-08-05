using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site
{
    /// <summary>
    /// 捕获所有异常
    /// </summary>
    public class ExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {

            //1.0获取异常信息
            Exception exp = filterContext.Exception;

            //2.0 将信息写入日志或者db中方便查询
            // System.IO.File.AppendAllText(filterContext.HttpContext.Server.MapPath("/Log/log.txt"), exp.ToString());

            //3.0 通知MVC框架，现在这个异常已经被我处理掉，你不需要将黄页显示给用户
            filterContext.ExceptionHandled = true;
            
            //4.0 跳转到错误提醒页面
            //filterContext.Result
            filterContext.HttpContext.Response.Redirect("/Login/Error", true);

            base.OnException(filterContext);
        }
    }
}
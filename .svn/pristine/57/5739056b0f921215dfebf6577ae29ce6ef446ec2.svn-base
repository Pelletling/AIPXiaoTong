using AIPXiaoTong.Model;
using Framework.Common;
using Framework.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class BaseController : Controller
    {
        public ILogger logger;

        public CurrentUser currentUser;

        public BaseController()
        {
            currentUser = UserHelper.GetCurrentUser();
            logger = LogManager.GetCurrentClassLogger();
        }
        public void AddError(ErrorCode code, string message = null)
        {
            TempData["DisplayError"] = !string.IsNullOrWhiteSpace(message) ? message : code.ToDescription();
        }

        protected void AddError()
        {
            foreach (var m in ModelState.Values.Where(t => t.Errors.Count > 0))
            {
                AddError(ErrorCode.Exception, m.Errors.FirstOrDefault().ErrorMessage);
            }
        }

        public void ShowTip()
        {
            TempData["DisplaySuccess"] = "1";
        }

        public void Log(string msg)
        {
            logger.Trace("ThreadID:" + System.Threading.Thread.CurrentThread.ManagedThreadId + "|" + msg);
        }
    }
}
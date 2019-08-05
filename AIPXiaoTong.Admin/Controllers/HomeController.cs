using AIPXiaoTong.IService;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IMenuService iMenuService;

        public HomeController(IMenuService iMenuService)
        {
            this.iMenuService = iMenuService;
        }

        public ActionResult Index()
        {
            ViewBag.UserMenuList = iMenuService.GetUserMenuList();

            return View();
        }

        public ActionResult Logout()
        {
            UserHelper.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
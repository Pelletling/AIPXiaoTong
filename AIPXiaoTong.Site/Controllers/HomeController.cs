using AIPXiaoTong.IService;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    public class HomeController : BaseController
    {
        public IEmployeeMenuService iEmployeeMenuService;
        public IEmployeeService iEmployeeService;

        public HomeController(IEmployeeMenuService iEmployeeMenuService,
                              IEmployeeService iEmployeeService)
        {
            this.iEmployeeMenuService = iEmployeeMenuService;
            this.iEmployeeService = iEmployeeService;
        }

        public ActionResult Index()
        {
            ViewBag.UserMenuList = iEmployeeMenuService.GetEmployeeMenuList();

            ViewBag.Employee = iEmployeeService.Get(t => t.ID == currentUser.ID);

            return View();
        }


        public ActionResult Logout()
        {
            UserHelper.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
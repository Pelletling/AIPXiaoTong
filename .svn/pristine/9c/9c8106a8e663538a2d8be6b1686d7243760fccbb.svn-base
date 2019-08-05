using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        IEmployeeService iEmployeeService;
        public LoginController(IEmployeeService iEmployeeService)
        {
            this.iEmployeeService = iEmployeeService;
        }

        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
           
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                LoginStatus loginStatus = iEmployeeService.Login(model);
                if (LoginStatus.Success == loginStatus)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", loginStatus.ToDescription());
                }
            }

            return View(model);
        }

        public PartialViewResult Error()
        {
            return PartialView();
        }
    }
}
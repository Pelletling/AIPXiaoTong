using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IUserService iUserService;
        public LoginController(IUserService iUserService)
        {
            this.iUserService = iUserService;
        }

        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            model.UserCode = "admin";

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                LoginStatus loginStatus = iUserService.Login(model);
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
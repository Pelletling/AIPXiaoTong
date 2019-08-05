using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.Common;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class UserController : BaseController
    {
        private IUserService iUserService;
        private IDepartmentService iDepartmentService;
        private IRoleService iRoleService;
        public UserController(IUserService iUserService,
            IDepartmentService iDepartmentService,
            IRoleService iRoleService)
        {
            this.iUserService = iUserService;
            this.iDepartmentService = iDepartmentService;
            this.iRoleService = iRoleService;
        }


        public ActionResult Index(UserQM model)
        {
            var list = this.iUserService.GetListModel<UserLM, UserQM>(model);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }
            else
            {
                BindData();
            }


            //Expression<Func<User, UserLM>> ex = t => new UserLM()
            //{
            //    ID = t.ID,
            //    Code = t.Code,
            //    Name=t.Name,
            //    RoleName = t.Role.Name,
            //    DepartmentName = t.Department.Name
            //};

            //var query = this.iUserService.Gets().Select(ex).ToList();


            return View(list);
        }

        private void BindData()
        {
            ViewBag.RoleList = iRoleService.GetListModel<RoleLM, RoleQM>();

            ViewBag.DepartmentList = iDepartmentService.GetListModel<DepartmentLM, DepartmentQM>();
            
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iUserService.GetViewModel<UserCM>(ID);

            BindData();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(UserCM m)
        {
            BindData();
            var entity = iUserService.Get(m.ID) ?? new User();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.Code = m.Code.Trim();
                    entity.Name = m.Name.Trim();
                    entity.DepartmentID = m.DepartmentID;
                    entity.RoleID = m.RoleID;
                    entity.IsMore = m.IsMore;
                    entity.AuthDepartmentIDs = m.AuthDepartmentIDArray == null ? null : string.Join(",", m.AuthDepartmentIDArray);
                    entity.Email = m.Email.ToTrim();
                    entity.Mobile = m.Mobile.ToTrim();
                    entity.Status = m.Status;
                    //entity.Job = m.Job.ToInt();

                    if (entity.ID == 0)
                    {
                        entity.Password = Framework.Security.Crypt.MD5(m.Password.Trim());
                    }

                    iUserService.Save(entity);
                    iUserService.Commit();
                    
                    this.ShowTip();

                    return RedirectToAction("Create", new { ID = entity.ID });
                }
                else
                {
                    AddError();
                }
            }
            catch (Exception ex)
            {
                this.AddError(ErrorCode.Exception, ex.Message);
            }

            return View(m);

        }



        public JsonResult CodeIsExists(long ID, string Code)
        {
            return Json(!iUserService.Exists(t => t.ID != ID && t.Code == Code.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult NameIsExists(long ID, string Name)
        {
            return Json(!iUserService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmailIsExists(long ID, string Email)
        {
            return Json(!iUserService.Exists(t => t.ID != ID && t.Email == Email.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iUserService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModifyPassword(long id)
        {
            var user = iUserService.Get(id);

            if (user == null)
                throw new Exception("ID(" + id + ")不存在");

            ModifyPasswordCM cm = new ModifyPasswordCM();

            cm.ID = user.ID;

            return View(cm);
        }

        [HttpPost]
        public ActionResult ModifyPassword(ModifyPasswordCM cm)
        {
            try
            {
                var user = iUserService.Get(cm.ID);

                if (user == null)
                    throw new Exception("ID(" + cm.ID + ")不存在");

                if (ModelState.IsValid)
                {
                    if (user.Password != Framework.Security.Crypt.MD5(cm.OriginalPassword))
                    {
                        throw new Exception("原密码不正确");
                    }

                    user.Password = Framework.Security.Crypt.MD5(cm.NewPassword);
                    iUserService.Save(user);
                    iUserService.Commit();
                    this.ShowTip();
                }
                else
                {
                    AddError();
                }
            }
            catch (Exception ex)
            {
                this.AddError(ErrorCode.Exception, ex.Message);
            }

            return RedirectToAction("ModifyPassword", new { ID = cm.ID });
        }


        public JsonResult IDNumberVerify(string IDNumber)
        {
            return Json(StringHelper.IsIDNumber(IDNumber), JsonRequestBehavior.AllowGet);
        }

    }
}
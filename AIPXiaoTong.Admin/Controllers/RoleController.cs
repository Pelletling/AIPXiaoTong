using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class RoleController : BaseController
    {

        private IRoleService iRoleService;
        private IMenuService iMenuService;

        public RoleController(IRoleService iRoleService, IMenuService iMenuService)
        {
            this.iRoleService = iRoleService;
            this.iMenuService = iMenuService;
        }

        public ActionResult Index(RoleQM model)
        {
            var list = this.iRoleService.GetListModel<RoleLM, RoleQM>(model);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }
            else
            {
                BindData();
            }

            return View(list);
        }

        private void BindData()
        {
            ViewBag.MenuList = iMenuService.GetAllList<MenuQM>();
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iRoleService.GetViewModel<RoleCM>(ID);

            BindData();

            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(RoleCM m)
        {
            BindData();
            var entity = iRoleService.Get(m.ID) ?? new Role();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.Name = m.Name;
                    entity.MenuActions = m.ActionIDList.Count > 0 ? string.Join(",", m.ActionIDList) : "";
                    entity.Menus = m.MenuIDList.Count > 0 ? string.Join(",", m.MenuIDList) : "";

                    iRoleService.Save(entity);

                    iRoleService.Commit();

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

            return RedirectToAction("Create", new { ID = entity.ID });

        }

        public JsonResult NameIsExists(long ID, string Name)
        {
            return Json(!iRoleService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iRoleService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
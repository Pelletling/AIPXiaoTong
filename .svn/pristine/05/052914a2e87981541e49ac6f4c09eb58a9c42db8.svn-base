using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    public class EmployeeRoleController : BaseController
    {
        private IEmployeeRoleService iEmployeeRoleService;
        private IEmployeeMenuService iEmployeeMenuService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;

        public EmployeeRoleController(IEmployeeRoleService iEmployeeRoleService,
                                       IEmployeeMenuService iEmployeeMenuService,
                                       IEmployeeService iEmployeeService,
                                       IMerchantService iMerchantService)
        {
            this.iEmployeeRoleService = iEmployeeRoleService;
            this.iEmployeeMenuService = iEmployeeMenuService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;

        }
        public ActionResult Index(EmployeeRoleQM model)
        {
            var list = this.iEmployeeRoleService.GetListModel<EmployeeRoleLM, EmployeeRoleQM>(model);

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {
            ViewBag.EmployeeMenuList = iEmployeeMenuService.GetAllList<EmployeeMenuQM>();

            var empInfo = iEmployeeService.Get(currentUser.ID) ?? new Employee();

            ViewBag.merInfo = iMerchantService.Get(empInfo.MerchantID);
        }


        public ActionResult Create(long? ID = null)
        {
            var model = iEmployeeRoleService.GetViewModel<EmployeeRoleCM>(ID);

            BindData();

            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(EmployeeRoleCM m)
        {
            BindData();
            var entity = iEmployeeRoleService.Get(m.ID) ?? new EmployeeRole();

            try
            {
                if (ModelState.IsValid)
                {
                    var empInfo = iEmployeeService.Get(currentUser.ID);

                    entity.MerchantID = empInfo.MerchantID;

                    entity.Name = m.Name;
                    entity.MenuActions = m.EmployeeActionIDList.Count > 0 ? string.Join(",", m.EmployeeActionIDList) : "";
                    entity.Menus = m.EmployeeMenuIDList.Count > 0 ? string.Join(",", m.EmployeeMenuIDList) : "";

                    iEmployeeRoleService.Save(entity);

                    iEmployeeRoleService.Commit();

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
            return Json(!iEmployeeRoleService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iEmployeeRoleService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
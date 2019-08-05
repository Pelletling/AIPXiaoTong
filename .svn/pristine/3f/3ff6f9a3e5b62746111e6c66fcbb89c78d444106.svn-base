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
    public class EmployeeDepartmentController : BaseController
    {
        private IEmployeeDepartmentService iEmployeeDepartmentService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;

        public EmployeeDepartmentController(IEmployeeDepartmentService iEmployeeDepartmentService,
                                             IEmployeeService iEmployeeService,
                                             IMerchantService iMerchantService)
        {
            this.iEmployeeDepartmentService = iEmployeeDepartmentService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
        }

        public ActionResult Index(EmployeeDepartmentQM model)
        {
            var list = this.iEmployeeDepartmentService.GetAllListModel<EmployeeDepartmentLM, EmployeeDepartmentQM>(model);

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {
            ViewBag.DepartmentList = iEmployeeDepartmentService.GetUseListModel<EmployeeDepartmentLM, EmployeeDepartmentQM>();

            var empInfo = iEmployeeService.Get(currentUser.ID) ?? new Employee();

            ViewBag.merInfo = iMerchantService.Get(empInfo.MerchantID);
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iEmployeeDepartmentService.GetViewModel<EmployeeDepartmentCM>(ID);

            BindData();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDepartmentCM m)
        {
            BindData();
            var entity = iEmployeeDepartmentService.Get(m.ID) ?? new EmployeeDepartment();

            try
            {
                if (ModelState.IsValid)
                {
                    var empInfo = iEmployeeService.Get(currentUser.ID);

                    entity.MerchantID = empInfo.MerchantID;

                    entity.Name = m.Name;
                    entity.ParentID = m.ParentID;
                    entity.Status = 1;

                    iEmployeeDepartmentService.Save(entity);

                    iEmployeeDepartmentService.Commit();

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
            return Json(!iEmployeeDepartmentService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iEmployeeDepartmentService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
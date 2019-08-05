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
    public class DepartmentController : BaseController
    {
        private IDepartmentService iDepartmentService;

        public DepartmentController(IDepartmentService iDepartmentService)
        {
            this.iDepartmentService = iDepartmentService;
        }

        public ActionResult Index(DepartmentQM model)
        {
            var list = this.iDepartmentService.GetAllListModel<DepartmentLM, DepartmentQM>(model);

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
            ViewBag.DepartmentList = iDepartmentService.GetUseListModel<DepartmentLM, DepartmentQM>();
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iDepartmentService.GetViewModel<DepartmentCM>(ID);

            BindData();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DepartmentCM m)
        {
            BindData();
            var entity = iDepartmentService.Get(m.ID) ?? new Department();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.Name = m.Name;
                    entity.ParentID = m.ParentID;
                    entity.Status = 1;

                    iDepartmentService.Save(entity);

                    iDepartmentService.Commit();

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
            return Json(!iDepartmentService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iDepartmentService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
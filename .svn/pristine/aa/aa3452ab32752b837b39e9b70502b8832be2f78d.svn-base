using AIPXiaoTong.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIPXiaoTong.IService;
using AIPXiaoTong.Model;

namespace AIPXiaoTong.Admin.Controllers
{
    public class EquipmentController : BaseController
    {
        private IEquipmentService iEquipmentService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;

        public EquipmentController(IEquipmentService iEquipmentService,
                                    IEmployeeService iEmployeeService,
                                    IMerchantService iMerchantService)
        {
            this.iEquipmentService = iEquipmentService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
        }

        public ActionResult Index(EquipmentQM model)
        {
            var list = this.iEquipmentService.GetListModel<EquipmentLM, EquipmentQM>(model);

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {
            ViewBag.MerchantList = iMerchantService.GetListModel<MerchantLM, MerchantQM>();
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iEquipmentService.GetViewModel<EquipmentCM>(ID);

            BindData();

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(EquipmentCM m)
        {
            var entity = iEquipmentService.Get(m.ID) ?? new Equipment();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.MerchantID = m.MerchantID;                 
                    entity.EquipmentSNNo = m.EquipmentSNNo;
                    entity.Status = m.Status;

                    iEquipmentService.Save(entity);
                    iEquipmentService.Commit();

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


        public JsonResult Delete(long ID)
        {
            var result = iEquipmentService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
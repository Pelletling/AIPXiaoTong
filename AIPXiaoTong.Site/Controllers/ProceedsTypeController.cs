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
    public class ProceedsTypeController : BaseController
    {
        private IProceedsTypeService iProceedsTypeService;
        private IMerchantService iMerchantService;


        public ProceedsTypeController(IProceedsTypeService iProceedsTypeService,
                                       IMerchantService iMerchantService)
        {
            this.iProceedsTypeService = iProceedsTypeService;
            this.iMerchantService = iMerchantService;
        }


        public ActionResult Index(ProceedsTypeQM model)
        {
            var list = this.iProceedsTypeService.GetListModel<ProceedsTypeLM, ProceedsTypeQM>(model);

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
            var model = iProceedsTypeService.GetViewModel<ProceedsTypeCM>(ID);

            BindData();

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProceedsTypeCM m)
        {
            var entity = iProceedsTypeService.Get(m.ID) ?? new ProceedsType();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.MerchantID = m.MerchantID;
                    entity.Type = m.Type;

                    iProceedsTypeService.Save(entity);
                    iProceedsTypeService.Commit();

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
            var result = iProceedsTypeService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
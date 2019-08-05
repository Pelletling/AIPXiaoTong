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
    public class PreferencesController : BaseController
    {
        private IPreferencesService iPreferencesService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;

        public PreferencesController(IPreferencesService iPreferencesService,
                                     IEmployeeService iEmployeeService,
                                     IMerchantService iMerchantService)
        {
            this.iPreferencesService = iPreferencesService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
        }

        public ActionResult Index(PreferencesQM model)
        {
            var list = this.iPreferencesService.GetListModel<PreferencesLM, PreferencesQM>(model);

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
            BindData();

            var model = iPreferencesService.GetViewModel<PreferencesCM>(ID);

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PreferencesCM m)
        {
            var entity = iPreferencesService.Get(m.ID) ?? new Preferences();

            try
            {
                if (ModelState.IsValid)
                {
                    if (m.ID==0 && iPreferencesService.Exists(t => t.MerchantID == m.MerchantID))
                        throw new Exception("该商户参数已配置");

                    entity.MerchantID = m.MerchantID;

                    entity.APPID = m.APPID.Trim();
                    entity.POSBaoMerchant = m.POSBaoMerchant.Trim();
                    entity.POSBaoKey = m.POSBaoKey;


                    iPreferencesService.Save(entity);

                    iPreferencesService.Commit();

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
            var result = iPreferencesService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
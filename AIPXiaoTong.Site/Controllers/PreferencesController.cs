﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
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

        //public ActionResult Index(PreferencesQM model)
        //{
        //    var list = this.iPreferencesService.GetListModel<PreferencesLM, PreferencesQM>(model);

        //    if (Request.IsAjaxRequest())
        //    {
        //        return PartialView("Grid", list);
        //    }

        //    return View(list);
        //}

        private void BindData()
        {
            var merchant = this.iMerchantService.Get(t => t.ID == currentUser.MerchantID);

            ViewBag.MerchantInfo = merchant.Name;
        }

        public ActionResult Create(long? ID = null)
        {
            BindData();

            var preferences = this.iPreferencesService.Get(t => t.MerchantID == currentUser.MerchantID);

            var model = iPreferencesService.GetViewModel<PreferencesCM>(preferences?.ID);

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
                    entity.MerchantID = currentUser.MerchantID;

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

        //public JsonResult CodeIsExists(long ID, string MerchantInfo)
        //{
        //    return Json(!iPreferencesService.Exists(t => t.ID != ID && t.MerchantInfo == MerchantInfo.Trim()), JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Delete(long ID)
        //{
        //    var result = iPreferencesService.AjaxDelete(ID);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

    }
}
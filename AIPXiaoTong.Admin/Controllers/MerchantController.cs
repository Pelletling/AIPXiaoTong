﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Common;
using System.ComponentModel;

namespace AIPXiaoTong.Admin.Controllers
{
    public class MerchantController : BaseController
    {

        private IMerchantService iMerchantService;

        public MerchantController(IMerchantService iMerchantService)
        {
            this.iMerchantService = iMerchantService;
        }

        public ActionResult Index(MerchantQM model)
        {
            var list = this.iMerchantService.GetListModel<MerchantLM, MerchantQM>(model);

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
            ViewBag.AccountBankOption = EnumHelper.EnumToList<AccountBankOption>();
        }


        public ActionResult Create(long? ID = null)
        {
            var model = iMerchantService.GetViewModel<MerchantCM>(ID);

            BindData();

            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(MerchantCM m)
        {
            BindData();
            var entity = iMerchantService.Get(m.ID) ?? new Merchant();

            try
            {
                if (ModelState.IsValid)
                {
                    entity.Code = m.Code.Trim();
                    entity.Name = m.Name.Trim();
                    entity.Mobile = m.Mobile.ToTrim();
                    entity.Contact = m.Contact.ToTrim();
                    entity.AccountBank = m.AccountBank;

                    iMerchantService.Save(entity);

                    iMerchantService.Commit();

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

        public JsonResult CodeIsExists(long ID, string Code)
        {
            return Json(!iMerchantService.Exists(t => t.ID != ID && t.Code == Code.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult NameIsExists(long ID, string Name)
        {
            return Json(!iMerchantService.Exists(t => t.ID != ID && t.Name == Name.Trim()), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long ID)
        {
            var result = iMerchantService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
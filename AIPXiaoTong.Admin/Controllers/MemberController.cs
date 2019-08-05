﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class MemberController : BaseController
    {
        private IMemberService iMemberService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;
        private IGuangDaAPIService iGuangDaAPIService;
        private IAccountPingAnService iAccountPingAnService;
        private IMerchantMemberService iMerchantMemberService;

        public MemberController(IMemberService iMemberService,
                                           IEmployeeService iEmployeeService,
                                           IMerchantService iMerchantService,
                                           IProjectService iProjectService,
                                           IGuangDaAPIService iGuangDaAPIService,
                                           IAccountPingAnService iAccountPingAnService,
                                           IMerchantMemberService iMerchantMemberService)
        {
            this.iMemberService = iMemberService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
            this.iProjectService = iProjectService;
            this.iGuangDaAPIService = iGuangDaAPIService;
            this.iAccountPingAnService = iAccountPingAnService;
            this.iMerchantMemberService = iMerchantMemberService;
        }

        public ActionResult Index(MemberQM model)
        {
            var list = this.iMemberService.GetListModel<MemberLM, MemberQM>(model);

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {
            ViewBag.ProjectList = iProjectService.GetListModel<ProjectLM, ProjectQM>();
        }

        public ActionResult Details(long? ID = null)
        {
            var model = iMemberService.GetViewModel<MemberDM>(ID);

            return View(model);
        }

        public JsonResult QueryBalanceGuangDa(long? id)
        {
            QueryBalanceJM result = new QueryBalanceJM();
            try
            {
                var member = iMemberService.Get(t => t.ID == id);

                if (member == null)
                    throw new Exception("会员(" + id + ")不存在");

                var response = iGuangDaAPIService.BCifAcNoAmount(member.ClientId);

                if (response.IsOK)
                {
                    result.Balance = response.Body.AvailBlance;
                    result.UseBalance = response.Body.AcNoBlance;
                    result.FreezeBalance = result.Balance - result.UseBalance;
                }
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.ToString();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDetail(long? ID = null)
        {
            var model = iMemberService.GetViewModel<MemberCM>(ID);
            var merchantMember = iMerchantMemberService.Get(t => t.MemberID == ID);
            if (merchantMember != null)
            {
                ViewBag.MerchantInfo = iMerchantService.Get(t => t.ID == merchantMember.MerchantID);
            }

            BindData();

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddDetail(MemberCM m)
        {
            try
            {
                BindData();

                if (ModelState.IsValid)
                {
                    if (m.AccountPingAn != null)
                    {
                        var entity = iMemberService.Get(t => t.ID == m.ID);

                        entity.AccountPingAn.BankCode = m.AccountPingAn.BankCode;
                        entity.AccountPingAn.BankName = m.AccountPingAn.BankName;
                        entity.AccountPingAn.AccountType = m.AccountPingAn.AccountType;
                        entity.AccountPingAn.Province = m.AccountPingAn.Province;
                        entity.AccountPingAn.City = m.AccountPingAn.City;
                        entity.AccountPingAn.AccountProp = m.AccountPingAn.AccountProp;
                        entity.AccountPingAn.UnionBank = m.AccountPingAn.UnionBank;

                        iMemberService.Save(entity);
                        iMemberService.Commit();

                        this.ShowTip();

                        return RedirectToAction("AddDetail", new { ID = entity.ID });
                    }
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
    }
}
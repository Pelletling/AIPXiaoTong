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
    public class MemberManagementController : BaseController
    {
        private IMemberService iMemberManagementService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;

        public MemberManagementController(IMemberService iMemberManagementService,
                                           IEmployeeService iEmployeeService,
                                           IMerchantService iMerchantService,
                                           IProjectService iProjectService)
        {
            this.iMemberManagementService = iMemberManagementService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
            this.iProjectService = iProjectService;
        }

        public ActionResult Index(MemberQM model)
        {
            var list = this.iMemberManagementService.GetListModel<MemberLM, MemberQM>(model);       

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {
            var empInfo = iEmployeeService.Get(currentUser.ID) ?? new Employee();

            ViewBag.merInfo = iMerchantService.Get(empInfo.MerchantID);

            ViewBag.ProjectList = iProjectService.GetListModel<ProjectLM, ProjectQM>();
        }

        public ActionResult Details(long? ID = null)
        {
            var model = iMemberManagementService.GetViewModel<MemberDM>(ID);

            return View(model);
        }
    }
}
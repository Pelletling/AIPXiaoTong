﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.Common;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class OrderPaidController : BaseController
    {
        private IOrderPaidService iOrderPaidService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;

        public OrderPaidController(IOrderPaidService iOrderPaidService,
                                   IEmployeeService iEmployeeService,
                                   IMerchantService iMerchantService,
                                   IProjectService iProjectService)
        {
            this.iOrderPaidService = iOrderPaidService;
            this.iMerchantService = iMerchantService;
            this.iEmployeeService = iEmployeeService;
            this.iProjectService = iProjectService;
        }
        public ActionResult Index(OrderPaidQM model)
        {
            var list = this.iOrderPaidService.GetListModel<OrderPaidLM, OrderPaidQM>(model);

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

        public ActionResult Details(long ID)
        {
            var model = iOrderPaidService.Get(ID);

            return View(model);
        }

        //public JsonResult Withdraw(long ID)
        //{
        //    ResultModel result = new ResultModel();
        //    try
        //    {
        //        var status = OrderPaidStatusOption.FrozenSuccess.ToInt();

        //        var orderPaid = iOrderPaidService.Get(t => t.ID == ID);

        //        if (orderPaid == null)
        //            throw new Exception("记录不存在，请刷新页面");

        //        if (orderPaid.Status != status)
        //            throw new Exception("当前状态(" + orderPaid.StatusDesc + ")无法操作");

        //orderPaid.PayAction = OrderPaidPayActionOption.Withdraw.ToInt();

        //iOrderPaidService.Save(orderPaid);

        //iOrderPaidService.Commit();

        //iOrderPaidService.PayWithdraw(orderPaid); //客户端提现操作，先解冻再提现

        //    }
        //    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
        //    {
        //        result.ResultMessage = ex.InnerException.InnerException.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ResultMessage = ex.Message;
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult Delete(long ID)
        {
            var result = iOrderPaidService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
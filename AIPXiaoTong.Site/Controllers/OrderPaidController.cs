﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Common;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    public class OrderPaidController : BaseController
    {
        private IOrderPaidService iOrderPaidService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;
        private IPreferencesService iPreferencesService;
        private IPingAnAPIService iPingAnAPIService;

        public OrderPaidController(IOrderPaidService iOrderPaidService,
                                   IEmployeeService iEmployeeService,
                                   IMerchantService iMerchantService,
                                   IProjectService iProjectService,
                                   IPreferencesService iPreferencesService,
                                   IPingAnAPIService iPingAnAPIService)
        {
            this.iOrderPaidService = iOrderPaidService;
            this.iMerchantService = iMerchantService;
            this.iEmployeeService = iEmployeeService;
            this.iProjectService = iProjectService;
            this.iPreferencesService = iPreferencesService;
            this.iPingAnAPIService = iPingAnAPIService;
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

        public ActionResult Export(string QueryJson)
        {
            var orderPaidQM = JsonHelper.Deserialize<OrderPaidQM>(System.Web.HttpUtility.UrlDecode(QueryJson));

            var list = iOrderPaidService.Export(orderPaidQM);

            var ms = iOrderPaidService.ExportNPOI<OrderPaidEM>(list);

            return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "认缴订单-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

        }

        public ActionResult Details(long ID)
        {
            var model = iOrderPaidService.Get(ID);

            return View(model);
        }

        public JsonResult Delete(long ID)
        {
            var result = iOrderPaidService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 提现（光大合作用户订单冻结或者已解冻状态）
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult Withdraw(long ID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.ID == ID);

                if (orderPaid == null)
                    throw new Exception("记录不存在，请刷新页面");

                iOrderPaidService.UnFreezeAndWithdraw(orderPaid); //客户端提现操作，先解冻再提现

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                result.ResultMessage = ex.InnerException.InnerException.Message;
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 解止付（平安合作用户-订单止付状态下（即相当于光大用户的已冻结状态））
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult UnFreezeMargins(long ID)
        {
            ResultModel result = new ResultModel();

            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.ID == ID);

                if (orderPaid == null)
                    throw new Exception("记录不存在，请刷新页面");

                iOrderPaidService.UnFreezePingAnMargins(orderPaid);

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                result.ResultMessage = ex.InnerException.InnerException.Message;
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    public class OrderBookingController : BaseController
    {
        private IOrderBookingService iOrderBookingService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;

        public OrderBookingController(IOrderBookingService iOrderBookingService,
                                      IEmployeeService iEmployeeService,
                                      IMerchantService iMerchantService,
                                      IProjectService iProjectService)
        {
            this.iOrderBookingService = iOrderBookingService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
            this.iProjectService = iProjectService;
        }
        public ActionResult Index(OrderBookingQM model)
        {
            var list = this.iOrderBookingService.GetListModel<OrderBookingLM, OrderBookingQM>(model);

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
            var model = iOrderBookingService.Get(ID);

            return View(model);
        }

        public JsonResult Delete(long ID)
        {
            var result = iOrderBookingService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
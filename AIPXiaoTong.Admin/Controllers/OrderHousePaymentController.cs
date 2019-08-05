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
    public class OrderHousePaymentController : BaseController
    {
        private IOrderHousePaymentService iOrderHousePaymentService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;

        public OrderHousePaymentController(IOrderHousePaymentService iOrderHousePaymentService,
                                           IEmployeeService iEmployeeService,
                                           IMerchantService iMerchantService)
        {
            this.iOrderHousePaymentService = iOrderHousePaymentService;
            this.iMerchantService = iMerchantService;
            this.iEmployeeService = iEmployeeService;
        }
        public ActionResult Index(OrderHousePaymentQM model)
        {
            var list = this.iOrderHousePaymentService.GetListModel<OrderHousePaymentLM, OrderHousePaymentQM>(model);

            BindData();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Grid", list);
            }

            return View(list);
        }

        private void BindData()
        {

        }

        public ActionResult Details(long ID)
        {
            var model = iOrderHousePaymentService.Get(ID);

            return View(model);
        }
    }
}
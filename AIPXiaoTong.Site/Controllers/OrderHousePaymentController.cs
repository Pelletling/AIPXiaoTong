using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    public class OrderHousePaymentController : BaseController
    {
        private IOrderHousePaymentService iOrderHousePaymentService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IMemberService iMemberService;

        public OrderHousePaymentController(IOrderHousePaymentService iOrderHousePaymentService,
                                           IEmployeeService iEmployeeService,
                                           IMerchantService iMerchantService,
                                           IMemberService iMemberService)
        {
            this.iOrderHousePaymentService = iOrderHousePaymentService;
            this.iMerchantService = iMerchantService;
            this.iEmployeeService = iEmployeeService;
            this.iMemberService = iMemberService;
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
            var empInfo = iEmployeeService.Get(currentUser.ID) ?? new Employee();

            ViewBag.merInfo = iMerchantService.Get(empInfo.MerchantID);

        }

        public ActionResult Export(string QueryJson)
        {
            var orderHousePaymentQM = JsonHelper.Deserialize<OrderHousePaymentQM>(System.Web.HttpUtility.UrlDecode(QueryJson));

            var list = iOrderHousePaymentService.Export(orderHousePaymentQM);

            var ms = iOrderHousePaymentService.ExportNPOI<OrderHousePaymentEM>(list);

            return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "房款订单-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public ActionResult Details(long ID)
        {
            var model = iOrderHousePaymentService.Get(ID);

            return View(model);
        }
    }
}
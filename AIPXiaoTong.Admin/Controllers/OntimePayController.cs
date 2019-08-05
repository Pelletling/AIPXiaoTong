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
    public class OntimePayController : BaseController
    {
        private IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService;

        public OntimePayController(IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService)
        {
            this.iPingAnOrderPaidRechargeService = iPingAnOrderPaidRechargeService;
        }

        public ActionResult Index(OntimePayQM model)
        {
            var list = this.iPingAnOrderPaidRechargeService.GetListModel<OntimePayLM, OntimePayQM>(model);

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
            var model = iPingAnOrderPaidRechargeService.Get(ID);

            return View(model);
        }
    }
}
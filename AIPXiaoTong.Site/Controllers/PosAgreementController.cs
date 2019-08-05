using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class PosAgreementController : BaseController
    {
        private IMemberService iMemberService;
        private IMerchantService iMerchantService;

        public PosAgreementController(IMemberService iMemberService,
            IMerchantService iMerchantService)
        {
            this.iMemberService = iMemberService;
            this.iMerchantService = iMerchantService;
        }

        /// <summary>
        /// 【通联支付】-中国光大银行电子账户业务服务协议
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public ActionResult GuangDaAccountAgreement(string IDNumber)
        {
            var member = this.iMemberService.Get(t => t.IDNumber == IDNumber) ?? new Member();

            ViewBag.MemberName = member.Name;

            return View();
        }

        /// <summary>
        /// 小通房产项目预存预缴服务协议
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public ActionResult DepositAndPayAgreement(string IDNumber, long? merchantid)
        {
            var member = this.iMemberService.Get(t => t.IDNumber == IDNumber) ?? new Member();

            ViewBag.MemberName = member.Name;

            var merchant = this.iMerchantService.Get(t => t.ID == merchantid);

            ViewBag.MerchantName = merchant?.Name;

            return View();
        }

    }
}
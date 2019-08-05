using AIPXiaoTong.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Framework.Web.IOC;
using Framework.Common;

namespace AIPXiaoTong.Site.Controllers
{
    public class AutoExecExtController : Controller
    {
        IGuangDaAPIService iGuangDaAPIService;

        public AutoExecExtController()
        {
            iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();
        }

        public string CheckFile(string date)
        {
            DateTime dateTime = date.ToDateTime("yyyyMMdd");

            var result = iGuangDaAPIService.BFinFundServiceReq(dateTime);

            return result.Head.ResCode + "：" + result.Head.ResMsg;
        }
    }
}
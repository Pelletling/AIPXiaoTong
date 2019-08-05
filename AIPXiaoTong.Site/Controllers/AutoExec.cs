using AIPXiaoTong.IService;
using FluentScheduler;
using Framework.Web.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace AIPXiaoTong.Site.Controllers
{
    public class AutoExec: Registry
    {
        IGuangDaAPIService iGuangDaAPIService;

        public AutoExec()
        {
            iGuangDaAPIService = DIFactory.GetContainer().Resolve<IGuangDaAPIService>();

            Schedule(() => CheckFile()).ToRunEvery(1).Days().At(6, 30);
        }

        private void CheckFile()
        {
            iGuangDaAPIService.BFinFundServiceReq(DateTime.Now);
        }
    }
}
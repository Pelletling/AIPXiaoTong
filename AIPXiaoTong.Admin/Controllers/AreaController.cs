using AIPXiaoTong.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Admin.Controllers
{
    [AllowAnonymous]
    public class AreaController : BaseController
    {
        IAreaService iAreaService;
        public AreaController(IAreaService iAreaService)
        {
            this.iAreaService = iAreaService;
        }

        public JsonResult GetChildren(string ParentCode = null)
        {
            var list = iAreaService.GetAllCache().Where(t => t.ParentCode == ParentCode);

            var result = from t in list
                         select new
                         {
                             Code = t.Code,
                             Name = t.Name,
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class HouseTypeShowController : BaseController
    {

        private IHouseTypeShowService iHouseTypeShowService;
        private IEmployeeService iEmployeeService;
        private IMerchantService iMerchantService;
        private IProjectService iProjectService;



        public HouseTypeShowController(IHouseTypeShowService iHouseTypeShowService,
                                        IEmployeeService iEmployeeService,
                                        IMerchantService iMerchantService,
                                        IProjectService iProjectService)
        {
            this.iHouseTypeShowService = iHouseTypeShowService;
            this.iEmployeeService = iEmployeeService;
            this.iMerchantService = iMerchantService;
            this.iProjectService = iProjectService;
        }
        public ActionResult Index(HouseTypeShowQM model)
        {
            var list = this.iHouseTypeShowService.GetListModel<HouseTypeShowLM, HouseTypeShowQM>(model);

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

            ViewBag.MerchantList = iMerchantService.GetListModel<MerchantLM, MerchantQM>();

            ViewBag.SiteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;
        }

        public ActionResult Details(long? ID = null)
        {
            BindData();

            var model = iHouseTypeShowService.GetViewModel<HouseTypeShowDM>(ID);

            return View(model);
        }

        //public ActionResult Create(long? ID = null)
        //{
        //    var model = iHouseTypeShowService.GetViewModel<HouseTypeShowCM>(ID);

        //    BindData();

        //    return View(model);
        //}

        //[ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Create(HouseTypeShowCM m)
        //{
        //    try
        //    {
        //        BindData();

        //        if (ModelState.IsValid)
        //        {
        //            var entity = iHouseTypeShowService.Get(m.ID) ?? new HouseTypeShow();

        //            if (m.ID == 0 && iHouseTypeShowService.Exists(t => t.ID != m.ID && t.ProjectID == m.ProjectID && t.HouseTypeName == m.HouseTypeName && t.MerchantID == m.MerchantID))
        //                throw new Exception("此户型已存在");

        //            entity.MerchantID = m.MerchantID;

        //            entity.ProjectID = m.ProjectID;
        //            entity.HouseTypeName = m.HouseTypeName;
        //            entity.HouseTypeArea = m.HouseTypeArea;
        //            entity.Content = m.Content;
        //            //entity.Description = m.Description;
        //            entity.Status = m.Status;

        //            //if (entity.HouseThumbnailImage != m.HouseThumbnailImage)
        //            //{
        //            //    entity.HouseThumbnailImage = @"\Images\HouseThumbnailImage\" + Guid.NewGuid() + ".png";
        //            //    System.IO.File.Copy(Server.MapPath(m.HouseThumbnailImage).Replace("Admin", "Site"), Server.MapPath(entity.HouseThumbnailImage).Replace("Admin", "Site"));
        //            //}


        //            if (m.HouseShowImageList != null)
        //            {


        //                for (int i = 0; i < m.HouseShowImageList.Count; i++)
        //                {
        //                    if (m.HouseShowImageList[i] != "")
        //                    {
        //                        if (m.HouseShowImageList[i].Contains(GlobalConfig.WebConfig.SiteImageUrl))
        //                        {
        //                            m.HouseShowImageList[i] = m.HouseShowImageList[i].Replace(GlobalConfig.WebConfig.SiteImageUrl, "");
        //                        }
        //                        var tarSource = @"\Images\HouseShowImage\" + Guid.NewGuid() + ".png";
        //                        System.IO.File.Copy(Server.MapPath(m.HouseShowImageList[i]).Replace("Admin", "Site"), Server.MapPath(tarSource).Replace("Admin", "Site"));

        //                        m.HouseShowImageList[i] = tarSource;
        //                    }
        //                }
        //                entity.HouseShowImage = JsonHelper.Serialize(m.HouseShowImageList);
        //            }

        //            iHouseTypeShowService.Save(entity);
        //            iHouseTypeShowService.Commit();

        //            this.ShowTip();
        //            return RedirectToAction("Create", new { ID = entity.ID });
        //        }
        //        else
        //        {
        //            AddError();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        this.AddError(ErrorCode.Exception, ex.Message);
        //    }

        //    return View(m);
        //}
        //public JsonResult Delete(long ID)
        //{
        //    var result = iHouseTypeShowService.AjaxDelete(ID);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult UploadHouseShowImage()
        //{
        //    return UploadFile("/Temp/TemHouseShowImage/", Request.Files[0].FileName);
        //}
        //protected JsonResult UploadFile(string path, string fileName)
        //{
        //    try
        //    {
        //        var file = Request.Files[0];

        //        if (!System.IO.Directory.Exists(path))
        //        {
        //            System.IO.Directory.CreateDirectory(path);
        //        }
        //        string FilePath = path + fileName;
        //        file.SaveAs(Server.MapPath(FilePath).Replace("Admin", "Site"));
        //        return Json(new { Msg = "", Path = FilePath, FileName = fileName }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Msg = ex.Message, Path = "", FileName = fileName }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public JsonResult CodeIsExists(long? ID, string HouseTypeName)
        //{
        //    var exists = false;

        //    var housetypeshow = iHouseTypeShowService.Get(t => t.HouseTypeName == HouseTypeName.Trim()) ?? new HouseTypeShow();

        //    if (ID == 0)
        //    {
        //        exists = iProjectService.Exists(t => t.ProjectName == HouseTypeName.Trim() && t.ID == housetypeshow.ID);
        //    }

        //    return Json(!exists, JsonRequestBehavior.AllowGet);
        //}
    }
}
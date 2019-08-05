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
            var empInfo = iEmployeeService.Get(currentUser.ID);

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

            ViewBag.ProjectList = iProjectService.GetListModel<ProjectLM, ProjectQM>().OrderBy(t=>t.ProjectName).ToList();
        }

        public ActionResult Create(long? ID = null)
        {
            var model = iHouseTypeShowService.GetViewModel<HouseTypeShowCM>(ID);

            BindData();

            return View(model);
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(HouseTypeShowCM m)
        {
            try
            {
                BindData();

                if (ModelState.IsValid)
                {
                    var entity = iHouseTypeShowService.Get(m.ID) ?? new HouseTypeShow();

                    if (iHouseTypeShowService.Exists(t => t.ID != m.ID && t.ProjectID == m.ProjectID && t.HouseTypeName == m.HouseTypeName))
                        throw new Exception("此户型已存在");

                    var empInfo = iEmployeeService.Get(currentUser.ID);

                    entity.MerchantID = empInfo.MerchantID;
                    entity.ProjectID = m.ProjectID;
                    entity.HouseTypeName = m.HouseTypeName;
                    entity.HouseTypeArea = m.HouseTypeArea;
                    entity.Content = m.Content;

                    if (m.HouseShowImageList.Where(s => !string.IsNullOrEmpty(s)).ToArray().Count() > 0)
                    {
                        for (int i = 0; i < m.HouseShowImageList.Count; i++)
                        {
                            if (m.HouseShowImageList[i] != "")
                            {
                                var tarSource = @"\Images\HouseShowImage\" + Guid.NewGuid() + ".png";
                                if (!ImageHelper.Resize(Server.MapPath(m.HouseShowImageList[i]), Server.MapPath(tarSource), 350))
                                {
                                    System.IO.File.Copy(Server.MapPath(m.HouseShowImageList[i]), Server.MapPath(tarSource));
                                }

                                m.HouseShowImageList[i] = tarSource;
                            }
                        }
                        entity.HouseShowImage = JsonHelper.Serialize(m.HouseShowImageList);
                    }
                    else
                    {
                        throw new Exception("户型图片不能为空");
                    }

                    iHouseTypeShowService.Save(entity);
                    iHouseTypeShowService.Commit();

                    this.ShowTip();
                    return RedirectToAction("Create", new { ID = entity.ID });
                }
                else
                {
                    AddError();
                }
            }
            catch (Exception ex)
            {

                this.AddError(ErrorCode.Exception, ex.Message);
            }
            return View(m);
        }


        public JsonResult Delete(long ID)
        {
            var result = iHouseTypeShowService.AjaxDelete(ID);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UploadHouseThumbnailImage()
        {
            return UploadFile("/Temp/TemHouseThumbnailImage/", Request.Files[0].FileName);
        }

        public JsonResult UploadHouseShowImage()
        {
            return UploadFile("/Temp/TemHouseShowImage/", Request.Files[0].FileName);
        }
        protected JsonResult UploadFile(string path, string fileName)
        {
            try
            {
                var file = Request.Files[0];

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string FilePath = path + fileName;
                file.SaveAs(Server.MapPath(FilePath));
                return Json(new { Msg = "", Path = FilePath, FileName = fileName }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message, Path = "", FileName = fileName }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(long ID)
        {
            var model = iHouseTypeShowService.Get(ID);

            return View(model);
        }

        public JsonResult Audit(long ID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var status = HouseTypeShowStatus.AlreadySubmit.ToInt();

                var e = iHouseTypeShowService.Get(t => t.ID == ID && t.Status == status);

                if (e == null)
                    throw new Exception("记录不存在，请刷新页面");

                e.Status = HouseTypeShowStatus.Pass.ToInt();

                iHouseTypeShowService.Save(e);

                iHouseTypeShowService.Commit();

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

        public JsonResult NoPass(long ID, string Msg)
        {
            ResultModel result = new ResultModel();
            try
            {
                var status = HouseTypeShowStatus.AlreadySubmit.ToInt();

                var e = iHouseTypeShowService.Get(t => t.ID == ID && t.Status == status);

                if (e == null)
                    throw new Exception("记录不存在，请刷新页面");

                e.Status = HouseTypeShowStatus.NotPass.ToInt();
                e.Reason = Msg;

                iHouseTypeShowService.Save(e);

                iHouseTypeShowService.Commit();

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

        public JsonResult AuditReset(long ID)
        {
            ResultModel result = new ResultModel();
            try
            {
                var status = HouseTypeShowStatus.AlreadySubmit.ToInt();

                var e = iHouseTypeShowService.Get(t => t.ID == ID && t.Status != status);

                if (e == null)
                    throw new Exception("记录不存在，请刷新页面");

                e.Status = HouseTypeShowStatus.AlreadySubmit.ToInt();
                e.Reason = "";

                iHouseTypeShowService.Save(e);

                iHouseTypeShowService.Commit();

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
﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.API;
using AIPXiaoTong.Model.Site;
using AIPXiaoTong.Service;
using Framework.Common;
using Framework.LambdaExpression;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VSP.Pay;
using Webdiyer.WebControls.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class APIController : Controller
    {
        public ILogger logger;
        private string key = "1234567890";
        private IEmployeeService iEmployeeService;
        private IOrderBookingService iOrderBookingService;
        private IOrderHousePaymentService iOrderHousePaymentService;
        private IOrderPaidService iOrderPaidService;
        private IMemberService iMemberService;
        private IProjectService iProjectService;
        private IHouseTypeShowService iHouseTypeShowService;
        private ITltService iTltService;
        private IBankCardService iBankCardService;
        private IEquipmentService iEquipmentService;
        private IBankService iBankService;
        private IAreaGuangDaService iAreaGuangDaService;
        private IGuangDaAPIService iGuangDaAPIService;
        private IPreferencesService iPreferencesService;
        private IOrderPaidRechargeService iOrderPaidRechargeService;
        private IOrderPaidFreezeService iOrderPaidFreezeService;
        private IOrderPaidUnFreezeService iOrderPaidUnFreezeService;
        private IOrderPaidWithdrawService iOrderPaidWithdrawService;
        private IGuangDaECIFService iGuangDaECIFService;
        private IAccountGuangDaService iAccountGuangDaService;
        private IGuangDaAreaService iGuangDaAreaService;
        private IMerchantMemberService iMerchantMemberService;

        private long merchantID { get; set; }
        private Merchant merchant { get; set; }

        //  VSPExec vspExec = null;

        public APIController(IEmployeeService iEmployeeService,
                              IOrderBookingService iOrderBookingService,
                              IOrderHousePaymentService iOrderHousePaymentService,
                              IOrderPaidService iOrderPaidService,
                              IMemberService iMemberService,
                              IProjectService iProjectService,
                              IHouseTypeShowService iHouseTypeShowService,
                              ITltService iTltService,
                              IBankCardService iBankCardService,
                              IEquipmentService iEquipmentService,
                              IBankService iBankService,
                              IAreaGuangDaService iAreaGuangDaService,
                              IGuangDaAPIService iDuangDaAPIService,
                              IPreferencesService iPreferencesService,
                              IOrderPaidRechargeService iOrderPaidRechargeService,
                              IOrderPaidFreezeService iOrderPaidFreezeService,
                               IOrderPaidUnFreezeService iOrderPaidUnFreezeService,
                               IOrderPaidWithdrawService iOrderPaidWithdrawService,
                               IGuangDaECIFService iGuangDaECIFService,
                               IAccountGuangDaService iAccountGuangDaService,
                               IGuangDaAreaService iGuangDaAreaService,
                               IMerchantMemberService iMerchantMemberService)
        {
            this.iEmployeeService = iEmployeeService;
            this.iOrderBookingService = iOrderBookingService;
            this.iOrderHousePaymentService = iOrderHousePaymentService;
            this.iOrderPaidService = iOrderPaidService;
            this.iMemberService = iMemberService;
            this.iProjectService = iProjectService;
            this.iHouseTypeShowService = iHouseTypeShowService;
            this.iTltService = iTltService;
            this.iBankCardService = iBankCardService;
            this.iEquipmentService = iEquipmentService;
            this.iBankService = iBankService;
            this.iAreaGuangDaService = iAreaGuangDaService;
            this.iGuangDaAPIService = iDuangDaAPIService;
            this.iPreferencesService = iPreferencesService;
            this.iOrderPaidRechargeService = iOrderPaidRechargeService;
            this.iOrderPaidFreezeService = iOrderPaidFreezeService;
            this.iOrderPaidUnFreezeService = iOrderPaidUnFreezeService;
            this.iOrderPaidWithdrawService = iOrderPaidWithdrawService;
            this.iGuangDaECIFService = iGuangDaECIFService;
            this.iAccountGuangDaService = iAccountGuangDaService;
            this.iGuangDaAreaService = iGuangDaAreaService;
            this.iMerchantMemberService = iMerchantMemberService;

            logger = LogManager.GetCurrentClassLogger();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string content = Request.Form.ToString();

            if (string.IsNullOrWhiteSpace(content))
                content = Request.QueryString.ToString();

            //content = HttpUtility.UrlDecode(content);

            logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + System.Threading.Thread.CurrentThread.ManagedThreadId + "|" + content);

            BaseResponse response = new BaseResponse();
            response.requestno = Request["requestno"] ?? "";

            //检查数据合法性

            if (!ModelState.IsValid)
            {
                response.retsultcode = GuangDaExceptionOption.DataError.ToInt().ToString();
                response.resultmsg = GuangDaExceptionOption.DataError.ToDescription() + "：" + ModelState.Values.Where(t => t.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }

            //检查SN号
            var equipmentsnno = Request["equipmentsnno"];
            var equipment = iEquipmentService.Get(t => t.EquipmentSNNo == equipmentsnno);
            if (equipment == null)
            {
                response.retsultcode = GuangDaExceptionOption.PosUnbound.ToInt().ToString();
                response.resultmsg = GuangDaExceptionOption.PosUnbound.ToDescription();
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }
            else if (equipment.Status <= 0)
            {
                response.retsultcode = GuangDaExceptionOption.PosUnable.ToInt().ToString();
                response.resultmsg = GuangDaExceptionOption.PosUnable.ToDescription() + "(" + equipment.StatusDesc + ")";
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }
            else
            {
                merchantID = equipment.MerchantID;
                merchant = equipment.Merchant;
            }

            //检查签名

            if (Request.Url.Host == "localhost")
                return;

            var result = Verify(content);

            if (!result)
            {
                response.retsultcode = GuangDaExceptionOption.VerifySignFail.ToInt().ToString();
                response.resultmsg = GuangDaExceptionOption.VerifySignFail.ToDescription();
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + System.Threading.Thread.CurrentThread.ManagedThreadId + "|" + (filterContext.Result as ContentResult)?.Content);

            base.OnActionExecuted(filterContext);
        }

        private bool Verify(string content)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var m in content.Split('&'))
            {
                var n = m.Split('=');
                if (n.Length >= 2 && !string.IsNullOrWhiteSpace(n[1]))
                {
                    dic.Add(n[0], HttpUtility.UrlDecode(n[1]));
                }
            }

            if (dic.ContainsKey("key"))
            {
                dic.Remove("key");
            }

            dic.Add("key", key);

            string sign = dic.ContainsKey("sign") ? dic["sign"] : "";

            dic.Remove("sign");

            string signString = "";

            foreach (var m in dic.OrderBy(t => t.Key))
            {
                signString += "&" + m.Key + "=" + m.Value;
            }

            signString = signString.Substring(1);

            string md5 = Framework.Security.Crypt.MD5(signString);

            if (!string.IsNullOrWhiteSpace(sign) && sign == md5)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 用户登录接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Login(LoginRequest request)
        {
            var result = new LoginResponse() { requestno = request.requestno.Trim() };

            try
            {
                var employee = iEmployeeService.Get(t => t.Code == request.employeecode && t.MerchantID == merchantID);

                if (employee == null)
                    throw new APIException(GuangDaExceptionOption.EmployeeNotExists);

                if (employee.Password != request.password)
                    throw new APIException(GuangDaExceptionOption.PasswordError);

                var preferences = iPreferencesService.Get(t => t.MerchantID == merchantID);

                if (preferences == null)
                    throw new APIException(GuangDaExceptionOption.NotSetVspParam);

                result.employeecode = employee.Code;
                result.employeeid = employee.ID.ToString();
                result.merchantid = employee.MerchantID.ToString();
                result.merchantname = employee.MerchantName;
                result.vspcode = preferences.POSBaoMerchant;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 单个“预约订单”查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryOrderBookingDetail(QueryOrderBookingDetailRequst request)
        {
            var result = new QueryOrderBookingDetailResponse() { requestno = request.requestno.Trim() };

            try
            {
                var orderBooking = iOrderBookingService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderBooking == null)
                    throw new APIException(GuangDaExceptionOption.OrderNotExists);

                result.orderbookingid = orderBooking.ID.ToString();
                result.ordernumber = orderBooking.OrderNumber;
                result.merchantid = orderBooking.MerchantID.ToString();
                result.merchantname = orderBooking.Merchant.Name;
                result.projectid = orderBooking.ProjectID.ToString();
                result.projectname = orderBooking.ProjectName;
                result.equipmentsnno = orderBooking.EquipmentSNNo;
                result.memberid = orderBooking.MemberID.ToString();
                result.membername = orderBooking.OrderName;
                result.membermobile = orderBooking.OrderMobile;
                result.memberidnumber = orderBooking.MemberIDNumber;
                result.ordertime = orderBooking.OrderTime.ToString();
                result.remark = orderBooking.Remark;
                result.employeeid = orderBooking.EmployeeID.ToString();
                result.employeename = orderBooking.Employee.Name;
                result.ordername = orderBooking.OrderName;
                result.ordermobile = orderBooking.OrderMobile;

            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “预约订单”列表接口查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryOrderBookingList(QueryOrderBookingListRequst request)
        {
            var result = new QueryOrderBookingListResponse() { requestno = request.requestno.Trim() };

            var model = new OrderBookingQM();

            try
            {
                Expression<Func<OrderBooking, bool>> express = DynamicExpressions.True<OrderBooking>();

                if (request.employeeid != null)
                {
                    express = express.AndAlso(t => t.EmployeeID == request.employeeid);
                }

                if (!string.IsNullOrWhiteSpace(request.projectname))
                {
                    express = express.AndAlso(t => t.Project.ProjectName.Contains(request.projectname.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(request.ordernumber))
                {
                    express = express.AndAlso(t => t.OrderNumber == request.ordernumber.Trim());
                }

                if (!string.IsNullOrWhiteSpace(request.appdate))
                {
                    var ordertime = request.appdate.ToDateTime("yyyyMMdd");
                    express = express.AndAlso(t => t.OrderTime == ordertime);
                }

                if (!string.IsNullOrWhiteSpace(request.username))
                {
                    express = express.AndAlso(t => t.Member.Name == request.username.Trim());
                }


                express = express.AndAlso(t => t.MerchantID == merchantID);

                var list = iOrderBookingService.Gets(express, request.pageindex.ToInt(), request.pagesize.ToInt(), new OrderByExpression<OrderBooking, long>(t => t.ID, true));

                result.orderbookinglist = new List<QueryOrderBookingListResponse.OrderBookingList>();

                for (int i = 0; i < list.Count; i++)
                {
                    result.orderbookinglist.Add(new QueryOrderBookingListResponse.OrderBookingList()
                    {
                        orderbookingid = list[i].ID.ToString(),
                        ordernumber = list[i].OrderNumber,
                        projectid = list[i].ProjectID.ToString(),
                        projectname = list[i].ProjectName,
                        equipmentsnno = list[i].EquipmentSNNo,
                        merchantid = list[i].MerchantID.ToString(),
                        merchantname = list[i].MerchantName,
                        memberid = list[i].MemberID.ToString(),
                        membername = list[i].MemberName,
                        membermobile = list[i].MemberMobile,
                        memberidnumber = list[i].MemberIDNumber,
                        ordermobile = list[i].OrderMobile,
                        ordername = list[i].OrderName,
                        ordertime = list[i].OrderTime.ToString(),
                        remark = list[i].Remark,
                        employeeid = list[i].EmployeeID.ToString(),
                        employeename = list[i].EmployeeName,

                    });
                }
                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iOrderBookingService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 预约订单创建接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateOrderBooking(CreateOrderBookingRequst request)
        {
            var result = new CreateOrderBookingResponse() { requestno = request.requestno.Trim() };

            try
            {
                var employee = iEmployeeService.Get(t => t.ID == request.employeeid && t.Merchant.EquipmentList.FirstOrDefault(f => f.EquipmentSNNo == request.equipmentsnno.Trim()) != null);

                if (employee == null)
                    throw new APIException(GuangDaExceptionOption.EmployeeNotExists);

                var orderBooking = iOrderBookingService.Get(t => t.OrderName == request.name.Trim() && t.OrderMobile == request.mobile.Trim());

                //if (orderBooking != null && (Convert.ToDateTime(request.ordertime) - orderBooking.OrderTime).Days < 7)   //一周内不允许重复预约
                //    throw new APIException("用户已预约");

                var member = iMemberService.Get(t => t.Mobile == request.mobile.Trim() && t.Name == request.name.Trim());

                var entity = new OrderBooking();

                entity.OrderName = request.name;
                entity.OrderMobile = request.mobile;
                entity.MerchantID = employee.MerchantID;
                entity.OrderNumber = GuidHelper.GenUniqueId();
                entity.ProjectID = request.projectid;
                entity.EquipmentSNNo = request.equipmentsnno;
                entity.OrderTime = Convert.ToDateTime(request.ordertime);
                entity.Remark = request.remark;
                entity.EmployeeID = employee.ID;
                entity.MemberID = member?.ID;

                iOrderBookingService.Save(entity);
                iOrderBookingService.Commit();

                result.ordernumber = entity.OrderNumber;
                result.orderbookingid = entity.ID.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 查询单个“认缴订单”接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryOrderPaidDetail(QueryOrderPaidDetailRequst request)
        {

            var result = new QueryOrderPaidDetailResponse() { requestno = request.requestno.Trim() };

            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderPaid == null)
                    throw new APIException(GuangDaExceptionOption.OrderNotExists);

                try
                {
                    iOrderPaidService.SyncStatus(orderPaid);
                    iOrderPaidService.Commit();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }


                result.orderpaidid = orderPaid.ID.ToString();
                result.merchantid = orderPaid.MerchantID.ToString();
                result.merchantname = orderPaid.MerchantName;
                result.ordernumber = orderPaid.OrderNumber;
                result.projectid = orderPaid.ProjectID.ToString();
                result.projectname = orderPaid.ProjectName;
                result.equipmentsnno = orderPaid.EquipmentSNNo;
                result.transactionamount = orderPaid.TransactionAmount.ToString();
                result.serialnumber = orderPaid.TransNumber;
                result.memberid = orderPaid.MemberID.ToString();
                result.membername = orderPaid.MemberName;
                result.membermobile = orderPaid.MemberMobile;
                result.memberidnumber = orderPaid.MemberIDNumber;
                result.bankcardnumber = orderPaid.Member?.BankCard?.BankCardNumber;
                result.remark = orderPaid.Remark;
                result.status = orderPaid.Status.ToString();
                result.statusdesc = orderPaid.StatusDesc.ToString();
                result.createdatetime = orderPaid.CreateDatetime.ToString("yyyyMMddHHmmss");
                result.employeeid = orderPaid.EmployeeID.ToString();
                result.employeename = orderPaid.EmployeeName;
                result.unfreezedate = orderPaid.OrderPaidFreeze?.UnFreezeDate.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “认缴订单”列表查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryOrderPaidList(QueryOrderPaidListRequst request)
        {
            var result = new QueryOrderPaidListResponse() { requestno = request.requestno.Trim() };

            var model = new OrderPaidQM();

            try
            {
                Expression<Func<OrderPaid, bool>> express = DynamicExpressions.True<OrderPaid>();

                if (!string.IsNullOrWhiteSpace(request.projectname))
                {
                    express = express.AndAlso(t => t.Project.ProjectName.Contains(request.projectname.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(request.ordernumber))
                {
                    express = express.AndAlso(t => t.OrderNumber == request.ordernumber.Trim());
                }

                if (!string.IsNullOrWhiteSpace(request.username))
                {
                    express = express.AndAlso(t => t.Member.Name == request.username.Trim());
                }

                if (request.employeeid != null)
                {
                    express = express.AndAlso(t => t.EmployeeID == request.employeeid);
                }

                express = express.AndAlso(t => t.MerchantID == merchantID);

                var list = iOrderPaidService.Gets(express, request.pageindex.ToInt(), request.pagesize.ToInt(), new OrderByExpression<OrderPaid, long>(t => t.ID, true));

                result.orderpaidlist = new List<QueryOrderPaidListResponse.OrderPaidList>();
                for (int i = 0; i < list.Count; i++)
                {
                    result.orderpaidlist.Add(new QueryOrderPaidListResponse.OrderPaidList()
                    {
                        ordernumber = list[i].OrderNumber,
                        merchantid = list[i].MerchantID.ToString(),
                        merchantname = list[i].MerchantName,
                        projectid = list[i].ProjectID.ToString(),
                        projectname = list[i].ProjectName,
                        equipmentsnno = list[i].EquipmentSNNo,
                        transactionamount = list[i].TransactionAmount,
                        serialnumber = list[i].TransNumber,
                        memberid = list[i].MemberID.ToString(),
                        membername = list[i].MemberName,
                        membermobile = list[i].MemberMobile,
                        memberidnumber = list[i].MemberIDNumber,
                        employeeid = list[i].EmployeeID.ToString(),
                        employeename = list[i].EmployeeName,
                        status = list[i].Status.ToString(),
                        statusdesc = list[i].StatusDesc,
                        rmark = list[i].Remark,
                    });
                }

                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iOrderPaidService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 认缴订单创建接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateOrderPaid(CreateOrderPaidRequst request)
        {
            var result = new CreateOrderPaidResponse() { requestno = request.requestno.Trim() };

            try
            {
                var employee = iEmployeeService.Get(t => t.ID == request.employeeid && t.MerchantID == merchantID);

                if (employee == null)
                    throw new APIException(GuangDaExceptionOption.EmployeeNotExists);

                var member = iMemberService.Get(t => t.IDNumber == request.idnumber.Trim());

                if (member == null)
                    throw new APIException(GuangDaExceptionOption.MemberNotExists);

                if (member.AccountGuangDa.IsCreateAccount != AccountStatus.IDCardUpload.ToInt())
                {
                    throw new APIException(GuangDaExceptionOption.UnOpenAccount);
                }

                var project = iProjectService.Get(t => t.ID == request.projectid);

                if (project == null)
                    throw new APIException(GuangDaExceptionOption.ProjectNotExists);

                if (request.transactionamount > project.ResidueAmount)
                    throw new APIException(GuangDaExceptionOption.ResidueAmountInsufficient);

                if (DateTime.Now > project.Deadline && DateTime.Now < project.StartTime)
                    throw new APIException(GuangDaExceptionOption.NotInDate);

                var entity = new OrderPaid();

                entity.MerchantID = merchantID;
                entity.TransactionAmount = request.transactionamount;
                entity.ProjectID = project.ID;
                entity.EquipmentSNNo = request.equipmentsnno;
                entity.Remark = request.remark;
                entity.EmployeeID = employee.ID;
                entity.MemberID = member.ID;
                entity.Project = project;

                if (!iMerchantMemberService.Exists(t => t.MerchantID == merchantID && t.MemberID == member.ID))
                {
                    var merchantMember = new MerchantMember();

                    merchantMember.MemberID = member.ID;
                    merchantMember.MerchantID = merchantID;

                    iMerchantMemberService.Save(merchantMember);
                    iMerchantMemberService.Commit();
                }

                iOrderPaidService.Save(entity);
                iOrderPaidService.Commit();

                result.ordernumber = entity.OrderNumber;
                result.orderpaidid = entity.ID.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “项目管理”单个项目详情查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryProjectDetail(QueryProjectDetailRequst request)
        {
            var siteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;
            var result = new QueryProjectDetailResponse() { requestno = request.requestno.Trim() };
            try
            {
                var project = iProjectService.Get(t => t.ID == request.projectid && t.MerchantID == merchantID);

                if (project == null)
                    throw new APIException(GuangDaExceptionOption.ProjectNotExists);

                if (project.AdvertisingImge != null)
                {
                    var advertisingimgelists = JsonHelper.Deserialize<List<string>>(project.AdvertisingImge).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                    for (int i = 0; i < advertisingimgelists.Count(); i++)
                    {
                        advertisingimgelists[i] = siteImageUrl + advertisingimgelists[i].Replace("\\", "/");
                    }

                    result.advertisingimge = JsonHelper.Serialize(advertisingimgelists);
                    result.projectimage = advertisingimgelists.FirstOrDefault().Replace("\\", "/");
                }

                result.merchantid = project.MerchantID.ToString();
                result.merchantname = project.MerchantName;
                result.projectid = project.ID.ToString();
                result.projectname = project.ProjectName;
                result.projectamount = project.ProjectAmount.ToString();
                result.residueamount = project.ResidueAmount.ToString();
                result.deadline = project.Deadline.ToString();
                result.description = project.Description;
                result.provincecode = project.ProvinceCode;
                result.provincename = project.ProvinceName;
                result.citycode = project.CityCode;
                result.cityname = project.CityName;
                result.status = project.Status.ToString();
                result.statusdesc = project.StatusDesc;
                result.reason = project.Reason;
                result.guaranteemonth = project.GuaranteeMonth.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “项目管理”项目列表查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryProjectList(QueryProjectListRequst request)
        {
            var siteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;
            var result = new QueryProjectListResponse() { requestno = request.requestno.Trim() };
            var model = new ProjectQM();

            try
            {
                var projectStatus = ProjectStatus.Pass.ToInt();

                Expression<Func<Project, bool>> express = DynamicExpressions.True<Project>();

                express = express.AndAlso(t => t.MerchantID == merchantID && t.Status == projectStatus);

                express = express.AndAlso(t => t.Deadline > DateTime.Now);

                if (!string.IsNullOrWhiteSpace(request.projectname))
                {
                    express = express.AndAlso(t => t.ProjectName.Contains(request.projectname.Trim()));
                }

                var list = iProjectService.Gets(express, request.pageindex.ToInt(), request.pagesize.ToInt(), new OrderByExpression<Project, long>(t => t.ID, true));

                result.projectlist = new List<QueryProjectListResponse.ProjectList>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].AdvertisingImge != null)
                    {
                        var advertisingimgelist = JsonHelper.Deserialize<List<string>>(list[i].AdvertisingImge).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                        for (int j = 0; j < advertisingimgelist.Count(); j++)
                        {
                            advertisingimgelist[j] = siteImageUrl + advertisingimgelist[j].Replace("\\", "/");
                        }

                        list[i].AdvertisingImge = JsonHelper.Serialize(advertisingimgelist);
                    }

                    result.projectlist.Add(new QueryProjectListResponse.ProjectList()
                    {
                        merchantid = list[i].MerchantID.ToString(),
                        merchantname = list[i].MerchantName,
                        projectid = list[i].ID.ToString(),
                        projectname = list[i].ProjectName.Trim(),
                        projectimage = list[i].AdvertisingImgList.FirstOrDefault().Replace("\\", "/"),
                        projectamount = list[i].ProjectAmount.ToString(),
                        residueamount = list[i].ResidueAmount.ToString(),
                        deadline = list[i].Deadline.ToString(),
                        description = list[i].Description,
                        statusdesc = list[i].StatusDesc,
                        status = list[i].Status.ToString(),
                        provincecode = list[i].ProvinceCode,
                        provincename = list[i].ProvinceName,
                        citycode = list[i].CityCode,
                        cityname = list[i].CityName,
                        advertisingimge = list[i].AdvertisingImge,
                        reason = list[i].Reason,
                    });
                }
                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iProjectService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }
            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “户型展示”单个信息查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryHouseTypeShowDetail(QueryHouseTypeShowDetailRequst request)  //查询单个项目信息
        {
            var siteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;
            var result = new QueryHouseTypeShowDetailResponse() { requestno = request.requestno.Trim() };

            try
            {
                var houseTypeStatus = HouseTypeShowStatus.Pass.ToInt();
                var houseTypeShow = iHouseTypeShowService.Get(t => t.ID == request.housetypeshowid && t.MerchantID == merchantID && t.Status == houseTypeStatus);

                if (houseTypeShow == null)
                    throw new APIException(GuangDaExceptionOption.HouseTypeShowNotExists);

                result.merchantid = houseTypeShow.MerchantID.ToString();
                result.merchantname = houseTypeShow.MerchantName;
                result.projectid = houseTypeShow.ProjectID.ToString();
                result.projectname = houseTypeShow.ProjectName;
                result.housetypeshowid = houseTypeShow.ID.ToString();
                result.housetypename = houseTypeShow.HouseTypeName;

                result.housetypearea = houseTypeShow.HouseTypeArea.ToString();
                // result.description = houseTypeShow.Description;
                result.content = houseTypeShow.Content;

                if (houseTypeShow.HouseShowImage != null)
                {
                    var houseshowimagelists = JsonHelper.Deserialize<List<string>>(houseTypeShow.HouseShowImage).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                    for (int i = 0; i < houseshowimagelists.Count(); i++)
                    {
                        houseshowimagelists[i] = siteImageUrl + houseshowimagelists[i].Replace("\\", "/");
                    }

                    result.houseshowimage = JsonHelper.Serialize(houseshowimagelists);
                    result.housethumbnailimage = houseshowimagelists.FirstOrDefault().Replace("\\", "/");
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// “户型管理”户型列表信息查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryHouseTypeShowList(QueryHouseTypeShowListRequst request)
        {
            var siteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;
            var result = new QueryHouseTypeShowListResponse() { requestno = request.requestno };

            var model = new HouseTypeShowQM();

            try
            {
                var houseTypeStatus = HouseTypeShowStatus.Pass.ToInt();

                Expression<Func<HouseTypeShow, bool>> express = DynamicExpressions.True<HouseTypeShow>();

                if (!string.IsNullOrWhiteSpace(request.houstypename))
                {
                    express = express.AndAlso(t => t.HouseTypeName.Contains(request.houstypename.Trim()));
                }

                express = express.AndAlso(t => t.MerchantID == merchantID && t.Status == houseTypeStatus && t.ProjectID == request.projectid);

                var list = iHouseTypeShowService.Gets(express, request.pageindex.ToInt(), request.pagesize.ToInt(), new OrderByExpression<HouseTypeShow, long>(t => t.ID, true));

                result.housetypeshowlist = new List<QueryHouseTypeShowListResponse.QueryHouseTypeShowList>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].HouseShowImage != null)
                    {
                        var houseshowimagelists = JsonHelper.Deserialize<List<string>>(list[i].HouseShowImage).Where(s => !string.IsNullOrEmpty(s)).ToArray(); ;

                        for (int j = 0; j < houseshowimagelists.Count(); j++)
                        {
                            houseshowimagelists[j] = siteImageUrl + houseshowimagelists[j].Replace("\\", "/");
                        }

                        list[i].HouseShowImage = JsonHelper.Serialize(houseshowimagelists);

                    }

                    result.housetypeshowlist.Add(new QueryHouseTypeShowListResponse.QueryHouseTypeShowList()
                    {
                        merchantid = list[i].MerchantID.ToString(),
                        merchantname = list[i].MerchantName,
                        projectid = list[i].ProjectID.ToString(),
                        projectname = list[i].ProjectName,
                        housetypeshowid = list[i].ID.ToString(),
                        housetypename = list[i].HouseTypeName,
                        housetypearea = list[i].HouseTypeArea.ToString(),
                        //content = HttpUtility.UrlEncode(list[i].Content),
                        content = list[i].Content,
                        housethumbnailimage = list[i].HouseShowImageList.FirstOrDefault().Replace("\\", "/"),
                        houseshowimage = list[i].HouseShowImage,
                    });
                }
                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iHouseTypeShowService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }
            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 会员信息创建接口(身份证创建)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateMember(CreateMemberRequst request)
        {
            var result = new CreateMemberResponse() { requestno = request.requestno.Trim() };

            try
            {
                var member = iMemberService.Get(t => t.IDNumber == request.idnumber.Trim());

                if (member != null)
                    throw new APIException(GuangDaExceptionOption.MemberIsCreate);

                member = new Member();

                var IDImageFrontPath = GlobalConfig.WebConfig.GuangDa_IDImagesPath + Guid.NewGuid() + ".jpg";
                var IDImageOppositePath = GlobalConfig.WebConfig.GuangDa_IDImagesPath + Guid.NewGuid() + ".jpg";

                ImageHelper.Base64StringToImage(Server.MapPath(IDImageFrontPath), request.idimagefront);
                ImageHelper.Base64StringToImage(Server.MapPath(IDImageOppositePath), request.idimageopposite);

                member.Name = request.name.Trim();
                member.IDNumber = request.idnumber.Trim();

                if (merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
                {
                    var account = new AccountGuangDa();

                    account.Member = member;
                    account.IdExpiredDate = request.idexpireddate.ToDateTime("yyyyMMdd");

                    account.IDImageFront = IDImageFrontPath;
                    account.IDImageOpposite = IDImageOppositePath;

                    iAccountGuangDaService.Save(account);
                }

                iMemberService.Save(member);

                iMemberService.Commit();

                result.memberid = member.ID.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 会员查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string QueryMemberInfo(QueryMemberInfoRequst request)
        {
            var result = new QueryMemberInfoResponse() { requestno = request.requestno };

            var siteImageUrl = GlobalConfig.WebConfig.SiteImageUrl;

            try
            {
                var member = iMemberService.Get(t => t.IDNumber == request.idnumber.Trim());

                if (member == null)
                    throw new APIException(GuangDaExceptionOption.MemberNotExists);

                //var bankcard = iBankCardService.Get(t => t.MemberID == member.ID);

                result.name = member.Name;
                result.memberid = member.ID;
                result.mobile = member.Mobile;
                result.idnumber = member.IDNumber;

                if (merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
                {
                    if (member.AccountGuangDa == null)
                    {
                        result.iscreateaccount = "0";
                        result.iscreateaccountdesc = AccountStatus.NotCreate.ToDescription();
                    }
                    else
                    {
                        result.iscreateaccount = member.AccountGuangDa.IsCreateAccount.ToString();
                        result.iscreateaccountdesc = member.AccountGuangDa.IsCreateAccountDesc;
                        result.balance = Convert.ToDecimal(member.AccountGuangDa.Balance);
                        result.freezebalance = Convert.ToDecimal(member.AccountGuangDa.FreezeBalance);
                        result.bankcardnumber = member.BankCardNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 银行卡绑定接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private BankCard BankCardBinding(long memberID, string name, string idNumber, string bankCardNumber, string mobile, string bankCode)
        {
            //检测是否存在绑定银行卡

            var bankCard = iBankCardService.Get(t => t.MemberID == memberID) ?? new BankCard();

            var bank = this.iBankService.Get(t => t.Code == bankCode);

            if (bank == null)
                throw new APIException(GuangDaExceptionOption.BankNotExists);

            bankCard.MemberID = memberID;
            bankCard.BankCardNumber = bankCardNumber;
            bankCard.Mobile = mobile;
            bankCard.BankID = bank.ID;
            bankCard.SubBranchName = bank.Name;

            iBankCardService.Save(bankCard);

            return bankCard;
        }

        /// <summary>
        /// 开户信息提交接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string CreateAccount(CreateAccountRequst request)
        {
            var result = new CreateAccountResponse() { requestno = request.requestno.Trim() };

            try
            {
                var member = iMemberService.Get(t => t.IDNumber == request.idnumber.Trim());

                if (member == null)
                    throw new APIException(GuangDaExceptionOption.MemberNotExists);


                if (merchant.AccountBank == AccountBankOption.GuangDa.ToInt())
                {
                    if (member.AccountGuangDa.IsCreateAccount == AccountStatus.NotCreate.ToInt())
                    {
                        member.Mobile = request.mobile.Trim();

                        member.AccountGuangDa.Address = request.address.Trim();
                        member.AccountGuangDa.EnName = member.Name.GetPinYin();
                        member.AccountGuangDa.Mobile = request.mobile.Trim();
                        member.AccountGuangDa.PostCode = request.postcode.Trim();
                        member.AccountGuangDa.ProvinceCode = request.provincecode.Trim();
                        member.AccountGuangDa.CityCode = request.citycode.Trim();
                        member.AccountGuangDa.Occupation = request.occupation.ToTrim();
                        member.AccountGuangDa.GuangDaArea = iGuangDaAreaService.GetGuangDaAreaByCity(request.citycode.Trim());

                        iAccountGuangDaService.Save(member.AccountGuangDa);

                        //创建待绑定银行卡
                        var bankCard = BankCardBinding(member.ID, member.Name.Trim(), member.IDNumber.Trim(), request.bankcardnumber.Trim(), request.mobile.Trim(), request.bankcode.Trim());

                        iMemberService.Commit();

                        //开户
                        var response = iGuangDaAPIService.CreateAccount(member, bankCard);

                        if ((response.IsOK && string.Equals(response?.Body?.State, "S", StringComparison.CurrentCultureIgnoreCase)) ||
                          response?.Head?.ResCode == "000455")
                        {
                            var check = iGuangDaAPIService.CreateAccountCheck(member);

                            if (check.IsOK)
                            {
                                member.AccountGuangDa.EAcNo = check.Body.EAcNo;
                                member.AccountGuangDa.IsCreateAccount = AccountStatus.Created.ToInt();

                                bankCard.Status = BankCardStatus.IsVerified.ToInt();
                                iBankCardService.Save(bankCard);

                                iMemberService.Save(member);
                                iMemberService.Commit();
                            }
                            else
                            {
                                member.AccountGuangDa.CoPatrnerJnlNo = GuidHelper.GenUniqueId();

                                iAccountGuangDaService.Save(member.AccountGuangDa);
                                iAccountGuangDaService.Commit();

                                throw new APIException(GuangDaExceptionOption.OpenAccountVerifyFail);
                            }
                        }
                        else
                        {
                            member.AccountGuangDa.CoPatrnerJnlNo = GuidHelper.GenUniqueId();

                            iAccountGuangDaService.Save(member.AccountGuangDa);
                            iAccountGuangDaService.Commit();

                            throw new APIException(GuangDaExceptionOption.OpenAccountFail);
                        }
                    }

                    //上传身份证
                    if (member.AccountGuangDa.IsCreateAccount == AccountStatus.Created.ToInt())
                    {
                        //开户
                        var response = iGuangDaAPIService.UploadIdCardImage(member);

                        if (response.IsOK)
                        {
                            member.AccountGuangDa.IsCreateAccount = AccountStatus.IDCardUpload.ToInt();

                            iAccountGuangDaService.Save(member.AccountGuangDa);
                            iAccountGuangDaService.Commit();
                        }
                        else
                        {
                            throw new APIException(GuangDaExceptionOption.OpenAccountUploadImageFail);
                        }
                    }

                }

                result.clientid = member.ClientId;
                result.memberid = member.ID.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }
            return JsonHelper.Serialize(result);
        }


        /// <summary>
        /// 银行列表查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetBankInfo(GetBankInfoRequst request)  //查询单个项目信息
        {
            var result = new GetBankInfoResponse() { requestno = request.requestno };

            try
            {
                var banklist = iBankService.Gets().ToList();

                result.bankinfo = new List<GetBankInfoResponse.BankInfo>();

                if (banklist.Count > 0)
                {
                    for (int i = 0; i < banklist.Count; i++)
                    {
                        result.bankinfo.Add(new GetBankInfoResponse.BankInfo()
                        {
                            code = banklist[i].Code,
                            name = banklist[i].Name
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 对私ECIF职业码制查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetECIF(GetGuangDaECIFRequst request)
        {
            var result = new GetGuangDaECIFResponse() { requestno = request.requestno };

            try
            {
                var eciflist = iGuangDaECIFService.Gets().ToList();

                result.guangDaECIF = new List<GetGuangDaECIFResponse.GuangDaECIF>();

                if (eciflist.Count > 0)
                {
                    for (int i = 0; i < eciflist.Count; i++)
                    {
                        result.guangDaECIF.Add(new GetGuangDaECIFResponse.GuangDaECIF()
                        {
                            code = eciflist[i].Code,
                            name = eciflist[i].Name,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }
            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 地区表查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetAreaInfo(GetAreaInfoRequst request)
        {
            var result = new GetAreaInfoResponse() { requestno = request.requestno };
            result.areainfo = new List<GetAreaInfoResponse.AreaInfo>();

            try
            {
                if (request.areacode == null)
                {
                    var arealist = iAreaGuangDaService.GetAllCache().Where(t => t.Code.EndsWith("0000")).ToList();

                    if (arealist.Count > 0)
                    {
                        for (int i = 0; i < arealist.Count; i++)
                        {
                            result.areainfo.Add(new GetAreaInfoResponse.AreaInfo()
                            {
                                code = arealist[i].Code,
                                name = arealist[i].Name
                            });
                        }
                    }

                }
                else
                {
                    var arealist = iAreaGuangDaService.GetAllCache().Where(t => t.Code.StartsWith(request.areacode.Trim().Substring(0, 2)) && t.Code != request.areacode.Trim()).ToList();

                    if (arealist.Count > 0)
                    {
                        for (int i = 0; i < arealist.Count; i++)
                        {
                            result.areainfo.Add(new GetAreaInfoResponse.AreaInfo()
                            {
                                code = arealist[i].Code,
                                name = arealist[i].Name
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 撤消
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Repeal(OrderPaidRepealRequst request)
        {
            var result = new OrderPaidRepealResponse() { requestno = request.requestno.Trim() };

            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderPaid == null)
                    throw new APIException(GuangDaExceptionOption.OrderNotExists);


                orderPaid.PayAction = OrderPaidPayActionOption.Repeal.ToInt();

                iOrderPaidService.Save(orderPaid);

                iOrderPaidService.Commit();

                iOrderPaidService.UnFreezeAndWithdraw(orderPaid); //客户端提现操作，先解冻再提现

                result.ordernumber = orderPaid.OrderNumber;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Recharge(OrderPailRechargeRequst request)
        {
            var result = new OrderPaidRechargeResponse() { requestno = request.requestno.Trim() };

            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderPaid == null)
                    throw new APIException(GuangDaExceptionOption.OrderNotExists);

                iOrderPaidService.Recharge(orderPaid);

                result.ordernumber = orderPaid.OrderNumber;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }


        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Freeze(OrderPaidFreezeRequst request)
        {
            var result = new OrderPaidFreezeResponse() { requestno = request.requestno.Trim() };

            try
            {
                var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderPaid == null)
                    throw new APIException(GuangDaExceptionOption.OrderNotExists);

                iOrderPaidService.Freeze(orderPaid);

                result.ordernumber = orderPaid.OrderNumber;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.retsultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }



    }
}
﻿using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using AIPXiaoTong.Model.PingAnAPI;
using Framework.Common;
using Framework.LambdaExpression;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AIPXiaoTong.Site.Controllers
{
    [AllowAnonymous]
    public class PingAnAPIController : Controller
    {
        public ILogger logger;
        private string key = "1234567890";
        private IEquipmentService iEquipmentService;
        private IMemberService iMemberService;
        private IEmployeeService iEmployeeService;
        private IProjectService iProjectService;
        private IPingAnAPIService iPingAnAPIService;
        private IOrderPaidService iOrderPaidService;
        private IPingAnOrderPaidService iPingAnOrderPaidService;
        private IAccountPingAnService iAccountPingAnService;
        private IOrderBookingService iOrderBookingService;
        private IHouseTypeShowService iHouseTypeShowService;
        private IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService;
        private IMerchantMemberService iMerchantMemberService;
        private IPreferencesService iPreferencesService;
        private ITLTPreferencesService iTLTPreferencesService;

        private static string channel = System.Configuration.ConfigurationManager.AppSettings["PingAn_Channel"].ToString();
        private static string orderValidDay = System.Configuration.ConfigurationManager.AppSettings["PingAn_OrderValidDay"].ToString();
        private static string freezeProduct = System.Configuration.ConfigurationManager.AppSettings["PingAn_FreezeProduct"].ToString();
        private static string autoFreeze = System.Configuration.ConfigurationManager.AppSettings["PingAn_AutoFreeze"].ToString();
        private static string preparedFreezeOrderTransCode = System.Configuration.ConfigurationManager.AppSettings["PingAn_PreparedFreezeOrderTransCode"].ToString();


        private long merchantID { get; set; }
        private Merchant merchant { get; set; }
        public PingAnAPIController(IEquipmentService iEquipmentService,
                                   IMemberService iMemberService,
                                   IEmployeeService iEmployeeService,
                                   IProjectService iProjectService,
                                   IPingAnAPIService iPingAnAPIService,
                                   IOrderPaidService iOrderPaidService,
                                   IPingAnOrderPaidService iPingAnOrderPaidService,
                                   IAccountPingAnService iAccountPingAnService,
                                   IOrderBookingService iOrderBookingService,
                                   IHouseTypeShowService iHouseTypeShowService,
                                   IPingAnOrderPaidRechargeService iPingAnOrderPaidRechargeService,
                                   IMerchantMemberService iMerchantMemberService,
                                   IPreferencesService iPreferencesService,
                                   ITLTPreferencesService iTLTPreferencesService)
        {
            this.iEquipmentService = iEquipmentService;
            this.iMemberService = iMemberService;
            this.iEmployeeService = iEmployeeService;
            this.iProjectService = iProjectService;
            this.iPingAnAPIService = iPingAnAPIService;
            this.iOrderPaidService = iOrderPaidService;
            this.iPingAnOrderPaidService = iPingAnOrderPaidService;
            this.iAccountPingAnService = iAccountPingAnService;
            this.iOrderBookingService = iOrderBookingService;
            this.iHouseTypeShowService = iHouseTypeShowService;
            this.iPingAnOrderPaidRechargeService = iPingAnOrderPaidRechargeService;
            this.iMerchantMemberService = iMerchantMemberService;
            this.iPreferencesService = iPreferencesService;
            this.iTLTPreferencesService = iTLTPreferencesService;

            logger = LogManager.GetCurrentClassLogger();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string content = Request.Form.ToString();

            if (string.IsNullOrWhiteSpace(content))
                content = Request.QueryString.ToString();


            logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + System.Threading.Thread.CurrentThread.ManagedThreadId + "|" + content);

            BaseResponse response = new BaseResponse();
            response.requestno = Request["requestno"] ?? "";

            //检查数据合法性
            if (!ModelState.IsValid)
            {
                response.resultcode = PingAnExceptionOption.DataError.ToInt().ToString();
                response.resultmsg = PingAnExceptionOption.DataError.ToDescription() + ModelState.Values.Where(t => t.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }

            //检查SN号
            var equipmentsnno = Request["equipmentsnno"];
            var equipment = iEquipmentService.Get(t => t.EquipmentSNNo == equipmentsnno);
            if (equipment == null)
            {
                response.resultcode = PingAnExceptionOption.PosUnbound.ToInt().ToString();
                response.resultmsg = PingAnExceptionOption.PosUnbound.ToDescription(); ;
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }
            else if (equipment.Status <= 0)
            {
                response.resultcode = PingAnExceptionOption.PosUnable.ToInt().ToString();
                response.resultmsg = PingAnExceptionOption.PosUnable.ToDescription() + equipment.StatusDesc;
                filterContext.Result = new JsonResult { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                logger.Trace("Action：" + filterContext.RouteData.Values["action"] + "|" + response.resultmsg);
                return;
            }
            else
            {
                merchantID = equipment.MerchantID;
                merchant = equipment.Merchant;
            }

            if (Request.Url.Host == "localhost")
                return;

            var result = Verify(content);

            if (!result)
            {
                response.resultcode = PingAnExceptionOption.VerifySignFail.ToInt().ToString();
                response.resultmsg = PingAnExceptionOption.VerifySignFail.ToDescription();
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
                    throw new APIException(PingAnExceptionOption.EmployeeNotExists.ToDescription());

                if (employee.Password != request.password)
                    throw new APIException(PingAnExceptionOption.PasswordError.ToDescription());

                var preferences = iPreferencesService.Get(t => t.MerchantID == merchantID);

                if (preferences == null)
                    throw new APIException(PingAnExceptionOption.NotSetVspParam);

                var TLTpreferences = iTLTPreferencesService.Get(t => t.MerchantID == merchantID);

                if (TLTpreferences == null)
                    throw new APIException(PingAnExceptionOption.NotSetTLTParam);

                result.employeecode = employee.Code;
                result.employeeid = employee.ID.ToString();
                result.merchantid = employee.MerchantID.ToString();
                result.merchantname = employee.MerchantName;
                result.vspcode = preferences.POSBaoMerchant;
                //  result.tltcode = TLTpreferences.TltMerchantId;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                    throw new APIException(PingAnExceptionOption.OrderNotExists);

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
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                    throw new APIException(PingAnExceptionOption.EmployeeNotExists.ToDescription());

                var orderBooking = iOrderBookingService.Get(t => t.OrderName == request.name.Trim() && t.OrderMobile == request.mobile.Trim());

                //if (orderBooking != null)   //一周内不允许重复预约
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
                result.resultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }


        /// <summary>
        ///平安银行创建订单（预下单接口），预下单完成返回免登地址及相关信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetPreparedFreezeOrder(GetPreparedFreezeOrderRequest request)
        {
            var result = new GetPreparedFreezeOrderResponse() { requestno = request.requestno.Trim() };

            try
            {
                var employee = iEmployeeService.Get(t => t.ID == request.employeeid && t.MerchantID == merchantID);

                if (employee == null)
                    throw new APIException(PingAnExceptionOption.EmployeeNotExists.ToDescription());

                var member = iMemberService.Get(t => t.IDNumber == request.cardnumber.Trim());

                if (member == null)
                    throw new APIException(PingAnExceptionOption.MemberNotExists.ToDescription());

                var project = iProjectService.Get(t => t.ID == request.projectid);

                if (project == null)
                    throw new APIException(PingAnExceptionOption.ProjectNotExists.ToDescription());

                if (DateTime.Now > project.Deadline && DateTime.Now < project.StartTime)
                    throw new Exception(PingAnExceptionOption.NotInDate.ToDescription());

                var orderPaid = new OrderPaid();
                var pingAnOrderPaid = new PingAnOrderPaid();

                orderPaid.MerchantID = merchantID;
                orderPaid.TransactionAmount = project.GuaranteeAmount;

                orderPaid.ProjectID = project.ID;
                orderPaid.EquipmentSNNo = request.equipmentsnno;
                orderPaid.EmployeeID = employee.ID;
                orderPaid.MemberID = member.ID;
                orderPaid.Member = member;
                orderPaid.Project = project;

                pingAnOrderPaid.OrderPaidID = orderPaid.ID;
                pingAnOrderPaid.Channel = channel;
                pingAnOrderPaid.ClientNo = "";
                pingAnOrderPaid.BusinessName = project.ProjectName;
                pingAnOrderPaid.OrderValidDay = Convert.ToInt32(orderValidDay); //订单确认有效天数      
                //冻结时间：当前时间至项目需要冻结的月数的总天数
                pingAnOrderPaid.FreezeTimeLimit = Convert.ToDateTime(DateTime.Now.AddMonths(project.GuaranteeMonth).AddDays(-1).ToShortDateString()).Subtract(Convert.ToDateTime(DateTime.Now.ToShortDateString())).Days;
                pingAnOrderPaid.FreezeProduct = Convert.ToInt32(freezeProduct); //止付产品 1-活期止付2-定期止付
                pingAnOrderPaid.AutoFreeze = autoFreeze; //到期是否自动解止付  00-是 01-否
                pingAnOrderPaid.TransCode = preparedFreezeOrderTransCode;

                var preparedFreezeOrderResponse = iPingAnAPIService.PreparedFreezeOrder(orderPaid, pingAnOrderPaid);

                if (preparedFreezeOrderResponse.IsOK)
                {
                    pingAnOrderPaid.BankOrderNo = preparedFreezeOrderResponse.dataObject.bankOrderNo;
                    pingAnOrderPaid.Status = PingAnOrderPaidStatusOption.Default.ToInt();

                    var autoLoginUrl = iPingAnAPIService.AutoLogin(pingAnOrderPaid, member);

                    if (!string.IsNullOrWhiteSpace(autoLoginUrl.autoLoginPath))
                    {
                        result.autologinurl = autoLoginUrl.autoLoginPath;
                        // pingAnOrderPaid.AutoLoginUrl = autoLoginUrl.autoLoginPath;
                    }
                    else
                    {
                        throw new APIException(PingAnExceptionOption.GetAutoLoginUrlFailed.ToDescription());
                    }

                    if (!iMerchantMemberService.Exists(t => t.MerchantID == merchantID && t.MemberID == member.ID))
                    {
                        var merchantMember = new MerchantMember();

                        merchantMember.MemberID = member.ID;
                        merchantMember.MerchantID = merchantID;

                        iMerchantMemberService.Save(merchantMember);
                        iMerchantMemberService.Commit();
                    }

                    iOrderPaidService.Save(orderPaid);
                    iPingAnOrderPaidService.Save(pingAnOrderPaid);

                    iOrderPaidService.Commit();

                }

                result.bankorderno = pingAnOrderPaid.BankOrderNo;
                result.orderpaidid = orderPaid.ID.ToString();
                result.ordernumber = orderPaid.OrderNumber;

                result.resultmsg = preparedFreezeOrderResponse.IsOK ? "" : preparedFreezeOrderResponse.responseMsg;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                var autoLoginUrl = "";
                var orderPaid = iOrderPaidService.Get(t => t.OrderNumber == request.ordernumber.Trim() && t.MerchantID == merchantID);

                if (orderPaid == null)
                    throw new APIException(PingAnExceptionOption.OrderNotExists.ToDescription());

                try
                {
                    iOrderPaidService.PingAnSyncStatus(orderPaid);
                    //更新免登地址(免登地址第二次进入则失效，需要重新生成免登地址)                 
                    autoLoginUrl = iOrderPaidService.UpdateAutoLoginUrl(orderPaid);
                    iOrderPaidService.Commit();
                }
                catch (Exception ex)
                {
                    result.generalinfo = "状态同步：" + ex.Message;
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
                result.bankcardnumber = orderPaid.Member?.AccountPingAn?.BankCardNumber;
                result.remark = orderPaid.Remark;
                result.status = orderPaid.Status.ToString();
                result.statusdesc = orderPaid.StatusDesc.ToString();
                result.createdatetime = orderPaid.CreateDatetime.ToString();
                result.employeeid = orderPaid.EmployeeID.ToString();
                result.employeename = orderPaid.EmployeeName;
                //---------------PingAnOrderPaid子表数据----------------------
                result.bankorderno = orderPaid.PingAnOrderPaid.BankOrderNo;
                // result.autologinurl = orderPaid.PingAnOrderPaid.AutoLoginUrl;
                result.autologinurl = autoLoginUrl;
                result.freezesuccesstime = orderPaid.PingAnOrderPaid.FreezeSuccessTime.ToString();

                if (!string.IsNullOrWhiteSpace(result.freezesuccesstime) && orderPaid.Status == OrderPaidStatusOption.FrozenSuccess.ToInt())
                {
                    result.unfrozentime = Convert.ToDateTime(orderPaid.PingAnOrderPaid.FreezeSuccessTime.ToString()).AddMonths(Convert.ToInt32(orderPaid.Project.GuaranteeMonth)).ToString("yyyy/MM/dd");
                }

            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 发起通联通代付业务
        /// </summary>
        /// <returns></returns>
        public string POSTltSingleOntimePay(POSTltSingleOntimePayRequest request)
        {
            var result = new POSTltSingleOntimePayResponse() { requestno = request.requestno.Trim() };

            try
            {
                var pingAnOrderPaidRecharge = iPingAnOrderPaidRechargeService.GetLast(t => t.OrderPaid.OrderNumber == request.ordernumber && t.OrderPaid.MerchantID == merchantID);

                if (pingAnOrderPaidRecharge == null)
                    throw new APIException(PingAnExceptionOption.OrderNotExists.ToDescription());

                if (pingAnOrderPaidRecharge.OrderPaid.Status == OrderPaidStatusOption.SingleOntimePayFail.ToInt())
                {
                    iOrderPaidService.PingAnTltSingleOntimePay(pingAnOrderPaidRecharge.OrderPaid);
                }
                else
                {
                    throw new Exception("当前状态" + ((OrderPaidStatusOption)pingAnOrderPaidRecharge.OrderPaid.Status).ToDescription() + "不可操作");
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                        createdatetime = list[i].CreateDatetime.ToString(),
                        //---------------PingAnOrderPaid子表数据----------------------
                        bankorderno = list[i].PingAnOrderPaid.BankOrderNo,
                        //autologinurl = list[i].PingAnOrderPaid.AutoLoginUrl,
                        freezesuccesstime = list[i].PingAnOrderPaid.FreezeSuccessTime.ToString(),
                    });
                }

                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iOrderPaidService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                    throw new APIException(PingAnExceptionOption.ProjectNotExists.ToDescription());

                if (project.AdvertisingImge != null)
                {
                    var advertisingimgelists = JsonHelper.Deserialize<List<string>>(project.AdvertisingImge).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                    for (int i = 0; i < advertisingimgelists.Count(); i++)
                    {
                        advertisingimgelists[i] = siteImageUrl + advertisingimgelists[i].Replace("\\", "/");
                    }
                    result.advertisingimgelist = advertisingimgelists.ToList();
                    result.projectimage = advertisingimgelists.FirstOrDefault().Replace("\\", "/");
                }

                result.merchantid = project.MerchantID.ToString();
                result.merchantname = project.MerchantName;
                result.projectid = project.ID.ToString();
                result.projectname = project.ProjectName;
                result.projectamount = project.ProjectAmount.ToString();
                result.residueamount = project.ResidueAmount.ToString();
                result.deadline = project.Deadline.ToString();
                result.starttime = project.StartTime.ToString();
                result.description = project.Description;
                result.provincecode = project.ProvinceCode;
                result.provincename = project.ProvinceName;
                result.citycode = project.CityCode;
                result.cityname = project.CityName;
                result.status = project.Status.ToString();
                result.statusdesc = project.StatusDesc;
                result.reason = project.Reason;
                result.guaranteeamount = project.GuaranteeAmount.ToString();
                result.guaranteemonth = project.GuaranteeMonth.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                        advertisingimgelist = JsonHelper.Deserialize<List<string>>(list[i].AdvertisingImge),
                        reason = list[i].Reason,
                        starttime = list[i].StartTime.ToString(),
                        guaranteeamount = list[i].GuaranteeAmount.ToString(),
                        guaranteemonth = list[i].GuaranteeMonth.ToString(),

                    });
                }
                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iProjectService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                    throw new APIException(PingAnExceptionOption.OrderNotExists.ToDescription());

                result.merchantid = houseTypeShow.MerchantID.ToString();
                result.merchantname = houseTypeShow.MerchantName;
                result.projectid = houseTypeShow.ProjectID.ToString();
                result.projectname = houseTypeShow.ProjectName;
                result.housetypeshowid = houseTypeShow.ID.ToString();
                result.housetypename = houseTypeShow.HouseTypeName;

                result.housetypearea = houseTypeShow.HouseTypeArea.ToString();

                result.content = houseTypeShow.Content;

                if (houseTypeShow.HouseShowImage != null)
                {
                    var houseshowimagelists = JsonHelper.Deserialize<List<string>>(houseTypeShow.HouseShowImage).Where(s => !string.IsNullOrEmpty(s)).ToArray();

                    for (int i = 0; i < houseshowimagelists.Count(); i++)
                    {
                        houseshowimagelists[i] = siteImageUrl + houseshowimagelists[i].Replace("\\", "/");
                    }
                    result.houseshowimagelist = houseshowimagelists.ToList();
                    result.housethumbnailimage = houseshowimagelists.FirstOrDefault().Replace("\\", "/");
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                        content = list[i].Content,
                        housethumbnailimage = list[i].HouseShowImageList.FirstOrDefault().Replace("\\", "/"),
                        houseshowimagelist = JsonHelper.Deserialize<List<string>>(list[i].HouseShowImage),
                    });
                }
                result.pageindex = request.pageindex.ToInt();
                result.pagesize = request.pagesize.ToInt();
                result.pagecount = Convert.ToInt32(Math.Ceiling(iHouseTypeShowService.Count(express) * 1.0 / request.pagesize.ToInt()));
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
            var result = new CreateMemberResponse() { requestno = request.requestno };

            try
            {
                var member = iMemberService.Get(t => t.IDNumber == request.idnumber.Trim());

                if (member != null)
                    throw new APIException(PingAnExceptionOption.MemberIsCreate.ToDescription());


                member = new Member();

                var IDImageFrontPath = GlobalConfig.WebConfig.PingAn_IDImagesPath + Guid.NewGuid() + ".jpg";
                var IDImageOppositePath = GlobalConfig.WebConfig.PingAn_IDImagesPath + Guid.NewGuid() + ".jpg";

                ImageHelper.Base64StringToImage(Server.MapPath(IDImageFrontPath), request.idimagefront);
                ImageHelper.Base64StringToImage(Server.MapPath(IDImageOppositePath), request.idimageopposite);

                member.Name = request.name.Trim();
                member.IDNumber = request.idnumber.Trim();
                member.Mobile = request.mobile.Trim();

                if (merchant.AccountBank == AccountBankOption.PingAn.ToInt())
                {
                    var account = new AccountPingAn();

                    account.IdExpiredDate = request.idexpireddate.ToDateTime("yyyyMMdd");
                    account.Mobile = request.mobile.Trim();

                    account.IDImageFront = IDImageFrontPath;
                    account.IDImageOpposite = IDImageOppositePath;

                    iAccountPingAnService.Save(account);
                }

                iMemberService.Save(member);
                iMemberService.Commit();



                result.memberid = member.ID.ToString();
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
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
                    throw new APIException(PingAnExceptionOption.MemberNotExists.ToDescription());

                result.name = member.Name;
                result.memberid = member.ID;
                result.mobile = member.Mobile;
                result.idnumber = member.IDNumber;

                if (merchant.AccountBank == AccountBankOption.PingAn.ToInt())
                {
                    result.bankcardnumber = member.AccountPingAn?.BankCardNumber;
                }
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }

        /// <summary>
        /// 撤消(判断订单存在--查询平安端订单状态--解止付平安端订单--修改小通订单状态)
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
                    throw new APIException(PingAnExceptionOption.OrderNotExists.ToDescription());

                orderPaid.PayAction = OrderPaidPayActionOption.Repeal.ToInt();

                iOrderPaidService.Save(orderPaid);

                iOrderPaidService.Commit();

                iOrderPaidService.UnFreezePingAnMargins(orderPaid);

                result.ordernumber = orderPaid.OrderNumber;
            }
            catch (Exception ex)
            {
                result.resultmsg = ex.Message;
                result.resultcode = (ex as APIException)?.ErrorCode;
            }

            return JsonHelper.Serialize(result);
        }
    }
}
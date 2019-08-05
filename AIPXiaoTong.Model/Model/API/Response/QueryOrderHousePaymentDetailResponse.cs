﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class QueryOrderHousePaymentDetailResponse : BaseResponse
    {
        private string _orderhousepaymentid { get; set; }
        private string _ordernumber { get; set; }
        private string _merchantid { get; set; }
        private string _merchantname { get; set; }
        private string _projectid { get; set; }
        private string _projectname { get; set; }
        private string _equipmentsnno { get; set; }
        private string _transactionamount { get; set; }
        private string _serialnumber { get; set; }
        private string _memberid { get; set; }
        private string _membername { get; set; }
        private string _membermobile { get; set; }
        private string _memberidnumber { get; set; }
       // private string _paymentstatus { get; set; }
       // private string _paymentstatusdesc { get; set; }
        private string _paymenttype { get; set; }
        private string _paymenttypedesc { get; set; }
        private string _status { get; set; }
        private string _statusdesc { get; set; }
        private string _createdatetime { get; set; }
        private string _bankcardnumber { get; set; }
        private string _employeeid { get; set; }
        private string _employeename { get; set; }
        private string _remark { get; set; }


        //------------------------------------------------------

         public string orderhousepaymentid { get { return !string.IsNullOrWhiteSpace(_orderhousepaymentid) ? _orderhousepaymentid : ""; } set { _orderhousepaymentid = value; } }
        public string ordernumber { get { return !string.IsNullOrWhiteSpace(_ordernumber) ? _ordernumber : ""; } set { _ordernumber = value; } }
        public string merchantid { get { return !string.IsNullOrWhiteSpace(_merchantid) ? _merchantid : ""; } set { _merchantid = value; } }
        public string merchantname { get { return !string.IsNullOrWhiteSpace(_merchantname) ? _merchantname : ""; } set { _merchantname = value; } }
        public string projectid { get { return !string.IsNullOrWhiteSpace(_projectid) ? _projectid : ""; } set { _projectid = value; } }
        public string projectname { get { return !string.IsNullOrWhiteSpace(_projectname) ? _projectname : ""; } set { _projectname = value; } }
        public string equipmentsnno { get { return !string.IsNullOrWhiteSpace(_equipmentsnno) ? _equipmentsnno : ""; } set { _equipmentsnno = value; } }
        public string transactionamount { get { return !string.IsNullOrWhiteSpace(_transactionamount) ? _transactionamount : ""; } set { _transactionamount = value; } }
        public string serialnumber { get { return !string.IsNullOrWhiteSpace(_serialnumber) ? _serialnumber : ""; } set { _serialnumber = value; } }
      //  public string paymentstatus { get { return !string.IsNullOrWhiteSpace(_paymentstatus) ? _paymentstatus : ""; } set { _paymentstatus = value; } }
      //  public string paymentstatusdesc { get { return !string.IsNullOrWhiteSpace(_paymentstatusdesc) ? _paymentstatusdesc : ""; } set { _paymentstatusdesc = value; } }
        public string paymenttype { get { return !string.IsNullOrWhiteSpace(_paymenttype) ? _paymenttype : ""; } set { _paymenttype = value; } }
        public string paymenttypedesc { get { return !string.IsNullOrWhiteSpace(_paymenttypedesc) ? _paymenttypedesc : ""; } set { _paymenttypedesc = value; } }
        public string status { get { return !string.IsNullOrWhiteSpace(_status) ? _status : ""; } set { _status = value; } }
        public string statusdesc { get { return !string.IsNullOrWhiteSpace(_statusdesc) ? _statusdesc : ""; } set { _statusdesc = value; } }
        public string createdatetime { get { return !string.IsNullOrWhiteSpace(_createdatetime) ? _createdatetime : ""; } set { _createdatetime = value; } }
        public string membername { get { return !string.IsNullOrWhiteSpace(_membername) ? _membername : ""; } set { _membername = value; } }
        public string memberid { get { return !string.IsNullOrWhiteSpace(_memberid) ? _memberid : ""; } set { _memberid = value; } }
        public string membermobile { get { return !string.IsNullOrWhiteSpace(_membermobile) ? _membermobile : ""; } set { _membermobile = value; } }
        public string memberidnumber { get { return !string.IsNullOrWhiteSpace(_memberidnumber) ? _memberidnumber : ""; } set { _memberidnumber = value; } }

        public string bankcardnumber { get { return !string.IsNullOrWhiteSpace(_bankcardnumber) ? _bankcardnumber : ""; } set { _bankcardnumber = value; } }
        public string employeeid { get { return !string.IsNullOrWhiteSpace(_employeeid) ? _employeeid : ""; } set { _employeeid = value; } }
        public string employeename { get { return !string.IsNullOrWhiteSpace(_employeename) ? _employeename : ""; } set { _employeename = value; } }
        public string remark { get { return !string.IsNullOrWhiteSpace(_remark) ? _remark : ""; } set { _remark = value; } }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class OntimePayLM : BaseListModel
    {
        public string SerialNumber { get; set; }
        public long? OrderPaidID { get; set; }
        public decimal Amount { get; set; }
        public string TransNumber { get; set; }
        public DateTime? TransTime { get; set; }
        public string BankCardNumber { get; set; }
        public string OutCardNo { get; set; }
        public string AccountName { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string IDNumber { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string AccountProp { get; set; }
        public string UnionBank { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string RechargeIDNumber { get; set; }
        public string OrderNumber { get; set; }
        public string StatusDesc { get; set; }
    }
}

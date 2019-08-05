using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OntimePayQM : BaseQueryModel
    {
        public string OrderNumber { get; set; }
        public string BankCardNumber { get; set; }
        public DateTime? TransTime { get; set; }
        public string RechargeIDNumber { get; set; }
        public string RechargeName { get; set; }
    }
}

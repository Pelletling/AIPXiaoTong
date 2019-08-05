using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OrderHousePaymentQM : BaseQueryModel
    {
        public string OrderNumber { get; set; }

        public string ProjectName { get; set; }

        public string SerialNumber { get; set; }

        public string MemberName { get; set; }

    }
}

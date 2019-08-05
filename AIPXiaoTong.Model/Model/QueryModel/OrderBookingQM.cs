using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class OrderBookingQM : BaseQueryModel
    {
        public string OrderNumber { get; set; }
        public string OrderMobile { get; set; }

        public string OrderName { get; set; }

        public long? ProjectID { get; set; }
        public DateTime? QueryDate { get; set; }

    }
}

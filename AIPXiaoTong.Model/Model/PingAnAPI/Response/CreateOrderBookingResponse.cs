using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class CreateOrderBookingResponse:BaseResponse
    {
        private string _orderbookingid { get; set; }

        private string _ordernumber { get; set; }

        //----------------------------------------------------------------------
        public string orderbookingid { get { return !string.IsNullOrWhiteSpace(_orderbookingid) ? _orderbookingid : ""; } set { _orderbookingid = value; } }

        public string ordernumber { get { return !string.IsNullOrWhiteSpace(_ordernumber) ? _ordernumber : ""; } set { _ordernumber = value; } }
    }
}

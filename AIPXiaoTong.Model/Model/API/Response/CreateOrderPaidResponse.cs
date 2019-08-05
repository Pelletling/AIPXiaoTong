using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class CreateOrderPaidResponse : BaseResponse
    {
         private string _orderpaidid { get; set; }

        private string _ordernumber { get; set; }

        //----------------------------------------------------------------------
          public string orderpaidid { get { return !string.IsNullOrWhiteSpace(_orderpaidid) ? _orderpaidid : ""; } set { _orderpaidid = value; } }

        public string ordernumber { get { return !string.IsNullOrWhiteSpace(_ordernumber) ? _ordernumber : ""; } set { _ordernumber = value; } }
    }
}

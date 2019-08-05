using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class GetPreparedFreezeOrderResponse : BaseResponse
    {
        private string _bankorderno { get; set; }
        private string _orderpaidid { get; set; }
        private string _autologinurl { get; set; }
        private string _ordernumber { get; set; }

        //---------------------------------------------------

        public string autologinurl { get { return !string.IsNullOrWhiteSpace(_autologinurl) ? _autologinurl : ""; } set { _autologinurl = value; } }
        public string bankorderno { get { return !string.IsNullOrWhiteSpace(_bankorderno) ? _bankorderno : ""; } set { _bankorderno = value; } }
        public string orderpaidid { get { return !string.IsNullOrWhiteSpace(_orderpaidid) ? _orderpaidid : ""; } set { _orderpaidid = value; } }
        public string ordernumber { get { return !string.IsNullOrWhiteSpace(_ordernumber) ? _ordernumber : ""; } set { _ordernumber = value; } }

    }
}

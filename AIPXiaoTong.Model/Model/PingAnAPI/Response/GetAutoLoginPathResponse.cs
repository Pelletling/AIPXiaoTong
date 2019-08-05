using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class GetAutoLoginPathResponse : BaseResponse
    {
        private string _autologinurl { get; set; }

        //---------------------------------------------------

        public string autologinurl { get { return !string.IsNullOrWhiteSpace(_autologinurl) ? _autologinurl : ""; } set { _autologinurl = value; } }

    }
}

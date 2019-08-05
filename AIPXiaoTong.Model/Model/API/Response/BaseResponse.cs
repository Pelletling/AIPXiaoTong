using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class BaseResponse
    {
        private string _requestno { get; set; }
        private string _resultstatus { get; set; }
        private string _resultmsg { get; set; }
        private string _retsultcode { get; set; }


        //------------------------------------------------

        public string requestno { get { return !string.IsNullOrWhiteSpace(_requestno) ? _requestno : ""; } set { _requestno = value; } }

        public string resultstatus { get { return !string.IsNullOrWhiteSpace(_resultmsg) ? "error" : "ok"; } set { _resultstatus = value; } }

        public string resultmsg { get { return !string.IsNullOrWhiteSpace(_resultmsg) ? _resultmsg : ""; } set { _resultmsg = value; } }
        public string retsultcode { get { return !string.IsNullOrWhiteSpace(_retsultcode) ? _retsultcode : ""; } set { _retsultcode = value; } }
    }
}

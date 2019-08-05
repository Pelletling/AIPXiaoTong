using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class LoginResponse : BaseResponse
    {
        private string _employeecode { get; set; }
        private string _employeeid { get; set; }
        private string _merchantid { get; set; }
        private string _merchantname { get; set; }
        private string _vspcode { get; set; }
        // private string _tltcode { get; set; }
        //---------------------------------------------------

        public string employeecode { get { return !string.IsNullOrWhiteSpace(_employeecode) ? _employeecode : ""; } set { _employeecode = value; } }

        public string employeeid { get { return !string.IsNullOrWhiteSpace(_employeeid) ? _employeeid : ""; } set { _employeeid = value; } }

        public string merchantid { get { return !string.IsNullOrWhiteSpace(_merchantid) ? _merchantid : ""; } set { _merchantid = value; } }
        public string merchantname { get { return !string.IsNullOrWhiteSpace(_merchantname) ? _merchantname : ""; } set { _merchantname = value; } }
        public string vspcode { get { return !string.IsNullOrWhiteSpace(_vspcode) ? _vspcode : ""; } set { _vspcode = value; } }
        //  public string tltcode { get { return !string.IsNullOrWhiteSpace(_tltcode) ? _tltcode : ""; } set { _tltcode = value; } }
    }
}

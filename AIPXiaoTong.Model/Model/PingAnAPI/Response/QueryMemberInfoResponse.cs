using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryMemberInfoResponse : BaseResponse
    {
        private string _mobile { get; set; }
        private string _idnumber { get; set; }
        private string _name { get; set; }
      //  private string _idimagefront { get; set; }
       // private string _idimageopposite { get; set; }
      //  private string _clientid { get; set; }
      //  private string _idexpireddate { get; set; }
      //  private string _iscreateaccount { get; set; }
        private string _bankcardnumber { get; set; }
       // private string _status { get; set; }
       // private string _statusdesc { get; set; }





        //-----------------------------------------

        public long memberid { get; set; }
        public string mobile { get { return !string.IsNullOrWhiteSpace(_mobile) ? _mobile : ""; } set { _mobile = value; } }
        public string idnumber { get { return !string.IsNullOrWhiteSpace(_idnumber) ? _idnumber : ""; } set { _idnumber = value; } }
        public string name { get { return !string.IsNullOrWhiteSpace(_name) ? _name : ""; } set { _name = value; } }
       // public string idimagefront { get { return !string.IsNullOrWhiteSpace(_idimagefront) ? _idimagefront : ""; } set { _idimagefront = value; } }
       // public string idimageopposite { get { return !string.IsNullOrWhiteSpace(_idimageopposite) ? _idimageopposite : ""; } set { _idimageopposite = value; } }
       // public string clientid { get { return !string.IsNullOrWhiteSpace(_clientid) ? _clientid : ""; } set { _clientid = value; } }
      //  public string idexpireddate { get { return !string.IsNullOrWhiteSpace(_idexpireddate) ? _idexpireddate : ""; } set { _idexpireddate = value; } }
        public string bankcardnumber { get { return !string.IsNullOrWhiteSpace(_bankcardnumber) ? _bankcardnumber : ""; } set { _bankcardnumber = value; } }
       // public string status { get { return !string.IsNullOrWhiteSpace(_status) ? _status : ""; } set { _status = value; } }
      //  public string statusdesc { get { return !string.IsNullOrWhiteSpace(_statusdesc) ? _statusdesc : ""; } set { _statusdesc = value; } }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class QueryMemberInfoResponse : BaseResponse
    {
        private string _mobile { get; set; }
        private string _idnumber { get; set; }
        private string _name { get; set; }
        private string _provincecode { get; set; }
        private string _provincename { get; set; }
        private string _citycode { get; set; }
        private string _cityname { get; set; }
        private string _idimagefront { get; set; }
        private string _idimageopposite { get; set; }
        private string _address { get; set; }
        private string _clientid { get; set; }
        private string _enname { get; set; }

        private string _idexpireddate { get; set; }
        private string _postcode { get; set; }
        private string _iscreateaccount { get; set; }
        private string _iscreateaccountdesc { get; set; }
        private string _bankcardnumber { get; set; }
        private string _subbranchname { get; set; }
        private string _status { get; set; }
        private string _statusdesc { get; set; }




        //-----------------------------------------

        public long memberid { get; set; }
        public string mobile { get { return !string.IsNullOrWhiteSpace(_mobile) ? _mobile : ""; } set { _mobile = value; } }
        public string idnumber { get { return !string.IsNullOrWhiteSpace(_idnumber) ? _idnumber : ""; } set { _idnumber = value; } }
        public string name { get { return !string.IsNullOrWhiteSpace(_name) ? _name : ""; } set { _name = value; } }
        public string provincecode { get { return !string.IsNullOrWhiteSpace(_provincecode) ? _provincecode : ""; } set { _provincecode = value; } }
        public string provincename { get { return !string.IsNullOrWhiteSpace(_provincename) ? _provincename : ""; } set { _provincename = value; } }
        public string citycode { get { return !string.IsNullOrWhiteSpace(_citycode) ? _citycode : ""; } set { _citycode = value; } }
        public string cityname { get { return !string.IsNullOrWhiteSpace(_cityname) ? _cityname : ""; } set { _cityname = value; } }
        public string idimagefront { get { return !string.IsNullOrWhiteSpace(_idimagefront) ? _idimagefront : ""; } set { _idimagefront = value; } }
        public string idimageopposite { get { return !string.IsNullOrWhiteSpace(_idimageopposite) ? _idimageopposite : ""; } set { _idimageopposite = value; } }
        public string address { get { return !string.IsNullOrWhiteSpace(_address) ? _address : ""; } set { _address = value; } }
        public string clientid { get { return !string.IsNullOrWhiteSpace(_clientid) ? _clientid : ""; } set { _clientid = value; } }
        public string enname { get { return !string.IsNullOrWhiteSpace(_enname) ? _enname : ""; } set { _enname = value; } }
        public string idexpireddate { get { return !string.IsNullOrWhiteSpace(_idexpireddate) ? _idexpireddate : ""; } set { _idexpireddate = value; } }
        public string postcode { get { return !string.IsNullOrWhiteSpace(_postcode) ? _postcode : ""; } set { _postcode = value; } }
        public string iscreateaccount { get { return !string.IsNullOrWhiteSpace(_iscreateaccount) ? _iscreateaccount : ""; } set { _iscreateaccount = value; } }
        public string iscreateaccountdesc { get { return !string.IsNullOrWhiteSpace(_iscreateaccountdesc) ? _iscreateaccountdesc : ""; } set { _iscreateaccountdesc = value; } }
        public string bankcardnumber { get { return !string.IsNullOrWhiteSpace(_bankcardnumber) ? _bankcardnumber : ""; } set { _bankcardnumber = value; } }
        public string subbranchname { get { return !string.IsNullOrWhiteSpace(_subbranchname) ? _subbranchname : ""; } set { _subbranchname = value; } }
        public string status { get { return !string.IsNullOrWhiteSpace(_status) ? _status : ""; } set { _status = value; } }
        public string statusdesc { get { return !string.IsNullOrWhiteSpace(_statusdesc) ? _statusdesc : ""; } set { _statusdesc = value; } }

        public decimal balance { get; set; }
        public decimal freezebalance { get; set; }



    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class UploadIDCardImgResponse : BaseResponse
    {
        private string _memberid { get; set; }

        //---------------------------------------------------
        public string memberid { get { return !string.IsNullOrWhiteSpace(_memberid) ? _memberid : ""; } set { _memberid = value; } }
    }
}

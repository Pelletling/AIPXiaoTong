﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Security;

namespace PingAnAPI.Model
{
    public class BaseResponse
    {
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public string data { get; set; }

        public bool IsOK { get { return responseCode == "000000" ? true : false; } }
    }
}

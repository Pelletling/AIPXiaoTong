﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TltApi.Model
{
    public class BaseResponse
    {
        //public bool IsVerify
        //{
        //    get
        //    {
        //        //验签
        //        var signMsgStartIndex = result.IndexOf("<SIGNED_MSG>");
        //        var signMsgEndIndex = result.IndexOf("</SIGNED_MSG>");
        //        string responseString = result.Substring(0, signMsgStartIndex) + result.Substring(signMsgEndIndex + "</SIGNED_MSG>".Length);

        //        string responseMsg = result.Substring(signMsgStartIndex + "<SIGNED_MSG>".Length, signMsgEndIndex - signMsgStartIndex - "<SIGNED_MSG>".Length);

        //        bool checkResult = Framework.Security.Crypt.RSADecryptByPublicKey(responseString, responseMsg, TltConfig.publicKey);

        //        return checkResult;
        //    }
        //}

        //public string result { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace AIPXiaoTong.Model
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message)
        {

        }
        public APIException(GuangDaExceptionOption exceptionOption) : base(exceptionOption.ToDescription())
        {
            ErrorCode = exceptionOption.ToInt().ToString();
        }

        public APIException(PingAnExceptionOption exceptionOption) : base(exceptionOption.ToDescription())
        {
            ErrorCode = exceptionOption.ToInt().ToString();
        }

        public virtual string ErrorCode { get; set; }

        //public new string Message { get; set; }
    }
}

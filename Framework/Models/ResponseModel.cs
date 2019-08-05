using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Models
{
   public class ResponseModel
    {
        public long? ID { get; set; }

        private string resultMessage;
        public int ResultCode { get; set; }

        public string ResultMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(resultMessage))
                {
                    return "";
                }

                return resultMessage;
            }
            set
            {
                this.resultMessage = value;
            }
        }
    }
}

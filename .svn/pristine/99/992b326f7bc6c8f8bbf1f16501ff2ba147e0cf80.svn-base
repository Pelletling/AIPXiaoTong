using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class BaseJsonModel : BaseModel
    {
        private string resultMessage;

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

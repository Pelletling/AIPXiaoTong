using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class BaseListModel : BaseModel
    {
        public long ID { get; set; }

        public int Status { get; set; }        

        public DateTime CreateDatetime { get; set; }
        

        public DateTime? ModifyDatetime { get; set; }

        public string CreateUserName { get; set; }
        public string ModifyUserName { get; set; }
    }
}

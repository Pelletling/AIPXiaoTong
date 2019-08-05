using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class EmployeeRoleLM : BaseListModel
    {
        public long MerchantID { get; set; }
        public string Name { get; set; }
        public string StatusDesc { get; set; }
    }
}

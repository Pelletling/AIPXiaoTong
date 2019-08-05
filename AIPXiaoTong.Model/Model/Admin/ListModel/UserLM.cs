using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{

    public class UserLM : BaseListModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        public string RoleName { get; set; }

        public string RealName { get; set; }

        public string Mobile { get; set; }        

        public string DepartmentName { get; set; }

        public string Email { get; set; }
        public string StatusDesc { get; set; }
        

    }
}

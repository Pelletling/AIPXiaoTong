using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class EmployeeLM : BaseListModel
    {
        public string MerchantCode { get; set; }
        
        public string MerchantName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        public string EmployeeRoleName { get; set; }

        public string EmployeeDepartmentName { get; set; }

        public string StatusDesc { get; set; }

    }
}

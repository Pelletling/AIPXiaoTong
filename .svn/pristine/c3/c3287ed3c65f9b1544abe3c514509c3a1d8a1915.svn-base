using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IEmployeeService : IBusinessService<Employee>
    {
        LoginStatus Login(LoginModel currentUser);

        void CacheCurrnetUser(Employee user);

        CurrentUser ConvertCurrentUser(Employee user);

        List<Employee> GetAuthList();
    }
}

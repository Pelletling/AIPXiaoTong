using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Admin;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IUserService : IBusinessService<User>
    {
        LoginStatus Login(LoginModel currentUser);

        void CacheCurrnetUser(User user);

        CurrentUser ConvertCurrentUser(User user);

        List<User> GetAuthList();
    }
}

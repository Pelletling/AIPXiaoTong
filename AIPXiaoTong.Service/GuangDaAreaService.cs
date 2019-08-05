using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Cache;
using Framework.Common;
using Framework.LambdaExpression;
using Framework.Web.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace AIPXiaoTong.Service
{
    public class GuangDaAreaService : BusinessService<GuangDaArea>, IGuangDaAreaService
    {

        public GuangDaArea GetGuangDaAreaByCity(string cityCode)
        {
            var iAreaGuangDaService = DIFactory.GetContainer().Resolve<IAreaGuangDaService>();

            var city = iAreaGuangDaService.Get(t => t.Code == cityCode);

            if (city == null)
                throw new Exception("城市代码不存在");

            var guangDaArea = Get(t=>t.Name.Contains(city.Name));

            ///若查找不到，则默认为“全国”
            if (guangDaArea == null)
            {
                guangDaArea = Get(t => t.Code == "9999");
            }

            return guangDaArea;
        }

    }
}

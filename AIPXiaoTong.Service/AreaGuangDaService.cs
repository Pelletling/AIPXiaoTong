using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Cache;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class AreaGuangDaService : BusinessService<AreaGuangDa>, IAreaGuangDaService
    {
        private List<AreaGuangDaModel> GetAll()
        {
            var all = Gets().Select(t => new AreaGuangDaModel
            {
                ID = t.ID,
                Code = t.Code,
                Name = t.Name,
                ParentCode = t.ParentCode,
                Level = t.Level,
            }).ToList();

            return all;
        }
        public void SetCache(List<AreaGuangDaModel> list)
        {
            if (list == null)
                list = GetAll();

            CacheHelper.SetCache(CacheKey.Area.ToString(), list, DateTime.Now.AddYears(1));
        }

        public List<AreaGuangDaModel> GetAllCache()
        {
            var list = CacheHelper.GetCache(CacheKey.Area.ToString()) as List<AreaGuangDaModel>;

            if (list == null)
            {
                list = GetAll();
                SetCache(list);
            }

            return list;
        }
    }
}

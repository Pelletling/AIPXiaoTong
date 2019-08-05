using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Service
{
    public class AreaService : BusinessService<Area>, IAreaService
    {
        private List<AreaModel> GetAll()
        {
            var all = Gets().Select(t => new AreaModel
            {
                ID = t.ID,
                Code = t.Code,
                Name = t.Name,
                ParentCode = t.ParentCode,
                Level = t.Level,
            }).ToList();

            return all;
        }
        public void SetCache(List<AreaModel> list)
        {
            if (list == null)
                list = GetAll();

            CacheHelper.SetCache(CacheKey.Area.ToString(), list, DateTime.Now.AddYears(1));
        }

        public List<AreaModel> GetAllCache()
        {
            var list = CacheHelper.GetCache(CacheKey.Area.ToString()) as List<AreaModel>;

            if (list == null)
            {
                list = GetAll();
                SetCache(list);
            }

            return list;
        }
    }
}

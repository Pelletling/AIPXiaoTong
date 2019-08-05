﻿using AIPXiaoTong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IAreaGuangDaService:IBusinessService<AreaGuangDa>
    {
        void SetCache(List<AreaGuangDaModel> list = null);

        List<AreaGuangDaModel> GetAllCache();
    }
}

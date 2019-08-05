using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class GetAreaInfoResponse:BaseResponse
    {
        public List<AreaInfo> areainfo { get; set; }

        public class AreaInfo
        {
            public string code { get; set; }
            public string name { get; set; }
        }
    }
}

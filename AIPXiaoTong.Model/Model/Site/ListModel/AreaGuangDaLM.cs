using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class AreaGuangDaLM : BaseListModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上级编码
        public string ParentCode { get; set; }

        /// <summary>
        /// 等级  
        /// </summary> 
        public int Level { get; set; }
    }
}

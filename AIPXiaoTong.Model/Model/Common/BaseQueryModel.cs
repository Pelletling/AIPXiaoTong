using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{
    public class BaseQueryModel : BaseModel
    {
        public int? Status { get; set; }

        public virtual int ID { get; set; }
        private int pageSize { get; set; }

        public int PageIndex
        {
            get { return ID; }
            set { ID = value; }
        }

        public int PageSize
        {
            get
            {
                if (pageSize == 0)
                    return GlobalConfig.PageSize;
                else
                    return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public bool IsNotTracking { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }
        
    }
}

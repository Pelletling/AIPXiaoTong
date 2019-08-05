using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryHouseTypeShowListRequst:BaseRequest
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        [Display(Name = "项目ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long? projectid { get; set; }

        /// <summary>
        /// 户型名称
        /// </summary>
        [Display(Name = "户型名称")]
        public string houstypename { get; set; }


        private int? _pageindex { get; set; }
        public int? pageindex
        {
            get { return _pageindex > 0 ? _pageindex : 1; }
            set { _pageindex = value; }
        }


        private int? _pagesize { get; set; }
        public int? pagesize
        {
            get { return _pagesize > 0 ? _pagesize : GlobalConfig.PageSize; }
            set { _pagesize = value; }
        }

    }
}

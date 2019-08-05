using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.PingAnAPI
{
    public class QueryProjectDetailRequst:BaseRequest
    {
        /// <summary>
        /// 项目id
        /// </summary>
        [Display(Name = "项目id")]
        [Required(ErrorMessage = "项目ID不能为空")]
        public long? projectid { get; set; }
    }
}

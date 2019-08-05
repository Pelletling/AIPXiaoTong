using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class QueryHouseTypeShowDetailRequst:BaseRequest
    {    
        /// <summary>
        /// 户型ID
        /// </summary>
        [Display(Name = "户型ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long housetypeshowid { get; set; }

    }
}

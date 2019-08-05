using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.API
{
    public class BaseRequest
    {
        /// <summary>
        /// 请求流水号
        /// </summary>
        [Display(Name = "请求流水号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string requestno { get; set; }

        /// <summary>
        /// 设备SN号
        /// </summary>
        [Display(Name = "设备SN号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string equipmentsnno { get; set; }
    }
}

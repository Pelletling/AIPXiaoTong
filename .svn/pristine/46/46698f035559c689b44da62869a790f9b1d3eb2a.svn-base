using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSP.Pay.ResponseModel;

namespace VSP.Pay.RequestModel
{
    public interface IBaseRequest<T> where T : BaseResponse
    {
        /// <summary>
        /// 获取请求地址。
        /// </summary>
        /// <returns>API名称</returns>
        string GetUrl();

        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 请求参数文本值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        Dictionary<string, string> GetParameters();
    }
}

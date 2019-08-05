using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuangDaAPI.Model
{
    public interface IBaseRequest<T> where T : BaseResponse
    {
        /// <summary>
        /// 调用方法  
        /// </summary>
        string Method { get; }

        string Action { get; }

        Dictionary<string, string> GetBody();

        HEAD Head { get; set; }

        string Sort(string signContent);
        
    }
}

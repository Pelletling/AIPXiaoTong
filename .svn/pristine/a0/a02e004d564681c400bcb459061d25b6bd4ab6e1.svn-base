using Framework.Common;
using Framework.Requests;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using VSP.Pay.RequestModel;
using VSP.Pay.ResponseModel;

namespace VSP.Pay
{
    public class VSPExec
    {
        public ILogger logger = LogManager.GetCurrentClassLogger();

        public string cusid { get; set; }
        public string key { get; set; }
        public string appid { get; set; }

        public VSPExec(string cusid, string key, string appid)
        {
            this.cusid = cusid;
            this.key = key;
            this.appid = appid;
        }

        public string GetParam<T>(IBaseRequest<T> request) where T : BaseResponse
        {
            string signString = "", postString = "";
            Dictionary<string, string> bizData = request.GetParameters();

            bizData.Add("cusid", cusid);
            bizData.Add("key", key);
            bizData.Add("appid", appid);

            foreach (var m in bizData.Where(t => !string.IsNullOrWhiteSpace(t.Value)).OrderBy(t => t.Key))
            {
                signString += "&" + m.Key + "=" + m.Value;

                if (m.Key != "key")
                {
                    postString += "&" + m.Key + "=" + m.Value;
                }
            }

            string sign = Framework.Security.Crypt.MD5(signString.Substring(1));

            return postString.Substring(1) + "&sign=" + sign;
        }

        public BaseResponse Exec<T>(IBaseRequest<T> request) where T : BaseResponse, new()
        {
            //拼接成URL

            string url = request.GetUrl();

            string txtParams = GetParam(request);

            string result = "";
            string exception = "";

            try
            {
                //请求
                result = Request.Post(url, txtParams);

                //把返回的内容序列化成对象
                var response = JsonHelper.Deserialize<T>(result);

                if (response.isRet)
                {
                    if (IsVerify(JsonHelper.Deserialize<Dictionary<string, string>>(result)))
                    {
                        return response;
                    }
                }
                else
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            finally
            {
                logger.Trace("（普通请求）请求地址：" + url + "，内容：" + txtParams + "，返回：" + result + ",http异常:" + exception);
            }

            return new T();
        }

        public bool IsVerify(Dictionary<string, string> dicVerify)
        {
            string signString = "";
            try
            {
                //验签
                //Dictionary<string, string> dicVerify = JsonHelper.Deserialize<Dictionary<string, string>>(result);

                if (!dicVerify.ContainsKey("sign"))
                    throw new Exception("验签失败，返回内容未包含sign信息");

                string resultSign = dicVerify["sign"];

                dicVerify.Add("key", this.key);
                dicVerify.Remove("sign");


                foreach (var m in dicVerify.Where(t => !string.IsNullOrWhiteSpace(t.Value)).OrderBy(t => t.Key))
                {
                    if (m.Key == "trxreserved")
                    {
                        signString += "&" + m.Key + "=" + System.Web.HttpUtility.UrlDecode(m.Value);
                    }
                    else
                    {
                        signString += "&" + m.Key + "=" + m.Value;
                    }
                }

                signString = signString.Substring(1);

                string sign = Framework.Security.Crypt.MD5(signString);

                if (sign.ToUpper() == resultSign.ToUpper())
                {
                    return true;
                }
                else
                {
                    logger.Trace("验签失败，签名原串为:" + signString + "，加密sign为：" + sign);
                    return false;
                }
            }
            catch (Exception ex)
            {

                logger.Trace("验签失败，签名原串为:" + signString + "，错误为：" + ex.Message);
                return false;
            }
          
        }

        public NotifyResponse Notify(System.Web.HttpRequestBase Request)
        {
            //测试
            //string result = "acct=olb9MuLyENyjsUtzwqw9s9ZuaL3c&appid=00008692&chnltrxid=4200000119201805246599107754&cusid=142581072993330&cusorderid=LYZ_20180524115717445&outtrxid=LYZ_20180524115717445&paytime=20180524115806&sign=4D6CF5879D691B5E663C1CDF9306548C&termauthno=LQT&termrefnum=4200000119201805246599107754&termtraceno=0&trxamt=1&trxcode=VSP501&trxdate=20180524&trxid=111857690000305187&trxstatus=0000";

            //生产
            string result = Request.Form.ToString();

            if (!string.IsNullOrWhiteSpace(result))
            {
                Dictionary<String, String> dic = new Dictionary<string, string>();

                foreach (var m in result.Split('&'))
                {
                    var value = m.Split('=');
                    dic.Add(value[0], value[1]);
                }

                if (IsVerify(dic))
                {
                    return JsonHelper.Deserialize<NotifyResponse>(JsonHelper.Serialize(dic));
                }
            }

            return null;
        }


    }
}

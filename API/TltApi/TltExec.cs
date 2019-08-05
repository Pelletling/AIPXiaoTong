using Framework.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TltApi.Model;

namespace TltApi
{
    public class TltExec
    {
        public string url, merchantId, userName, userPassword, privateKeyPassword, privateKey, publicKey, result;

        public TltExec(string url, string merchantId, string userName, string userPassword, string privateKeyPassword, string privateKey = "", string publicKey = "")
        {
            this.url = url;
            this.merchantId = merchantId;
            this.userName = userName;
            this.userPassword = userPassword;
            this.privateKeyPassword = privateKeyPassword;
            this.privateKey = privateKey;
            this.publicKey = publicKey;
        }

        public ILogger logger = LogManager.GetCurrentClassLogger();
        public string GetXml<T>(IBaseRequest<T> request) where T : BaseResponse
        {
            string signContent = "<?xml version=\"1.0\" encoding=\"GBK\"?>" + XmlHelper.XmlSerializer(request, encoding: Encoding.GetEncoding("GBK"));

            var sign = Framework.Security.Crypt.RSAEncryptByPrivateKeyTLT(signContent, this.privateKey, this.privateKeyPassword);

            string result = signContent.Substring(0, signContent.IndexOf("</REQ_SN>") + "</REQ_SN>".Length) + "<SIGNED_MSG>" + sign + "</SIGNED_MSG>" + signContent.Substring(signContent.IndexOf("</REQ_SN>") + "</REQ_SN>".Length);

            logger.Trace("（回调返回）待加密字符串：" + signContent + ",加密后:" + sign + "，返回：" + result);

            return result;
        }

        public BaseResponse Exec<T>(IBaseRequest<T> request) where T : BaseResponse, new()
        {
            //拼接成URL

            string xml = GetXml(request);

            string exception = "";

            try
            {
                result = Framework.Requests.Request.PostHttps(this.url, xml, Encoding.GetEncoding("GBK"));

                var response = XmlHelper.XmlDeserialize<T>(result, Encoding.GetEncoding("GBK"));
                
                //把返回的内容序列化成对象
                return response;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            finally
            {
                logger.Trace("（普通请求）请求地址：" + this.url + "，内容：" + xml + "，返回：" + result + ",异常:" + exception);
            }

            return new T();
        }

        public bool IsVerify()
        {
            //验签
            var signMsgStartIndex = result.IndexOf("<SIGNED_MSG>");
            var signMsgEndIndex = result.IndexOf("</SIGNED_MSG>");
            string responseString = result.Substring(0, signMsgStartIndex) + result.Substring(signMsgEndIndex + "</SIGNED_MSG>".Length);

            string responseMsg = result.Substring(signMsgStartIndex + "<SIGNED_MSG>".Length, signMsgEndIndex - signMsgStartIndex - "<SIGNED_MSG>".Length);

            bool checkResult = Framework.Security.Crypt.RSADecryptByPublicKey(responseString, responseMsg, this.publicKey);

            return checkResult;
        }
    }
}

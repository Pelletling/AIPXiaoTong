using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Framework.Requests
{
    public class Request
    {
        /// <summary>
        /// 发送HTTP请求 get方式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string Get(string url, Encoding encoding = null)
        {
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                using (WebResponse wr = request.GetResponse())
                {

                    Stream st = wr.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    if (encoding != null)
                    {
                        sr = new StreamReader(st, encoding);
                    }
                    return sr.ReadToEnd();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string Post(string url, Encoding encoding = null)
        {
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";

                using (WebResponse wr = request.GetResponse())
                {
                    Stream st = wr.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    if (encoding != null)
                    {
                        sr = new StreamReader(st, encoding);
                    }
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Post(string url, string PostString, SecurityProtocolType? securityProtocolType = null)
        {
            HttpWebRequest request = null;
            try
            {
                if (securityProtocolType != null)
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)securityProtocolType;
                }

                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                byte[] postData = Encoding.UTF8.GetBytes(PostString);
                System.IO.Stream reqStream = request.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                using (WebResponse wr = request.GetResponse())
                {
                    Stream st = wr.GetResponseStream();
                    StreamReader sr = new StreamReader(st);
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public static string PostHttps(string url, string postString, Encoding encoding)
        {
            HttpWebRequest request = request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //HTTPS请求
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = DefaultUserAgent;

            //写入数据
            var postData = encoding.GetBytes(postString);
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            //读取数据
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, encoding);
            var respText = sr.ReadToEnd();
            resStream.Close();

            return respText;
        }

        private static string Post(string url, int timeOut, string fileKeyName, string filePath, NameValueCollection stringDict)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符
            var beginBoundary = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符
            var endBoundary = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

            // 设置属性
            webRequest.Method = "POST";
            webRequest.Timeout = timeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // 写入文件
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, filePath);
            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            // 写入字符串的Key
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in stringDict.Keys
                                             select string.Format(stringKeyHeader, key, stringDict[key])
                                                 into formitem
                                             select System.Text.Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // 写入最后的结束边界符
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

            using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                            System.Text.Encoding.GetEncoding("utf-8")))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }

            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();

            return responseContent;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { // 总是接受 
            return true;
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public static bool Download(string url, string path)
        {
            //string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            //System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            //string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件

            //if (System.IO.File.Exists(tempFile))
            //{
            //    System.IO.File.Delete(tempFile);    //存在则删除
            //}


            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            //创建本地文件写入流

            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                fs.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            fs.Close();
            responseStream.Close();
            //System.IO.File.Move(tempFile, path);
            return true;

        }

        /// <summary>
        /// 发送HTTP请求 get方式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static Stream GetStream(string url, Encoding encoding = null)
        {
            HttpWebRequest request = null;

            request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            using (WebResponse wr = request.GetResponse())
            {
                Stream st = wr.GetResponseStream();

                return st;
            }
        }
    }
}

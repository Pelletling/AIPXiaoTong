using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Framework.Requests
{
    public class FtpHelper
    {
        public string ip { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public FtpHelper(string ip, string user, string password)
        {
            this.ip = ip;
            this.user = user;
            this.password = password;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="downloadPath">下载FTP的路径</param>
        /// <param name="SavePath">保存的文件路径</param>
        /// <returns></returns>
        public int Download(string downloadPath, string SavePath)
        {
            FtpWebRequest reqFTP;
            FileStream outputStream = new FileStream(SavePath, FileMode.Create);

            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ip + "/" + downloadPath));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(user, password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return readCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                outputStream.Close();
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="uploadPath">原文件的路径</param>
        /// <param name="savePath">上传到FTP的路径</param>
        public void Upload(string uploadPath, string savePath)
        {
            FileInfo fileInf = new FileInfo(uploadPath);
            string uri = ip + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided  
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            // Provide the WebPermission Credintials  
            reqFTP.Credentials = new NetworkCredential(user, password);

            // By default KeepAlive is true, where the control connection is not closed  
            // after a command is executed.  
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.  
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file  
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded  
            using (FileStream fs = fileInf.OpenRead())
            {
                try
                {
                    // Stream to which the file to be upload is written  
                    using (Stream strm = reqFTP.GetRequestStream())
                    {

                        // Read from the file stream 2kb at a time  
                        contentLen = fs.Read(buff, 0, buffLength);

                        // Till Stream content ends  
                        while (contentLen != 0)
                        {
                            // Write Content from the file stream to the FTP Upload Stream  
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }

                        // Close the file stream and the Request Stream  
                        //strm.Close();  
                        //fs.Close();  
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    fs.Close();
                }
            }

        }
    }
}
